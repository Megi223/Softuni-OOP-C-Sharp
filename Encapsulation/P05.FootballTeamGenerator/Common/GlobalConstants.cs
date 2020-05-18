using System;
using System.Collections.Generic;
using System.Text;

namespace P05FootballTeamGenerator.Common
{
    public static class GlobalConstants
    {
        public static string InvalidStatExceptionMessage = "{0} should be between 0 and 100.";
        public static string InvalidNameExceptionMessage = "A name should not be empty.";
        public static string RemovingMissingPlayerExceptionMessage = "Player {0} is not in {1} team.";
        public static string MissingTeamExceptionMessage = "Team {0} does not exist.";
    }
}
