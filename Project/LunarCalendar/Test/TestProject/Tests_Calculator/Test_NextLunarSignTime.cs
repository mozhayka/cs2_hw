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
    internal class Test_NextLunarSignTime
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
        public void Test1()
        {
            var date = new DateTime(2021, 02, 19).AddHours(-3);
            var jd = TimeCalculator.GetJulDay(date);

            var actual = TimeCalculator.FromJulDay(calc.NextLunarSignTime(jd));
            var expected = new DateTime(2021, 02, 19, 19, 03, 00).AddHours(-3);

            Assert.That(actual, Is.EqualTo(expected).Within(TimeSpan.FromMinutes(1)));
        }
    }
}
