using System.Globalization;
using System.Text;
using Objects;

namespace ConsoleUI.ConsoleRunner
{
    // Interface Segregation Principle - разделили интерфейс работы с консолью на IPrinter и IReader
    internal class ConsoleWorker : IReader, IWriter
    {
        public static readonly Coordinates SPB_Coordinates = new (
            new DMS(30, 18, 50), // longitude
            new DMS(59, 56, 19), // latitude
            11); // geoalt

        public void Greetings()
        {
            Console.WriteLine("Start Lunar Calendar");
        }

        public void Print(DayInformation info)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{info.DateUTC}");
            sb.AppendLine($"{info.Coordinates}");
            sb.AppendLine(PrintAspects(info.LunarAspects));
            sb.AppendLine(PrintLBK(info.LBK));

            Console.WriteLine(sb.ToString());
        }

        public DateTime ReadDate()
        {
            Console.WriteLine("Write date in format: yyyy-MM-dd\n" +
                "(or press enter for today's date)");
            var date = Console.ReadLine();
            if (date == null || date == "")
                return DateTime.Today;

            return StringToDate(date);
        }

        public Coordinates ReadCoordinates()
        {
            Console.WriteLine("Write coordinates if format: latitude longitude geoalt\n" +
                "(or press enter for SPB's coordinates)");
            var coordinates = Console.ReadLine();
            if (coordinates == null || coordinates == "")
                return SPB_Coordinates;

            return StringToCoordinates(coordinates);
        }

        private static DateTime StringToDate(string s)
        {
            return DateTime.ParseExact(s, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        private static Coordinates StringToCoordinates(string s)
        {
            var args = s.Split(' ');
            var latitude = double.Parse(args[0]);
            var longitude = double.Parse(args[1]);
            var geoalt = double.Parse(args[2]);
            return new Coordinates(latitude, longitude, geoalt);
        }

        private static string PrintAspects(List<LunarAspect> aspects)
        {
            var sb = new StringBuilder();
            foreach (var aspect in aspects)
            {
                sb.AppendLine(PrintAspect(aspect));
            }
            return sb.ToString();
        }

        private static string PrintAspect(LunarAspect aspect)
        {
            return $"{AstroObject.Moon} {aspect.Type} {aspect.AstroObject} {aspect.ExactTime}";
        }

        private static string PrintLBK(List<LBK> lbk)
        {
            return $"LBK not yet implemented";
        }
    }
}
