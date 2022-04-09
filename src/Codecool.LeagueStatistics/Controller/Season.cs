using System;
using System.Collections.Generic;
using Codecool.LeagueStatistics.Factory;
using Codecool.LeagueStatistics.Model;
using Codecool.LeagueStatistics.View;
using Codecool.LeagueStatistics;

namespace Codecool.LeagueStatistics.Controllers
{
    /// <summary>
    ///     Provides all necessary methods for season simulation
    /// </summary>
    public class Season
    {
        public List<Team> League { get; set; }

        public Season()
        {
            League = new List<Team>();
        }

        /// <summary>
        ///     Fills league with new teams and simulates all games in season.
        /// After all games played calls table to be displayed.
        /// </summary>
        public void Run()
        {
            var league = LeagueFactory.CreateLeague(6);
            foreach (var team in league)
            {
                League.Add(team);
            }
            PlayAllGames();

            // Call Display methods here
        }
        /// <summary>
        ///     Playing one round. Everyone with everyone one time. 
        /// </summary>
        public void PlayAllGames()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        ///     Plays single game between two teams and displays result after.
        /// </summary>
        public void PlayMatch(Team team1, Team team2)
        {
            int team1Score = ScoredGoals(team1);
            int team2Score = ScoredGoals(team2);
            if (team1Score > team2Score)
            {
                team1.Wins++;
                team2.Losts++;
            }
            else if (team1Score < team2Score)
            {
                team1.Losts++;
                team2.Wins++;
            }
            else
            {
                team1.Draws++;
                team2.Draws++;
            }
            Display.DisplayMatchResult(team1.Name, team1Score, team2.Name, team2Score);
        }

        /// <summary>
        ///     Checks for each player of given team chanse to score based on skillrate.
        ///     Adds scored golas to player's and team's statistics.
        /// </summary>
        /// <param name="team">team</param>
        /// <returns>All goals scored by the team in current game</returns>
        public int ScoredGoals(Team team)
        {
            int score = 0;
            foreach (var player in team.Players)
            {
                if (Utils.Random.Next(1, 101) <= player.SkillRate)
                {
                    score++;
                    player.Goals++;
                }
            }
            return score;
        }
    }
}
