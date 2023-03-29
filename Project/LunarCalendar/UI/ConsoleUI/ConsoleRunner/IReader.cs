using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects;

namespace ConsoleUI.ConsoleRunner
{
    internal interface IReader
    {
        public DateTime ReadDate();
        public Coordinates ReadCoordinates();
    }
}
