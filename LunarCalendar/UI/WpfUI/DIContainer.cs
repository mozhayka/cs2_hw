using Calculator;
using Calculator.Helper;
using LunarCalendarVM;
using Microsoft.Extensions.DependencyInjection;

namespace WpfUI
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
            BindVM();
        }

        private void BindCalculator()
        {
            services.AddTransient<IPlanetPositionCalculator, PlanetPositionCalculator>();

            services.AddTransient<IAspectCalculator, AspectCalculator>();
            services.AddTransient<ILunarPositionCalculator, LunarPositionCalculator>();

            services.AddTransient<ILBKCalculator, LBKCalculator>();

            services.AddTransient<IDayInformationCalculator, DayInformationCalculator>();
        }

        private void BindVM()
        {
            services.AddScoped<ILunarCalendar, LunarCalendar>();
        }
    }
}
