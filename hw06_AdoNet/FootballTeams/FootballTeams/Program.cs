// See https://aka.ms/new-console-template for more information
using System.Configuration;
using FootballTeams;

DBHelper db = new(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
db.ClearAll();
db.AddTeam(SomeTeams.Team1);
db.AddStadium(SomeStadiums.Stadium1);
db.AddPlayer(SomePlayers.Player1);
db.AddPlayer(SomePlayers.Player2);
Console.WriteLine(db.GetTeamId(SomeTeams.Team1));

db.PrintTeamPlayers(SomeTeams.Team1);
db.ScoreGoal(SomePlayers.Player1);

db.DeletePlayer(SomePlayers.Player1.FirstName);
