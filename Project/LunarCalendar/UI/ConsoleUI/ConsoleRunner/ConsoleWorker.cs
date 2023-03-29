using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects;

namespace ConsoleUI.ConsoleRunner
{
    // Interface Segregation Principle - разделили интерфейс работы с консолью на IPrinter и IReader
    internal class ConsoleWorker : IPrinter, IReader
    {
        public void Greetings()
        {
            Console.WriteLine("Start Lunar Calendar");
        }

        public void Print(DayInformation info)
        {
            Console.WriteLine("Printing day info");
            throw new NotImplementedException();
        }

        public DateTime ReadDate()
        {
            Console.WriteLine("Write date: ");
            var date = Console.ReadLine();
            if (date == null)
                return DateTime.Today;

            return StringToDate(date);
        }

        public Coordinates ReadCoordinates()
        {
            Console.WriteLine("Write coordinates: ");
            var date = Console.ReadLine();
            if (date == null)
                return new Coordinates();

            return StringToCoordinates(date);
        }

        private static DateTime StringToDate(string s)
        {
            throw new NotImplementedException();
        }

        private static Coordinates StringToCoordinates(string s)
        {
            throw new NotImplementedException();
        }
    }
}
