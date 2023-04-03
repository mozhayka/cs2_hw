using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;
using Calculator.Helper;
using LunarCalendarVM;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleUI.ConsoleRunner
{
    internal class DIContainer
    {
        public IServiceCollection Container { get; set; }

        public DIContainer(IServiceCollection services)
        {
            Container = services;
        }

        public DIContainer()
            : this(new ServiceCollection())
        { }

        public void CompositionRoot()
        {
            Container.AddSingleton<IPlanetPositionCalculator, PlanetPositionCalculator>();

            // Container сам видит, что для сервиса IPlanetPositionCalculator зарегистрирована реализация PlanetPositionCalculator,
            // поэтому при создании объекта AspectsCalculator неявно создает объект PlanetPositionCalculator
            // и передает его в конструктор AspectsCalculator
            Container.AddTransient<IAspectCalculator, AspectsCalculator>();
            Container.AddTransient<ILBKCalculator, LBKCalculator>();

            Container.AddTransient<IDayInformationCalculator, DayInformationCalculator>();

            Container.AddScoped<ILunarCalendar, LunarCalendar>();
        }
    }
}
