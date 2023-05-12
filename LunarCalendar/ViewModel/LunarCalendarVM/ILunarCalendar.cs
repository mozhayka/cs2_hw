using Objects;

namespace LunarCalendarVM
{
    public interface ILunarCalendar
    {
        public DateTime Date { get; set; }
        public Coordinates Coordinates { get; set; }

        public DayInformation GetDayInformation();
    }
}
