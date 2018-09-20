using System;

namespace MatchesOfSports.Domain
{
    public class Team
    {
        private string name{get; set;}
        private string photoUrl{get;set;}

        
        public Team(){
            name="noName";
            photoUrl="noPhoto";
        }
        public Team(string aName, string aUrl)
        {
            name = aName;
            photoUrl = aUrl;
        }
    }
}
