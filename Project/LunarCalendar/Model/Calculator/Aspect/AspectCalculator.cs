using System.Numerics;
using Calculator.Helper;
using Objects;

namespace Calculator
{
    // The Open-Closed Principle - AspectCalculator реализует поиск аспектов в сутках полным перебором
    // Можно реализовать более умный способ поиска, и тогда придется лишь изменить класс, реализующий интерфейс IAspectCalculator
    public class AspectCalculator : IAspectCalculator
    {
        private readonly IPlanetPositionCalculator calculator;
        
        public AspectCalculator(IPlanetPositionCalculator calculator)
        {
            this.calculator = calculator;
        }

        // Находит только первые аспекты луны с планетами (так как Луна проходит за день примерно 12 градусов, то с одной планетой расстояние между аспектами хотя бы 2 дня)
        // Может сломаться, если передать слишком большой промежуток времени
        public List<LunarAspect> FindLunarAspects(CalculationParameters parameters)
        {
            var planets = InterestingPlanets.All;
            return FindLunarAspects(parameters, planets);
        }

        public List<LunarAspect> FindLunarAspects(CalculationParameters parameters, AstroObject[] planets)
        {
            var jdFrom = TimeCalculator.GetJulDay(parameters.DateUTC);
            var jdTo = TimeCalculator.GetJulDay(parameters.DateUTC.AddDays(1));
            return FindLunarAspects(jdFrom, jdTo, planets, parameters.Coordinates);
        }

        public List<LunarAspect> FindLunarAspects(double jdFrom, double jdTo, AstroObject[] planets, Coordinates? coordinates)
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
            return aspects.OrderBy(a => a.ExactTime).ToList();
        }

        private LunarAspect? TryFindOneLunarAspect(AstroObject planet, double jdFrom, double jdTo, Coordinates? coordinates)
        {
            var moon = AstroObject.Moon;
            var exactJd = TryFindNextLunarAspectExactTime(planet, jdFrom, jdTo, coordinates);
            if (exactJd == null)
                return null;
            
            var exactJD = (double)exactJd;
            var date = TimeCalculator.FromJulDay(exactJD);
            var angle = calculator.GetAngle(moon, planet, exactJD, coordinates);
            var aspectType = AspectTypeCalc.GetAspectType(angle, Const.DegMinute);

            if (aspectType == null)
                throw new Exception($"Coludn't recognize aspect type\n" +
                    $"angle = {angle}, eps = {Const.DegMinute}");

            var moonPosition = calculator.CalculatePosition(moon, exactJD, coordinates);
            var planetPosition = calculator.CalculatePosition(planet, exactJD, coordinates);

            var moonZodiac = ZodiacCalc.FromAngle(moonPosition);
            var planetZodiac = ZodiacCalc.FromAngle(planetPosition);
            return new LunarAspect(date, planet, (AspectType)aspectType, moonZodiac, planetZodiac, DMS.FromDegrees(moonPosition));
        }

        private double? TryFindNextLunarAspectExactTime(AstroObject planet, double jdFrom, double jdTo, Coordinates? coordinates)
        {
            var moon = AstroObject.Moon;
            var startAngle = calculator.GetAngle(moon, planet, jdFrom, coordinates);
            var endAngle = calculator.GetAngle(moon, planet, jdTo, coordinates);

            if (SectorCalc.IsSameAspectSectors(startAngle, endAngle))
                return null;

            var leftJd = jdFrom;
            var rightJd = jdTo;

            while (rightJd - leftJd > Const.SecondJd)
            {
                var midJd = (leftJd + rightJd) / 2;
                var midAngle = calculator.GetAngle(moon, planet, midJd, coordinates);
                if (SectorCalc.IsSameSectors(startAngle, midAngle))
                    leftJd = midJd;
                else
                    rightJd = midJd;
            }

            return leftJd;
        }
    }
}
