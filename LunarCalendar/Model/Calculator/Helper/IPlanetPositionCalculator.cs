using Objects;

namespace Calculator.Helper
{
    public interface IPlanetPositionCalculator
    {
        public double CalculatePosition(AstroObject planet, double jd, Coordinates? coordinates = null);
        public double GetAngle(AstroObject planet1, AstroObject planet2, double jdExactTime, Coordinates? coordinates);
    }
}
