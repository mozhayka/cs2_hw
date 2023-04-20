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

namespace TestProject.Tests_Calculator
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
        public void Test1()
        {
            var date = new DateTime(2021, 02, 19).AddHours(-3);
            var parameters = new CalculationParameters(date);

            var actual = calc.FindAllLBK(parameters, false);
            var expected = new List<LBK>
            {
                new LBK(new DateTime(2021, 02, 19, 10, 28, 00).AddHours(-3), new DateTime(2021, 02, 19, 19, 03, 00).AddHours(-3)),
            };

            CompareLBK(actual, expected);
        }

        [Test]
        public void Test2()
        {
            var date = new DateTime(2021, 02, 19).AddHours(-3);
            var parameters = new CalculationParameters(date);

            var actual = calc.FindAllLBK(parameters, true);
            var expected = new List<LBK>
            {
                new LBK(new DateTime(2021, 02, 19, 03, 48, 00).AddHours(-3), new DateTime(2021, 02, 19, 19, 03, 00).AddHours(-3)),
            };

            CompareLBK(actual, expected);
        }

        [Test]
        public void Test3()
        {
            var date = new DateTime(2020, 05, 13).AddHours(-3);
            var parameters = new CalculationParameters(date);

            var actual = calc.FindAllLBK(parameters, true);
            var expected = new List<LBK>
            {
            };

            CompareLBK(actual, expected);
        }

        [Test]
        public void Test4()
        {
            var date = new DateTime(2020, 01, 13).AddHours(-3);
            var parameters = new CalculationParameters(date);

            var actual = calc.FindAllLBK(parameters, true);
            var expected = new List<LBK>
            {
                new LBK(new DateTime(2020, 01, 13, 16, 42, 00).AddHours(-3), new DateTime(2020, 01, 13, 17, 06, 00).AddHours(-3)),
            };

            CompareLBK(actual, expected);
        }

        [Test]
        public void Test5()
        {
            var date = new DateTime(2020, 01, 13).AddHours(-3);
            var parameters = new CalculationParameters(date);

            var actual = calc.FindAllLBK(parameters, false);
            var expected = new List<LBK>
            {
                new LBK(new DateTime(2020, 01, 13, 16, 42, 00).AddHours(-3), new DateTime(2020, 01, 13, 17, 06, 00).AddHours(-3)),
            };

            CompareLBK(actual, expected);
        }

        private void CompareLBK(List<LBK> actual, List<LBK> expected)
        {
            Assert.Multiple(() =>
            {
                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.That(actual[i].From, Is.EqualTo(expected[i].From).Within(TimeSpan.FromMinutes(1)));
                    Assert.That(actual[i].To, Is.EqualTo(expected[i].To).Within(TimeSpan.FromMinutes(1)));
                }
            });
        }
    }
}
