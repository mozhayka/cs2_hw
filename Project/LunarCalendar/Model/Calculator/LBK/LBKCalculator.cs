using Calculator.Helper;
using Objects;

namespace Calculator
{
    public class LBKCalculator : ILBKCalculator
    {
        private readonly IPlanetPositionCalculator calculator;
        private readonly IAspectCalculator aspectCalculator;
        public const double SecondJd = (double)1 / (24 * 60 * 60);

        public LBKCalculator(IPlanetPositionCalculator calculator, IAspectCalculator aspectCalculator)
        {
            this.calculator = calculator;
            this.aspectCalculator = aspectCalculator;
        }

        public List<LBK> FindAllLBK(CalculationParameters parameters)
        {
            List<LBK> lbKList = new();
            var newSignJd = NextLunarSignTime(parameters.JdFrom, parameters.Coordinates, parameters.Topocentric);
            if (newSignJd < parameters.JdTo)
            {
                var lbk1 = FindLBK(parameters.JdFrom, newSignJd - SecondJd, parameters);
                var lbk2 = FindLBK(newSignJd, parameters.JdTo, parameters);

                if (lbk1 != null)
                    lbKList.Add(lbk1);

                if (lbk2 != null)
                    lbKList.Add(lbk2);
            }
            else
            {
                var lbk = FindLBK(parameters.JdFrom, parameters.JdTo, parameters);
                if (lbk != null)
                    lbKList.Add(lbk);
            }
            return lbKList;
        }

        public double NextLunarSignTime(double jd, Coordinates? coordinates = null, bool topocentric = false)
        {
            var moon = AstroObject.Moon;
            var leftJd = jd;
            var rightJd = jd + 5;
            var startPosition = calculator.CalculatePosition(moon, jd, coordinates, topocentric);

            while (rightJd - leftJd > SecondJd)
            {
                var midJd = (leftJd + rightJd) / 2;
                var midPosition = calculator.CalculatePosition(moon, midJd, coordinates, topocentric);
                if (SectorCalc.IsSameSectors(startPosition, midPosition))
                    leftJd = midJd;
                else
                    rightJd = midJd;
            }

            return rightJd;
        }

        private LBK? FindLBK(double jdStart, double jdEndOfSign, CalculationParameters parameters)
        {
            var lbkStart = TimeOfLastLunarAspect(jdStart, jdEndOfSign, parameters) ?? jdStart;

            var lbkFrom = TimeCalculator.FromJulDay(Math.Max(lbkStart, parameters.JdFrom));
            var lbkTo = TimeCalculator.FromJulDay(Math.Min(jdEndOfSign, parameters.JdTo));
            if (lbkFrom > lbkTo)
                return null;
            return new LBK(lbkFrom, lbkTo);
        }

        private double? TimeOfLastLunarAspect(double jdFrom, double jdTo, CalculationParameters parameters)
        {
            var lunarAspects = aspectCalculator.FindLunarAspects(new CalculationParameters(jdFrom, jdTo, parameters));
            if (lunarAspects.Count > 0)
                return TimeCalculator.GetJulDay(lunarAspects[^1].ExactTime);
            return null;
        }
    }
}
