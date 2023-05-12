using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Helper;
using Calculator;
using Microsoft.Extensions.DependencyInjection;
using Objects;

namespace TestProject.Tests_Calculator.Complex
{
    internal class Test_LunarInformation
    {
        ILunarPositionCalculator calc;

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
            calc = provider.GetRequiredService<ILunarPositionCalculator>();
        }

        [Test]
        public void Test_2020_01_13()
        {
            var date = new DateTime(2020, 01, 13).AddHours(-3);
            var parameters = new CalculationParameters(date);


            var actual = calc.LunarInformation(parameters);
            var expected = Answers.Answers_LunarInformation._2020_01_13;

            Answers.Answers_LunarInformation.CompareLunarInformation(actual, expected);
        }

        [Test]
        public void Test_2020_05_13()
        {
            var date = new DateTime(2020, 05, 13).AddHours(-3);
            var parameters = new CalculationParameters(date);


            var actual = calc.LunarInformation(parameters);
            var expected = Answers.Answers_LunarInformation._2020_05_13;

            Answers.Answers_LunarInformation.CompareLunarInformation(actual, expected);
        }

        [Test]
        public void Test_2021_02_19()
        {
            var date = new DateTime(2021, 02, 19).AddHours(-3);
            var parameters = new CalculationParameters(date);


            var actual = calc.LunarInformation(parameters);
            var expected = Answers.Answers_LunarInformation._2021_02_19;

            Answers.Answers_LunarInformation.CompareLunarInformation(actual, expected);
        }
    }
}
