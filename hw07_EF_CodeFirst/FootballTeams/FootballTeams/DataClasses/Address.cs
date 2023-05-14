using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballTeams
{
    internal class Address
    {
        [Key]
        [ForeignKey("Player")]
        public int Id { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Building { get; set; }
        public int Apartment { get; set; }

        public Player Player { get; set; }
    }
}
