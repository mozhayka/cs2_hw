// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using FootballTeams;
using FootballTeams.DB;

DBHelper db = new();

db.AddPlayer(SomePlayers.Player1);
db.AddPlayer(SomePlayers.Player2);

db.AddTeam(SomeTeams.Team1);
db.AddTeam(SomeTeams.Team2);
db.AddTeam(SomeTeams.Team3);

db.AddStadium(SomeStadiums.Stadium1);
db.AddStadium(SomeStadiums.Stadium2);

db.AddPlayer_Team(SomePlayers.Player1, SomeTeams.Team1);
db.AddPlayer_Team(SomePlayers.Player2, SomeTeams.Team1);

db.PrintAllTeams();
db.PrintTeamStats(db.GetTeam(SomeTeams.Team1.Name));

db.AddTeam_Stadium(SomeTeams.Team1, SomeStadiums.Stadium1);
db.DeletePlayer(SomePlayers.Player1);
db.ScoreGoal(SomePlayers.Player2);

db.PrintAllTeams();
db.PrintTeamStats(SomeTeams.Team1);
