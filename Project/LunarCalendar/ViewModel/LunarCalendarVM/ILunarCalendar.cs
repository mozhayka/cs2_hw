using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
