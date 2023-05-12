using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeams
{
    internal class Player
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public class Address
        {
            public string Country { get; set; }
            public string City { get; set; }
            public string Street { get; set; }
            public int Building { get; set; }
            public int Apartment { get; set; }
        }

        public Address Addr { get; set; }
        public Team Team { get; set; }
        public int NumberOfGoals { get; set; } = 0;
    }

    static class SomePlayers
    {
        public static Player Player1 = new()
        {
            FirstName = "fst_fn",
            SecondName = "fst_sn",
            Addr = new()
            {
                Country = "Ru",
                City = "SPb",
                Street = "s1",
                Building = 3,
                Apartment = 4,
            },
            Team = SomeTeams.Team1,
            NumberOfGoals = 0
        };
    }
}
