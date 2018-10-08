using System;
using System.Collections.Generic;

namespace MatchesOfSports.Domain
{
    public class Sport
    {
        public Guid SportId{get;set;}
        public string Name{get; set;}  
        public List<Team> ListOfTeams{get;set;}
        public List<Match> ListOfMatches { get; set; }

        
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
