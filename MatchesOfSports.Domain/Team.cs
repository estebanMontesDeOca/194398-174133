using System;

namespace MatchesOfSports.Domain
{
    public class Team
    {
        public Guid   TeamId {get;set;}
        public  string Name{get; set;}
        public string PhotoUrl{get;set;}
        public List<Sport> LisOfSports{get;set;}        
        public List<Team> ListOfTeams{get;set;}
        public List<Match> ListOfMatches { get; set; }
        public bool WasDeleted{get;set;}

        
        public Team(){
            Name="noName";
            PhotoUrl="noPhoto";            
            ListOfSports= new List<Sport>();
            ListOfTeams=new List<Team>();
            ListOfMatches= new List<Match>();
            WasDeleted=true;
        }
    }
}
