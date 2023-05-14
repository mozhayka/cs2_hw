namespace FootballTeams
{
    internal class Stadium
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Team> Teams { get; set; } = new List<Team>();
    }
}
