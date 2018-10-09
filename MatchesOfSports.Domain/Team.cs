using System;

namespace MatchesOfSports.Domain
{
    public class Team
    {
        public Guid   TeamId {get;set;}
        public  string Name{get; set;}
        public string PhotoUrl{get;set;}
        public bool WasDeleted{get;set;}

        
        public Team(){
            Name="noName";
            PhotoUrl="noPhoto";
            WasDeleted=true;
        }
        public Team(string aName, string aUrl,bool wasDeleted)
        {
            Name = aName;
            PhotoUrl = aUrl;
            WasDeleted = wasDeleted;
        }
    }
}
