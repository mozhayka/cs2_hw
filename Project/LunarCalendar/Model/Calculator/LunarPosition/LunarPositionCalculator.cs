using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Helper;
using Objects;

namespace Calculator
{
    public class LunarPositionCalculator : ILunarPositionCalculator
    {
        public const double SecondJd = (double)1 / (24 * 60 * 60);
        private readonly IPlanetPositionCalculator calculator;

        public LunarPositionCalculator(IPlanetPositionCalculator calculator)
        {
            this.calculator = calculator;
        }

        public double NextLunarSignTime(double jd, Coordinates? coordinates = null)
        {
            var moon = AstroObject.Moon;
            var leftJd = jd;
            var rightJd = jd + 5;
            var startPosition = calculator.CalculatePosition(moon, jd, coordinates);

            while (rightJd - leftJd > SecondJd)
            {
                var midJd = (leftJd + rightJd) / 2;
                var midPosition = calculator.CalculatePosition(moon, midJd, coordinates);
                if (SectorCalc.IsSameSectors(startPosition, midPosition))
                    leftJd = midJd;
                else
                    rightJd = midJd;
            }

            return rightJd;
        }

        public LunarInformation LunarInformation(CalculationParameters parameters)
        {
            var jdFrom = TimeCalculator.GetJulDay(parameters.DateUTC);
            var jdTo = TimeCalculator.GetJulDay(parameters.DateUTC.AddDays(1));
            return new LunarInformation()
            {
                LunarIngression = LunarIngression(jdFrom, jdTo, parameters.Coordinates),

                StartSign = LunarInZodiac(jdFrom, parameters.Coordinates),
                EndSign = LunarInZodiac(jdTo, parameters.Coordinates),

                StartPhase = LunarInPhase(jdFrom, parameters.Coordinates),
                EndPhase = LunarInPhase(jdTo, parameters.Coordinates)
            };
        }

        private Zodiac LunarInZodiac(double jd, Coordinates? coordinates)
        {
            var moon = AstroObject.Moon;
            var position = calculator.CalculatePosition(moon, jd, coordinates);
            return ZodiacCalc.FromAngle(position);
        }

        private LunarPhase LunarInPhase(double jd, Coordinates? coordinates)
        {
            var moon = AstroObject.Moon;
            var sun = AstroObject.Sun;
            var angle = calculator.GetAngle(moon, sun, jd, coordinates);
            return LunarPhaseCalc.FromAngle(angle);
        }

        private DateTime? LunarIngression(double jd, double maxJd, Coordinates? coordinates)
        {
            var nextSignJd = NextLunarSignTime(jd, coordinates);
            if (nextSignJd > maxJd)
                return null;
            return TimeCalculator.FromJulDay(nextSignJd);
        }
    }
}
