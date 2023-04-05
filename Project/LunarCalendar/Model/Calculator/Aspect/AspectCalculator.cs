using Calculator.Helper;
using Objects;

namespace Calculator
{
    // The Open-Closed Principle - AspectCalculator реализует поиск аспектов в сутках полным перебором
    // Можно реализовать более умный способ поиска, и тогда придется лишь изменить класс, реализующий интерфейс IAspectCalculator
    public class AspectsCalculator : IAspectCalculator
    {
        private readonly IPlanetPositionCalculator calculator;
        public readonly AstroObject[] InterestingPlanets = (AstroObject[])Enum.GetValues(typeof(AstroObject));
        public const double EpsAngle = 1e-3;
        public const double EpsJd = 1e-3;
        
        public AspectsCalculator(IPlanetPositionCalculator calculator)
        {
            this.calculator = calculator;
        }

        public List<Aspect> FindAllAspects(DateTime date, Coordinates coorinates)
        {
            return FindAllAspects(TimeCalculator.GetJulDay(date), TimeCalculator.GetJulDay(date.AddDays(1)), coorinates);
        }

        public List<Aspect> FindAllAspects(double jdFrom, double jdTo, Coordinates coorinates)
        {
            List<Aspect> aspects = new List<Aspect>();
            for (int i = 0; i < InterestingPlanets.Length; i++)
            {
                var planet1 = InterestingPlanets[i];
                var planets = InterestingPlanets.Skip(i).ToArray();
                aspects.AddRange(FindAllAspects(planet1, planets, jdFrom, jdTo, coorinates));
            }
            return aspects;
        }

        public List<Aspect> FindAllAspects(AstroObject planet1, AstroObject[] planets, double jdFrom, double jdTo, Coordinates coordinates)
        {
            var aspects = new List<Aspect>();
            foreach (var planet2 in planets)
            {
                if (planet2.Equals(planet1))
                    continue;
                var aspect = TryFindOneAspect(planet1, planet2, jdFrom, jdTo, coordinates);
                if (aspect != null)
                    aspects.Add(aspect);
            }
            return aspects;
        }

        private Aspect? TryFindOneAspect(AstroObject planet1, AstroObject planet2, double jdFrom, double jdTo, Coordinates coordinates, double eps = EpsAngle)
        {
            var startAngle = GetAngle(planet1, planet2, jdFrom, coordinates);
            var endAngle = GetAngle(planet1, planet2, jdTo, coordinates);

            if (SectorCalc.IsSameAspectSectors(startAngle, endAngle))
                return null;

            var leftJd = jdFrom;
            var rightJd = jdTo;

            while (rightJd - leftJd > EpsJd)
            {
                var midJd = (jdTo - jdFrom) / 2;
                var midAngle = GetAngle(planet1, planet2, midJd, coordinates);
                if (SectorCalc.IsSameSectors(startAngle, midAngle))
                {
                    leftJd = midJd;
                }
                else
                {
                    rightJd = midJd;
                }
            }

            var date = TimeCalculator.FromJulDay(leftJd);
            var angle = GetAngle(planet1, planet2, leftJd, coordinates);
            var aspectType = AspectTypeCalc.GetAspectType(angle, eps);

            if (aspectType == null)
                throw new Exception($"Coludn't recognize aspect type\n angle = {angle}, eps = {eps}");

            return new Aspect(date, planet1, planet2, (AspectType)aspectType);
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
