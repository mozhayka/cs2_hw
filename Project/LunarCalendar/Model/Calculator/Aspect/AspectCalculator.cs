using System.Numerics;
using Calculator.Helper;
using Objects;

namespace Calculator
{
    // The Open-Closed Principle - AspectCalculator реализует поиск аспектов в сутках полным перебором
    // Можно реализовать более умный способ поиска, и тогда придется лишь изменить класс, реализующий интерфейс IAspectCalculator
    public partial class AspectsCalculator : IAspectCalculator
    {
        private readonly IPlanetPositionCalculator calculator;
        public const double EpsAngle = 1e-3;
        public const double EpsJd = 1e-3;
        
        public AspectsCalculator(IPlanetPositionCalculator calculator)
        {
            this.calculator = calculator;
        }

        public List<LunarAspect> FindLunarAspects(DateTime date, Coordinates coordinates, bool septener)
        {
            return FindLunarAspects(TimeCalculator.GetJulDay(date), TimeCalculator.GetJulDay(date.AddDays(1)), coordinates, septener);
        }

        public List<LunarAspect> FindLunarAspects(double jdFrom, double jdTo, Coordinates coordinates, bool septener)
        {
            var planets = septener ? InterestingPlanets.Septener : InterestingPlanets.All;
            return FindLunarAspects(jdFrom, jdTo, coordinates, planets);
        }

        private double GetAngle(AstroObject planet1, AstroObject planet2, double jdExactTime, Coordinates coordinates)
        {
            var planet1_Position = calculator.CalculatePosition(planet1, jdExactTime, coordinates);
            var planet2_Position = calculator.CalculatePosition(planet2, jdExactTime, coordinates);

            if (planet1_Position < planet2_Position)
                planet1_Position += 360;

            return planet1_Position - planet2_Position;
        }
    }
}
