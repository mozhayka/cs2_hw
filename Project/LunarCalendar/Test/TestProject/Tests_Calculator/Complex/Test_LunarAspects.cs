using Calculator;
using Calculator.Helper;
using LunarCalendarVM;
using Microsoft.Extensions.DependencyInjection;
using Objects;

namespace TestProject.Tests_Calculator.Complex
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
        public void Test_2020_01_13_septener()
        {
            var date = new DateTime(2020, 01, 13).AddHours(-3);
            var parameters = new CalculationParameters(date);

            var actual = calc.FindLunarAspects(parameters, InterestingPlanets.Septener);
            var expected = Answers.Answers_LunarAspects.aspects_2020_01_13_septener;

            Answers.Answers_LunarAspects.CompareLunarAspects(actual, expected);
        }

        [Test]
        public void Test_2020_01_13_all()
        {
            var date = new DateTime(2020, 01, 13).AddHours(-3);
            var parameters = new CalculationParameters(date);

            var actual = calc.FindLunarAspects(parameters);
            var expected = Answers.Answers_LunarAspects.aspects_2020_01_13_all;

            Answers.Answers_LunarAspects.CompareLunarAspects(actual, expected);
        }


        [Test]
        public void Test_2020_05_13_septener()
        {
            var date = new DateTime(2020, 05, 13).AddHours(-3);
            var parameters = new CalculationParameters(date);

            var actual = calc.FindLunarAspects(parameters, InterestingPlanets.Septener);
            var expected = Answers.Answers_LunarAspects.aspects_2020_05_13_septener;

            Answers.Answers_LunarAspects.CompareLunarAspects(actual, expected);
        }

        [Test]
        public void Test_2020_05_13_all()
        {
            var date = new DateTime(2020, 05, 13).AddHours(-3);
            var parameters = new CalculationParameters(date);

            var actual = calc.FindLunarAspects(parameters);
            var expected = Answers.Answers_LunarAspects.aspects_2020_05_13_all;

            Answers.Answers_LunarAspects.CompareLunarAspects(actual, expected);
        }


        [Test]
        public void Test_2021_02_19_septener()
        {
            var date = new DateTime(2021, 02, 19).AddHours(-3);
            var parameters = new CalculationParameters(date);

            var actual = calc.FindLunarAspects(parameters, InterestingPlanets.Septener);
            var expected = Answers.Answers_LunarAspects.aspects_2021_02_19_septener;

            Answers.Answers_LunarAspects.CompareLunarAspects(actual, expected);
        }

        [Test]
        public void Test_2021_02_19_all()
        {
            var date = new DateTime(2021, 02, 19).AddHours(-3);
            var parameters = new CalculationParameters(date);

            var actual = calc.FindLunarAspects(parameters);
            var expected = Answers.Answers_LunarAspects.aspects_2021_02_19_all;

            Answers.Answers_LunarAspects.CompareLunarAspects(actual, expected);
        }
    }
}
