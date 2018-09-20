using System;
using System.Collections.Generic;

namespace MatchesOfSports.Domain
{
    public class Sport
    {
        private string Name{get; set;}
        private List<Team> ListOfTeams { get; set; }
        private List<Match> ListOfMatches { get; set; }

        
        public Sport(){
            Name="noName";
            ListOfTeams=new List<Team>();
            ListOfMatches= new List<Match>();
        }
        public Sport(string aName, List<Team> Teams, List<Match> Matches)
        {
            Name = aName;
            ListOfTeams = Teams;
            ListOfMatches = Matches;
        }
    }
}
