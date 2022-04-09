using Codecool.LeagueStatistics.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codecool.LeagueStatistics.View
{
    /// <summary>
    /// Provides console view for league table, results and all League statistics
    /// </summary>
    public static class Display
    {
        public static void DisplayMatchResult(string team1Name, int score1, string team2Name, int score2)
        {
            Console.WriteLine($"{team1Name}: {score1} -- {team2Name}: {score2}");
        }
    }
}
