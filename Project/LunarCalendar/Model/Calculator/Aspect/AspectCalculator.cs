using System.Numerics;
using Calculator.Helper;
using Objects;

namespace Calculator
{
    // The Open-Closed Principle - AspectCalculator реализует поиск аспектов в сутках полным перебором
    // Можно реализовать более умный способ поиска, и тогда придется лишь изменить класс, реализующий интерфейс IAspectCalculator
    public partial class AspectCalculator : IAspectCalculator
    {
        private readonly IPlanetPositionCalculator calculator;
        public const double SecondJd = (double) 1 / (24 * 60 * 60);
        
        public AspectCalculator(IPlanetPositionCalculator calculator)
        {
            this.calculator = calculator;
        }

        // Находит только первые аспекты луны с планетами (так как Луна проходит за день примерно 12 градусов, то с одной планетой расстояние между аспектами хотя бы 2 дня)
        // Может сломаться, если передать слишком большой промежуток времени
        public List<LunarAspect> FindLunarAspects(CalculationParameters parameters)
        {
            var aspects = new List<LunarAspect>();
            foreach (var planet in parameters.Planets)
            {
                if (planet.Equals(AstroObject.Moon))
                    continue;
                var aspect = TryFindOneLunarAspect(planet, parameters);
                if (aspect != null)
                    aspects.Add(aspect);
            }
            return aspects.OrderBy(a => a.ExactTime).ToList();
        }

        private double GetAngle(AstroObject planet1, AstroObject planet2, double jdExactTime, Coordinates? coordinates, bool topocentric)
        {
            var planet1_Position = calculator.CalculatePosition(planet1, jdExactTime, coordinates, topocentric);
            var planet2_Position = calculator.CalculatePosition(planet2, jdExactTime, coordinates, topocentric);

            if (planet1_Position < planet2_Position)
                planet1_Position += 360;

            return planet1_Position - planet2_Position;
        }
    }
}
