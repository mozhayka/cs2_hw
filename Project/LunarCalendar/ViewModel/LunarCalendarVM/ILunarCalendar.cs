using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects;

namespace LunarCalendarVM
{
    internal interface ILunarCalendar
    {
        public void SetDate(DateTime newDate);

        public void SetCoordinates(Coordinates newCoordinates);

        public DayInformation GetDayInformation();
    }
}
