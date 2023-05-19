using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfUI
{
    public class ExampleItem
    {
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int UTC { get; set; }

        public ExampleItem(DateTime date, int utc = 3) 
        {
            UTC = utc;
            Text = $"{date:D}, {date:ddd}";
            Date = date;
        }
    }
}
