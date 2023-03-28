using Objects;

namespace LunarCalendarVM
{
    public class LunarCalendar
    {
        public DateTime Date { get; private set; }
        public Coordinates Coordinates { get; private set; }

        public LunarCalendar(DateTime date, Coordinates coordinates)
        {
            Date = date;
            Coordinates = coordinates;
        }

        public DayInformation GetDayInformation()
        {
            throw new NotImplementedException();
        }

        public void ChangeDate(DateTime newDate)
        {
            Date = newDate;
        }

        public void ChangeCoordinates(Coordinates newCoordinates)
        {
            Coordinates = newCoordinates;
        }
    }
}