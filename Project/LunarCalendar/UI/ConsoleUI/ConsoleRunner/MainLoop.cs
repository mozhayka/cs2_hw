using ConsoleUI.ConsoleRunner;
using LunarCalendarVM;

namespace ConsoleUI
{
    internal class MainLoop
    {
        public static void Start()
        {
            var console = new ConsoleWorker();
            console.Greetings();
            var date = console.ReadDate();
            var coordinates = console.ReadCoordinates();

            var lc = new LunarCalendar(date, coordinates);
            console.Print(lc.GetDayInformation());
        }
    }
}
