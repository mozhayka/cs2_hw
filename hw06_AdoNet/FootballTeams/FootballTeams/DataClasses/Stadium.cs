using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeams
{
    internal class Stadium
    {
        public string Name { get; set; }
    }

    static class SomeStadiums
    {
        public static Stadium Stadium1 = new()
        {
            Name = "stadium1"
        };

        public static Stadium Stadium2 = new()
        {
            Name = "stadium2"
        };
    }
}
