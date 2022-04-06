using Codecool.LeagueStatistics.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codecool.LeagueStatistics.Factory
{
    /// <summary>
    /// Provides full set of teams with players
    /// </summary>
    public static class LeagueFactory
    {
        /// <summary>
        ///     For each division, creates given amount of teams. Each team gets a newly created collection of players.
        ///     The amount of players should be taken from Utils.TeamSize
        /// </summary>
        /// <param name="teamsInDivision">Indicates number of teams are in division</param>
        /// <returns>Full set of teams with players</returns>
        public static IEnumerable<Team> CreateLeague(int teamsInDivision)
        {
            var teams = new List<Team>();
            var enumValues = Enum.GetValues(typeof(Division));
            foreach(Division division in enumValues)
            {
                for(int i = 0; i < teamsInDivision; i++)
                {
                    IEnumerable<Player> players = GetPlayers(Utils.TeamSize);
                    teams.Add(new Team(division, players));
                }
            }
            return teams;
        }

        /// <summary>
        ///     Returns a collection with a given amount of newly created players
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        private static IEnumerable<Player> GetPlayers(int amount)
        {
            List<Player> players = new List<Player>();
            for (int i = 0; i < amount; i++) players.Add(new Player(PlayerSkillRate));
            return players;
        }

        private static int PlayerSkillRate => Utils.Random.Next(5, 21);
    }
}
