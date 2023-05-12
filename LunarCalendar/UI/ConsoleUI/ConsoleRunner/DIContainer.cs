using Calculator;
using Calculator.Helper;
using LunarCalendarVM;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleUI.ConsoleRunner
{
    internal class DIContainer
    {
        public ServiceProvider ServiceProvider { get; private set; }
        private readonly IServiceCollection services;
        
        public DIContainer(IServiceCollection services)
        {
            this.services = services;
            CompositionRoot();
            ServiceProvider = services.BuildServiceProvider();
        }

        public DIContainer()
            : this(new ServiceCollection())
        { }

        private void CompositionRoot()
        {
            BindCalculator();
            BindConsoleUI();
            BindVM();
        }

        private void BindCalculator()
        {
            services.AddTransient<IPlanetPositionCalculator, PlanetPositionCalculator>();

            // Container сам видит, что для сервиса IPlanetPositionCalculator зарегистрирована реализация PlanetPositionCalculator,
            // поэтому при создании объекта AspectsCalculator неявно создает объект PlanetPositionCalculator
            // и передает его в конструктор AspectsCalculator
            services.AddTransient<IAspectCalculator, AspectCalculator>();
            services.AddTransient<ILunarPositionCalculator, LunarPositionCalculator>();

            services.AddTransient<ILBKCalculator, LBKCalculator>();

            services.AddTransient<IDayInformationCalculator, DayInformationCalculator>();
        }

        private void BindConsoleUI()
        {
            services.AddSingleton<IReader, ConsoleWorker>();
            services.AddSingleton<IWriter, ConsoleWorker>();
        }

        private void BindVM()
        {
            services.AddScoped<ILunarCalendar, LunarCalendar>();
        }
    }
}
