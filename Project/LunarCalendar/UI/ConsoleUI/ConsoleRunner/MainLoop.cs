using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunarCalendarVM;

namespace ConsoleUI
{
    internal class MainLoop
    {
        public static void Start()
        {
            Console.WriteLine("Start Lunar Calendar");
            var date = ConsoleReader.ReadDate();
            var coordinates = ConsoleReader.ReadCoordinates();

            var lc = new LunarCalendar(date, coordinates);
            DayInformationPrinter.Print(lc.GetDayInformation());
        }
    }
}
