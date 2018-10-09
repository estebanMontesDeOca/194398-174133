using System;
using System.Collections.Generic;

namespace MatchesOfSports.Domain
{
    public class Sport
    {
        public Guid SportId{get;set;}
        public string Name{get; set;}  
        public bool WasDeleted {get;set;}

        
        public Sport(){
            Name="noName";
            WasDeleted = false;
        }
        public Sport(string aName,bool wasDeleted)
        {
            Name = aName;
            ListOfTeams = Teams;
        }

        
    }
}
