using Objects;

namespace DayInformation
{
    public class DayInformationCalculator
    {
        public DateTime Date { get; set; }
        public string? Coordinates { get; set; }

        public DayInformationCalculator(DateTime date, string coordinates)
        {
            Date = date;
            Coordinates = coordinates;
        }

        public Objects.DayInformation Calculate()
        {
            Console.WriteLine("Calculating day information");
            var info = new Objects.DayInformation();
            return info;
        }
    }
}
