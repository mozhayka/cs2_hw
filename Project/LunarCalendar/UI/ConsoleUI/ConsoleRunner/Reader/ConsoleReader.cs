using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects;

namespace ConsoleUI
{
    internal class ConsoleReader
    {
        public static DateTime ReadDate()
        {
            Console.WriteLine("Write date: ");
            var date = Console.ReadLine();
            if (date == null)
                return DateTime.Today;

            return StringToDate(date);
        }

        public static Coordinates ReadCoordinates()
        {
            Console.WriteLine("Write coordinates: ");
            var date = Console.ReadLine();
            if (date == null)
                return new Coordinates();

            return StringToCoordinates(date);
        }

        private static DateTime StringToDate(string s)
        {
            return new DateTime(long.Parse(s));
        }

        private static Coordinates StringToCoordinates(string s)
        {
            return new Coordinates();
        }
    }
}
