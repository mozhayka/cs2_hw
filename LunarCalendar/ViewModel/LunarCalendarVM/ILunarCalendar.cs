using Objects;

namespace LunarCalendarVM
{
    public interface ILunarCalendar
    {
        public DayInformation GetDayInformation(DateTime Date);
        public string GetDayInfoRus(DateTime Date, int UTC);
    }
}
