using System;
using System.Collections.Generic;

namespace MatchesOfSports.Domain
{
    public class Team
    {
        public Guid   TeamId {get;set;}
        public  string Name{get; set;}
        public string PhotoUrl{get;set;}
        public Sport Sport {get;set;}        
        public List<Match> ListOfMatches { get; set; }
        public bool WasDeleted{get;set;}

        
        public Team(){
            Name="noName";
            PhotoUrl="noPhoto";
            Sport = new Sport();
            ListOfMatches= new List<Match>();
            WasDeleted=true;
        }
    }
}
