// See https://aka.ms/new-console-template for more information
using System.Configuration;
using FootballTeams;

DBHelper db = new(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
// db.AddTeam(SomeTeams.Team1);
// db.AddStadium(SomeStadiums.Stadium1);
// Console.WriteLine(db.GetTeamId(SomeTeams.Team1));
// db.AddPlayer(SomePlayers.Player1);
db.DeletePlayer(SomePlayers.Player1.FirstName);