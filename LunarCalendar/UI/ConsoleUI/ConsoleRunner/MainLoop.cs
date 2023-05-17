using ConsoleUI.ConsoleRunner;
using LunarCalendarVM;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleUI
{
    internal class MainLoop
    {
        public static void Start()
        {
            var di = new DIContainer();
            var consoleWriter = di.ServiceProvider.GetRequiredService<IWriter>();
            var consoleReader = di.ServiceProvider.GetRequiredService<IReader>();
            var lc = di.ServiceProvider.GetRequiredService<ILunarCalendar>();

            consoleWriter.Greetings();
            var date = consoleReader.ReadDate();

            consoleWriter.Print(lc.GetDayInformation(date));
        }
    }
}
