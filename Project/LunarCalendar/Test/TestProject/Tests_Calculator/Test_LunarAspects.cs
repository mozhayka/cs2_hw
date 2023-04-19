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

        [Test]
        public void Test1()
        {
            var date = new DateTime(2021, 02, 19).AddHours(-3);
            // var coordinates = InterestingCoordinates.Moscow;
            var parameters = new CalculationParameters(TimeCalculator.GetJulDay(date), TimeCalculator.GetJulDay(date.AddDays(1)), false);
            var actual = calc.FindLunarAspects(parameters);
            var expected = new List<LunarAspect>
            {
                new LunarAspect(new DateTime(2021, 02, 19, 02, 21, 00).AddHours(-3), AstroObject.Venus, AspectType.Square),
                new LunarAspect(new DateTime(2021, 02, 19, 03, 48, 00).AddHours(-3), AstroObject.Mars, AspectType.Conjunction),
                new LunarAspect(new DateTime(2021, 02, 19, 10, 28, 00).AddHours(-3), AstroObject.Pluto, AspectType.Trine),
                new LunarAspect(new DateTime(2021, 02, 19, 21, 47, 00).AddHours(-3), AstroObject.Sun, AspectType.Square),
            };

            CompareLunarAspects(actual, expected);
        }

        [Test]
        public void Test2()
        {
            var date = new DateTime(2020, 05, 13).AddHours(-3);
            // var coordinates = InterestingCoordinates.Moscow;
            var parameters = new CalculationParameters(TimeCalculator.GetJulDay(date), TimeCalculator.GetJulDay(date.AddDays(1)), false);
            var actual = calc.FindLunarAspects(parameters);
            var expected = new List<LunarAspect>
            {
                new LunarAspect(new DateTime(2020, 05, 13, 08, 51, 00).AddHours(-3), AstroObject.Uranus, AspectType.Square),
            };

            CompareLunarAspects(actual, expected);
        }

        [Test]
        public void Test3()
        {
            var date = new DateTime(2020, 01, 13).AddHours(-3);
            // var coordinates = InterestingCoordinates.Moscow;
            var parameters = new CalculationParameters(TimeCalculator.GetJulDay(date), TimeCalculator.GetJulDay(date.AddDays(1))); //, false);
            var actual = calc.FindLunarAspects(parameters);
            var expected = new List<LunarAspect>
            {
                new LunarAspect(new DateTime(2020, 01, 13, 16, 41, 00).AddHours(-3), AstroObject.Venus, AspectType.Opposition),
                // new LunarAspect(new DateTime(2020, 01, 13, 21, 29, 00).AddHours(-3), AstroObject.Uranus, AspectType.Trine),
            };

            CompareLunarAspects(actual, expected);
        }

        private void CompareLunarAspects(List<LunarAspect> actual, List<LunarAspect> expected)
        {
            Assert.Multiple(() =>
            {
                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.That(actual[i].AstroObject, Is.EqualTo(expected[i].AstroObject));
                    Assert.That(actual[i].Type, Is.EqualTo(expected[i].Type));
                    Assert.That(actual[i].ExactTime,
                        Is.EqualTo(expected[i].ExactTime).Within(TimeSpan.FromMinutes(1)));
                }
            });
        }
    }
}
