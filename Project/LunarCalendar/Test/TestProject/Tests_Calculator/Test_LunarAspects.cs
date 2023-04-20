using Calculator;
using Calculator.Helper;
using LunarCalendarVM;
using Microsoft.Extensions.DependencyInjection;
using Objects;

namespace TestProject.Tests_Calculator
{
    internal class Test_LunarAspects
    {
        IAspectCalculator calc;

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();

            services.AddTransient<IPlanetPositionCalculator, PlanetPositionCalculator>();

            services.AddTransient<IAspectCalculator, AspectCalculator>();
            services.AddTransient<ILunarPositionCalculator, LunarPositionCalculator>();

            services.AddTransient<ILBKCalculator, LBKCalculator>();

            services.AddTransient<IDayInformationCalculator, DayInformationCalculator>();

            var provider = services.BuildServiceProvider();
            calc = provider.GetRequiredService<IAspectCalculator>();
        }

        [Test]
        public void Test1()
        {
            var date = new DateTime(2021, 02, 19).AddHours(-3);
            // var coordinates = InterestingCoordinates.Moscow;
            var parameters = new CalculationParameters(date);
            var actual = calc.FindLunarAspects(parameters);
            var expected = new List<LunarAspect>
            {
                new LunarAspect(new DateTime(2021, 02, 19, 02, 21, 00).AddHours(-3), AstroObject.Venus, AspectType.Square, Zodiac.Taurus, Zodiac.Aquarius, new DMS(22, 0, 0)),
                new LunarAspect(new DateTime(2021, 02, 19, 03, 48, 00).AddHours(-3), AstroObject.Mars, AspectType.Conjunction, Zodiac.Taurus, Zodiac.Taurus, new DMS(23, 0, 0)),
                new LunarAspect(new DateTime(2021, 02, 19, 10, 28, 00).AddHours(-3), AstroObject.Pluto, AspectType.Trine, Zodiac.Taurus, Zodiac.Capricornus, new DMS(26, 0, 0)),
                new LunarAspect(new DateTime(2021, 02, 19, 21, 47, 00).AddHours(-3), AstroObject.Sun, AspectType.Square, Zodiac.Gemini, Zodiac.Pisces, new DMS(02, 0, 0)),
            };

            CompareLunarAspects(actual, expected);
        }

        [Test]
        public void Test2()
        {
            var date = new DateTime(2021, 02, 19).AddHours(-3);
            // var coordinates = InterestingCoordinates.Moscow;
            var parameters = new CalculationParameters(date);
            var actual = calc.FindLunarAspects(parameters, InterestingPlanets.Septener);
            var expected = new List<LunarAspect>
            {
                new LunarAspect(new DateTime(2021, 02, 19, 02, 21, 00).AddHours(-3), AstroObject.Venus, AspectType.Square, Zodiac.Taurus, Zodiac.Aquarius, new DMS(22, 0, 0)),
                new LunarAspect(new DateTime(2021, 02, 19, 03, 48, 00).AddHours(-3), AstroObject.Mars, AspectType.Conjunction, Zodiac.Taurus, Zodiac.Taurus, new DMS(23, 0, 0)),
                new LunarAspect(new DateTime(2021, 02, 19, 21, 47, 00).AddHours(-3), AstroObject.Sun, AspectType.Square, Zodiac.Gemini, Zodiac.Pisces, new DMS(02, 0, 0)),
            };

            CompareLunarAspects(actual, expected);
        }

        [Test]
        public void Test3()
        {
            var date = new DateTime(2020, 05, 13).AddHours(-3);
            // var coordinates = InterestingCoordinates.Moscow;
            var parameters = new CalculationParameters(date);
            var actual = calc.FindLunarAspects(parameters);
            var expected = new List<LunarAspect>
            {
                new LunarAspect(new DateTime(2020, 05, 13, 08, 51, 00).AddHours(-3), AstroObject.Uranus, AspectType.Square, Zodiac.Aquarius, Zodiac.Taurus, new DMS(08, 0, 0)),
            };

            CompareLunarAspects(actual, expected);
        }

        [Test]
        public void Test4()
        {
            var date = new DateTime(2020, 01, 13).AddHours(-3);
            // var coordinates = InterestingCoordinates.Moscow;
            var parameters = new CalculationParameters(date);
            var actual = calc.FindLunarAspects(parameters);
            var expected = new List<LunarAspect>
            {
                new LunarAspect(new DateTime(2020, 01, 13, 16, 41, 00).AddHours(-3), AstroObject.Venus, AspectType.Opposition, Zodiac.Leo, Zodiac.Aquarius, new DMS(30, 0, 0)),
                new LunarAspect(new DateTime(2020, 01, 13, 21, 29, 00).AddHours(-3), AstroObject.Uranus, AspectType.Trine, Zodiac.Virgo, Zodiac.Taurus, new DMS(3, 0, 0)),
            };

            CompareLunarAspects(actual, expected);
        }

        [Test]
        public void Test5()
        {
            var date = new DateTime(2020, 01, 13).AddHours(-3);
            // var coordinates = InterestingCoordinates.Moscow;
            var parameters = new CalculationParameters(date);
            var actual = calc.FindLunarAspects(parameters, InterestingPlanets.Septener);
            var expected = new List<LunarAspect>
            {
                new LunarAspect(new DateTime(2020, 01, 13, 16, 41, 00).AddHours(-3), AstroObject.Venus, AspectType.Opposition, Zodiac.Leo, Zodiac.Aquarius, new DMS(30, 0, 0)),
            };

            CompareLunarAspects(actual, expected);
        }

        private void CompareLunarAspects(List<LunarAspect> actual, List<LunarAspect> expected)
        {
            Assert.Multiple(() =>
            {
                Assert.That(actual, Has.Count.EqualTo(expected.Count));
                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.That(actual[i].AstroObject, Is.EqualTo(expected[i].AstroObject));
                    Assert.That(actual[i].Type, Is.EqualTo(expected[i].Type));
                    Assert.That(actual[i].ExactTime, Is.EqualTo(expected[i].ExactTime).Within(TimeSpan.FromMinutes(1)));
                    Assert.That(actual[i].MoonInZodiac, Is.EqualTo(expected[i].MoonInZodiac));
                    Assert.That(actual[i].PlanetInZodiac, Is.EqualTo(expected[i].PlanetInZodiac));
                    Assert.That((actual[i].MoonPosition.RoundToDegrees() - 1) % 30 + 1, Is.EqualTo(expected[i].MoonPosition.Degrees));
                }
            });
        }
    }
}
