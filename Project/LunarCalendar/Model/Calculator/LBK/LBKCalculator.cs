using Calculator.Helper;
using Objects;

namespace Calculator
{
    public class LBKCalculator : ILBKCalculator
    {
        private readonly ILunarPositionCalculator lunarCalculator;
        private readonly IAspectCalculator aspectCalculator;
        public const double SecondJd = (double)1 / (24 * 60 * 60);

        public LBKCalculator(ILunarPositionCalculator lunarCalculator, IAspectCalculator aspectCalculator)
        {
            this.lunarCalculator = lunarCalculator;
            this.aspectCalculator = aspectCalculator;
        }

        public List<LBK> FindAllLBK(CalculationParameters parameters, bool septener)
        {
            var jdFrom = TimeCalculator.GetJulDay(parameters.DateUTC);
            var jdTo = TimeCalculator.GetJulDay(parameters.DateUTC.AddDays(1));
            List<LBK> lbKList = new();

            var newSignJd = lunarCalculator.NextLunarSignTime(jdFrom, parameters.Coordinates);
            if (newSignJd < jdTo)
            {
                var lbk1 = FindLBK(jdFrom, newSignJd - SecondJd, jdFrom, jdTo, septener, parameters.Coordinates);
                if (lbk1 != null)
                    lbKList.Add(lbk1);

                var lbk2 = FindLBK(newSignJd, jdTo, jdFrom, jdTo, septener, parameters.Coordinates);
                if (lbk2 != null)
                    lbKList.Add(lbk2);
            }
            else
            {
                var lbk = FindLBK(jdFrom, jdTo, jdFrom, jdTo, septener, parameters.Coordinates);
                if (lbk != null)
                    lbKList.Add(lbk);
            }
            return lbKList;
        }

        private LBK? FindLBK(double jdStart, double jdEndOfSign, double jdFrom, double jdTo, bool septener, Coordinates? coordinates)
        {
            var lbkStart = TimeOfLastLunarAspect(jdStart, jdEndOfSign, septener, coordinates) ?? jdStart;

            var lbkFrom = TimeCalculator.FromJulDay(Math.Max(lbkStart, jdFrom));
            var lbkTo = TimeCalculator.FromJulDay(Math.Min(jdEndOfSign, jdTo));
            if (lbkFrom > lbkTo)
                return null;
            return new LBK(lbkFrom, lbkTo);
        }

        private double? TimeOfLastLunarAspect(double jdFrom, double jdTo, bool septener, Coordinates? coordinates)
        {
            var planets = septener ? InterestingPlanets.Septener : InterestingPlanets.All;
            var lunarAspects = aspectCalculator.FindLunarAspects(jdFrom, jdTo, planets, coordinates);
            if (lunarAspects.Count > 0)
                return TimeCalculator.GetJulDay(lunarAspects[^1].ExactTime);
            return null;
        }
    }
}
