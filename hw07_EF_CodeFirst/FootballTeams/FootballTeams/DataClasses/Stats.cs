using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FootballTeams
{
    internal class Stats
    {
        [Key]
        [ForeignKey("Team")]
        public int Id { get; set; }
        public int NumberOfPlayers { get; set; } = 0;
        public int NumberOfStadiums { get; set; } = 0;
        public float AvgGoals { get; set; } = 0;

        public Team Team { get; set; }
    }
}
