using Calculator;
using Objects;

namespace LunarCalendarVM
{
    public class LunarCalendar : ILunarCalendar
    {
        public DateTime Date { get; set; }
        public Coordinates Coordinates { get; set; } = new();
        private readonly IDayInformationCalculator Calculator;

        public LunarCalendar(IDayInformationCalculator calculator)
        {
            Calculator = calculator;
        }

        public DayInformation GetDayInformation()
        {
            if (IsSavedInDB())
            {
                return LoadFromDB();
            }
            var parameters = new CalculationParameters(TimeCalculator.GetJulDay(Date), TimeCalculator.GetJulDay(Date.AddDays(1)), Coordinates);
            var dayInfo = Calculator.Calculate(parameters);
            SaveToDB(dayInfo);
            return dayInfo;
        }

        private bool IsSavedInDB()
        {
            return false;
        }

        private DayInformation LoadFromDB()
        {
            throw new NotImplementedException();
        }

        private void SaveToDB(DayInformation dayInformation)
        {
            // TODO implement DB
        }
    }
}
