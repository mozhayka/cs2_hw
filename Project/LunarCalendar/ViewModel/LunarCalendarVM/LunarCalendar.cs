using Calculator;
using Objects;

namespace LunarCalendarVM
{
    public class LunarCalendar : ILunarCalendar
    {
        public DateTime Date { get; private set; }
        public Coordinates Coordinates { get; private set; }
        private readonly IDayInformationCalculator Calculator;

        public LunarCalendar(DateTime date, Coordinates coordinates, IDayInformationCalculator calculator)
        {
            Calculator = calculator;
            Date = date;
            Coordinates = coordinates;
        }

        public void SetDate(DateTime newDate)
        {
            Date = newDate;
        }

        public void SetCoordinates(Coordinates newCoordinates)
        {
            Coordinates = newCoordinates;
        }

        public DayInformation GetDayInformation()
        {
            return Calculator.Calculate(Date, Coordinates);
        }
    }
}
