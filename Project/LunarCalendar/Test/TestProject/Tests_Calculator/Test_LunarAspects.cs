using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;
using Objects;

namespace TestProject.Tests_Calculator
{
    internal class Test_LunarAspects
    {
        readonly IAspectCalculator calc = new AspectCalculator(new PlanetPositionCalculator());
        const double minute = (double)1 / (24 * 60);

        [Test]
        public void Test1()
        {
            var date = new DateTime(2021, 02, 19).AddHours(-3);
            var coordinates = InterestingCoordinates.Moscow;
            var actual = calc.FindLunarAspects(date, coordinates, false);
            var expected = new List<LunarAspect>
            {
                new LunarAspect(new DateTime(2021, 02, 19, 02, 21, 00).AddHours(-3), AstroObject.Venus, AspectType.Square),
                new LunarAspect(new DateTime(2021, 02, 19, 03, 48, 00).AddHours(-3), AstroObject.Mars, AspectType.Conjunction),
                new LunarAspect(new DateTime(2021, 02, 19, 10, 28, 00).AddHours(-3), AstroObject.Pluto, AspectType.Trine),
                new LunarAspect(new DateTime(2021, 02, 19, 21, 47, 00).AddHours(-3), AstroObject.Sun, AspectType.Square),
            };

            for (int i = 0; i < expected.Count; i++)
                CompareLunarAspects(actual[i], expected[i]);
        }

        private void CompareLunarAspects(LunarAspect actual, LunarAspect expected)
        {
            Assert.Multiple(() =>
            {
                Assert.That(actual.AstroObject, Is.EqualTo(expected.AstroObject));
                Assert.That(actual.Type, Is.EqualTo(expected.Type));
                Assert.That(actual.ExactTime,
                    Is.EqualTo(expected.ExactTime).Within(minute));
            });
        }
    }
}
