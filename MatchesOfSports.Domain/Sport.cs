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
        public bool WasDeleted {get;set;}

        
        public Sport(){
            Name="noName";
            ListOfTeams=new List<Team>();
            ListOfMatches= new List<Match>();
            WasDeleted = false;
        }
        public Sport(string aName, List<Team> Teams, List<Match> Matches,bool wasDeleted)
        {
            Name = aName;
            ListOfTeams = Teams;
            ListOfMatches = Matches;
            WasDeleted = wasDeleted;
        }
    }
}
