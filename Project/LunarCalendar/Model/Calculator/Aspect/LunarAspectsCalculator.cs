using Objects;

namespace Calculator
{
    public partial class AspectsCalculator : IAspectCalculator
    {
        // Находит только первые аспекты луны с планетами
        // Может сломаться, если передать слишком большой промежуток времени
        public List<LunarAspect> FindLunarAspects(double jdFrom, double jdTo, Coordinates coordinates, AstroObject[] planets)
        {
            var aspects = new List<LunarAspect>();
            foreach (var planet in planets)
            {
                if (planet.Equals(AstroObject.Moon))
                    continue;
                var aspect = TryFindOneLunarAspect(planet, jdFrom, jdTo, coordinates);
                if (aspect != null)
                    aspects.Add(aspect);
            }
            return aspects;
        }

        private LunarAspect? TryFindOneLunarAspect(AstroObject planet, double jdFrom, double jdTo, Coordinates coordinates, double eps = EpsAngle)
        {
            var moon = AstroObject.Moon;
            var startAngle = GetAngle(moon, planet, jdFrom, coordinates);
            var endAngle = GetAngle(moon, planet, jdTo, coordinates);

            if (SectorCalc.IsSameAspectSectors(startAngle, endAngle))
                return null;

            var leftJd = jdFrom;
            var rightJd = jdTo;

            while (rightJd - leftJd > EpsJd)
            {
                var midJd = (jdTo - jdFrom) / 2;
                var midAngle = GetAngle(moon, planet, midJd, coordinates);
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
            var angle = GetAngle(moon, planet, leftJd, coordinates);
            var aspectType = AspectTypeCalc.GetAspectType(angle, eps);

            if (aspectType == null)
                throw new Exception($"Coludn't recognize aspect type\n" +
                    $"angle = {angle}, eps = {eps}");

            return new LunarAspect(date, planet, (AspectType)aspectType);
        }
    }
}
