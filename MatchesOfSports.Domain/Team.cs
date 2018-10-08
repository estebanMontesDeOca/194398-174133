using System;

namespace MatchesOfSports.Domain
{
    public class Team
    {
        public Guid   TeamId {get;set;}
        public  string Name{get; set;}
        public string PhotoUrl{get;set;}

        
        public Team(){
            Name="noName";
            PhotoUrl="noPhoto";
        }
        public Team(string aName, string aUrl)
        {
            Name = aName;
            PhotoUrl = aUrl;
        }
    }
}
