using System.Data.Entity;

namespace FootballTeams
{
    internal class FootballContext : DbContext
    {
        public FootballContext() : base("name=DefaultConnection")
        { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Stats> Statistics { get; set; }

        public DbSet<Stadium> Stadiums { get; set; }
    }
}
