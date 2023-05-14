namespace FootballTeams
{
    internal class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public int EstYear { get; set; }

        public ICollection<Player> Players { get; set; } = new List<Player>();
        public ICollection<Stadium> Stadiums { get; set; } = new List<Stadium>();
        public Stats Stats { get; set; } = new();
    }
}
