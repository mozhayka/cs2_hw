using Calculator.Helper;
using Objects;

namespace Calculator
{
    public class LBKCalculator : ILBKCalculator
    {
        private IPlanetPositionCalculator calculator;
        public const double SecondJd = (double)1 / (24 * 60 * 60);

        public LBKCalculator(IPlanetPositionCalculator calculator)
        {
            this.calculator = calculator;
        }

        public List<LBK> FindAllLBK(CalculationParameters parameters)
        {
            throw new NotImplementedException();
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
    }
}
