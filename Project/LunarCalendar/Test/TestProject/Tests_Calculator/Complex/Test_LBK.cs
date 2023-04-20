using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;
using Calculator.Helper;
using LunarCalendarVM;
using Microsoft.Extensions.DependencyInjection;
using Objects;

namespace TestProject.Tests_Calculator.Complex
{
    internal class Test_LBK
    {
        ILBKCalculator calc;

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
            calc = provider.GetRequiredService<ILBKCalculator>();
        }

        [Test]
        public void Test_2020_01_13_septener()
        {
            var date = new DateTime(2020, 01, 13).AddHours(-3);
            var parameters = new CalculationParameters(date);

            var actual = calc.FindAllLBK(parameters, true);
            var expected = Answers.Answers_LBK.lbk_2020_01_13_septener;

            Answers.Answers_LBK.CompareLBK(actual, expected);
        }

        [Test]
        public void Test_2020_01_13_all()
        {
            var date = new DateTime(2020, 01, 13).AddHours(-3);
            var parameters = new CalculationParameters(date);

            var actual = calc.FindAllLBK(parameters, false);
            var expected = Answers.Answers_LBK.lbk_2020_01_13_all;

            Answers.Answers_LBK.CompareLBK(actual, expected);
        }


        [Test]
        public void Test_2020_05_13_septener()
        {
            var date = new DateTime(2020, 05, 13).AddHours(-3);
            var parameters = new CalculationParameters(date);

            var actual = calc.FindAllLBK(parameters, true);
            var expected = Answers.Answers_LBK.lbk_2020_05_13_septener;

            Answers.Answers_LBK.CompareLBK(actual, expected);
        }

        [Test]
        public void Test_2020_05_13_all()
        {
            var date = new DateTime(2020, 05, 13).AddHours(-3);
            var parameters = new CalculationParameters(date);

            var actual = calc.FindAllLBK(parameters, false);
            var expected = Answers.Answers_LBK.lbk_2020_05_13_all;

            Answers.Answers_LBK.CompareLBK(actual, expected);
        }


        [Test]
        public void Test_2021_02_19_septener()
        {
            var date = new DateTime(2021, 02, 19).AddHours(-3);
            var parameters = new CalculationParameters(date);

            var actual = calc.FindAllLBK(parameters, true);
            var expected = Answers.Answers_LBK.lbk_2021_02_19_septener;

            Answers.Answers_LBK.CompareLBK(actual, expected);
        }

        [Test]
        public void Test_2021_02_19_all()
        {
            var date = new DateTime(2021, 02, 19).AddHours(-3);
            var parameters = new CalculationParameters(date);

            var actual = calc.FindAllLBK(parameters, false);
            var expected = Answers.Answers_LBK.lbk_2021_02_19_all;

            Answers.Answers_LBK.CompareLBK(actual, expected);
        }
    }
}
