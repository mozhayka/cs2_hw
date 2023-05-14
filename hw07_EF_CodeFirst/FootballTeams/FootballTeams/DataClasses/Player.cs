namespace FootballTeams
{
    internal class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int NumberOfGoals { get; set; } = 0;        
        
        public Address Address { get; set; }

        public int? TeamId { get; set; }
        public Team Team { get; set; }
    }
}
