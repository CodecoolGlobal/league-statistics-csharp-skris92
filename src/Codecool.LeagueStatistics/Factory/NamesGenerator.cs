using System.IO;

namespace Codecool.LeagueStatistics.Facotry
{
    /// <summary>
    ///     Provides random names for Players and Teams
    /// </summary>
    public static class NamesGenerator
    {
        public static string GetPlayerName()
        {
            return File.ReadAllLines("C:\\Users\\Admin\\source\\repos\\league-statistics-csharp-skris92\\data\\PlayerNames.txt").GetRandomValue();
        }

        public static string GetTeamName()
        {
            var cities = File.ReadAllLines("C:\\Users\\Admin\\source\\repos\\league-statistics-csharp-skris92\\data\\CityNames.txt");
            var names = File.ReadAllLines("C:\\Users\\Admin\\source\\repos\\league-statistics-csharp-skris92\\data\\TeamNames.txt");

            return cities.GetRandomValue() + " " + names.GetRandomValue();
        }
    }
}
