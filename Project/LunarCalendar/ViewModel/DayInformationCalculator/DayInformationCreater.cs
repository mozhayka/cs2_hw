namespace DayInformationCalculator
{
    public class DayInformationCreater
    {
        public DateTime Date { get; set; }
        public string? Coordinates { get; set; }

        public DayInformationCreater(DateTime date, string coordinates)
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
