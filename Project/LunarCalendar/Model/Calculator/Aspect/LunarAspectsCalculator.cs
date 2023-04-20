using System.Numerics;
using Objects;

namespace Calculator
{
    public partial class AspectCalculator : IAspectCalculator
    {
        private LunarAspect? TryFindOneLunarAspect(AstroObject planet, CalculationParameters parameters)
        {
            var moon = AstroObject.Moon;
            var startAngle = GetAngle(moon, planet, parameters.JdFrom, parameters.Coordinates, parameters.Topocentric);
            var endAngle = GetAngle(moon, planet, parameters.JdTo, parameters.Coordinates, parameters.Topocentric);

            if (SectorCalc.IsSameAspectSectors(startAngle, endAngle))
                return null;

            var leftJd = parameters.JdFrom;
            var rightJd = parameters.JdTo;

            while (rightJd - leftJd > SecondJd)
            {
                var midJd = (leftJd + rightJd) / 2;
                var midAngle = GetAngle(moon, planet, midJd, parameters.Coordinates, parameters.Topocentric);
                if (SectorCalc.IsSameSectors(startAngle, midAngle))
                    leftJd = midJd;
                else
                    rightJd = midJd;
            }

            var date = TimeCalculator.FromJulDay(leftJd);
            var angle = GetAngle(moon, planet, leftJd, parameters.Coordinates, parameters.Topocentric);
            var aspectType = AspectTypeCalc.GetAspectType(angle, parameters.EpsDeg);

            if (aspectType == null)
                throw new Exception($"Coludn't recognize aspect type\n" +
                    $"angle = {angle}, eps = {parameters.EpsDeg}");

            var moonPosition = calculator.CalculatePosition(moon, leftJd, parameters.Coordinates, parameters.Topocentric);
            var planetPosition = calculator.CalculatePosition(planet, leftJd, parameters.Coordinates, parameters.Topocentric);

            var moonZodiac = ZodiacCalc.FromAngle(moonPosition);
            var planetZodiac = ZodiacCalc.FromAngle(planetPosition);
            return new LunarAspect(date, planet, (AspectType)aspectType, moonZodiac, planetZodiac, DMS.FromDegrees(moonPosition));
        }
    }
}
