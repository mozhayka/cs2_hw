using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public  class CalculationParameters
    {
        
        public DateTime DateUTC { get; set; }
        public Coordinates? Coordinates { get; set; }

        public CalculationParameters(DateTime date, Coordinates? coordinates = null)
        {
            DateUTC = date;
            Coordinates = coordinates;
        }
    }
}
