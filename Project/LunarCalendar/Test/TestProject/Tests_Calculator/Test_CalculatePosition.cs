using Calculator;
using Calculator.Helper;
using Objects;

namespace TestProject.Tests_Calculator
{
    internal class Test_CalculatePosition
    {
        const double DegMinute = (double)1 / 60;
        readonly IPlanetPositionCalculator calc = new PlanetPositionCalculator();

        [Test]
        public void Test_MoonPositionGeocentric()
        {
            var date = new DateTime(2021, 2, 19, 02, 21, 00).AddHours(-3); // Перевод локального времени в UTC
            var coordinates = InterestingCoordinates.Moscow;
            var planet = AstroObject.Moon;

            var jd = TimeCalculator.GetJulDay(date);
            var actual = calc.CalculatePosition(planet, jd);
            var expected = new DMS(51, 46, 27).ToDegrees();

            Assert.That(actual, Is.EqualTo(expected).Within(DegMinute));
        }

        [Test]
        public void Test_MoonPositionTopocentric()
        {
            var date = new DateTime(2023, 04, 18, 13, 42, 00); 
            var coordinates = InterestingCoordinates.Moscow;
            var planet = AstroObject.Moon;

            var jd = TimeCalculator.GetJulDay(date);
            var actual = calc.CalculatePosition(planet, jd, coordinates, true);
            var expected_geocentric = new DMS(7, 25, 20).ToDegrees();
            var expected_topocentric = new DMS(6,35, 50).ToDegrees();

            Assert.That(actual, Is.EqualTo(expected_topocentric).Within(DegMinute));
        }

        [Test]
        public void Test_SeptenerPosition()
        {
            var date = new DateTime(2021, 2, 19, 02, 21, 00).AddHours(-3);
            var coordinates = InterestingCoordinates.Moscow;
            var jd = TimeCalculator.GetJulDay(date);
            Console.WriteLine($"UTC time {date}");

            var Moon = calc.CalculatePosition(AstroObject.Moon, jd, coordinates);
            Console.WriteLine($"Moon coordinates: {DMS.FromDegrees(Moon)}");

            var Sun = calc.CalculatePosition(AstroObject.Sun, jd, coordinates);
            Console.WriteLine($"Sun coordinates: {DMS.FromDegrees(Sun)}");
            
            var Mercury = calc.CalculatePosition(AstroObject.Mercury, jd, coordinates);
            Console.WriteLine($"Mercury coordinates: {DMS.FromDegrees(Mercury)}");
            
            var Venus = calc.CalculatePosition(AstroObject.Venus, jd, coordinates);
            Console.WriteLine($"Venus coordinates: {DMS.FromDegrees(Venus)}");
            
            var Mars = calc.CalculatePosition(AstroObject.Mars, jd, coordinates);
            Console.WriteLine($"Mars coordinates: {DMS.FromDegrees(Mars)}");
            
            var Jupiter = calc.CalculatePosition(AstroObject.Jupiter, jd, coordinates);
            Console.WriteLine($"Jupiter coordinates: {DMS.FromDegrees(Jupiter)}");
            
            var Saturn = calc.CalculatePosition(AstroObject.Saturn, jd, coordinates);
            Console.WriteLine($"Saturn coordinates: {DMS.FromDegrees(Saturn)}");

            Assert.Multiple(() =>
            {
                Assert.That(Moon, Is.EqualTo(51.77).Within(DegMinute), "Moon");
                Assert.That(Sun, Is.EqualTo(330.53).Within(DegMinute), "Sun");
                Assert.That(Mercury, Is.EqualTo(311.27).Within(DegMinute), "Mercury");
                Assert.That(Venus, Is.EqualTo(321.77).Within(DegMinute), "Venus");
                Assert.That(Mars, Is.EqualTo(52.45).Within(DegMinute), "Mars");
                Assert.That(Jupiter, Is.EqualTo(314.29).Within(DegMinute), "Jupiter");
                Assert.That(Saturn, Is.EqualTo(307.36).Within(DegMinute), "Saturn");
            });
        }
    }
}
