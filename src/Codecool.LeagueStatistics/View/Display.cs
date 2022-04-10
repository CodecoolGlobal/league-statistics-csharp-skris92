using Codecool.LeagueStatistics.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codecool.LeagueStatistics.View
{
    using static Codecool.LeagueStatistics.Model.LeagueStatistics;
    /// <summary>
    /// Provides console view for league table, results and all League statistics
    /// </summary>
    public static class Display
    {
        public static void DisplayMatchResult(string team1Name, int score1, string team2Name, int score2)
        {
            Console.WriteLine($"{team1Name}: {score1} -- {team2Name}: {score2}");
        }

        public static void DisplayFinalResult(IEnumerable<Team> teams)
        {
            teams = teams.GetAllTeamsSorted();
            var longestNamedTeam = teams.GetTeamWithTheLongestName();
            var maxNameLength = longestNamedTeam.Name.Length;
            var cellLength = 6;

            var headers = $"|Name{new string(' ', maxNameLength - 4)}|Points| Goals|  Wins| Draws|Losses|";
            var separator = $"+{new string('-', maxNameLength)}+------+------+------+------+------+";

            Console.WriteLine(separator);
            Console.WriteLine(headers);
            foreach (var team in teams)
            {
                var goals = team.Players.Sum(player => player.Goals);

                var nameLength = team.Name.Length;
                var pointsLength = team.CurrentPoints.ToString().Length;
                var goalsLength = goals.ToString().Length;
                var winsLength = team.Wins.ToString().Length;
                var drawsLength = team.Draws.ToString().Length;
                var lossesLength = team.Losts.ToString().Length;

                var nameCell = $"{team.Name}{new string(' ', maxNameLength - nameLength)}";
                var pointsCell = $"{new string(' ', cellLength - pointsLength)}{team.CurrentPoints}";
                var goalsCell = $"{new string(' ', cellLength - goalsLength)}{goals}";
                var winsCell = $"{new string(' ', cellLength - winsLength)}{team.Wins}";
                var drawsCell = $"{new string(' ', cellLength - drawsLength)}{team.Draws}";
                var lossesCell = $"{new string(' ', cellLength - lossesLength)}{team.Losts}";

                Console.WriteLine(separator);
                Console.WriteLine($"|{nameCell}|{pointsCell}|{goalsCell}|{winsCell}|{drawsCell}|{lossesCell}|");
            }
            Console.WriteLine(separator);
        }
    }
}
