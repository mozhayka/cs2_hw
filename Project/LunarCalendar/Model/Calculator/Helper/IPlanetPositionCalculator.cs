using Objects;

namespace Calculator.Helper
{
    public interface IPlanetPositionCalculator
    {
        public double CalculatePosition(AstroObject planet, double jd, Coordinates? coordinates = null, bool topocentric = false);
    }
}
