using System;
using System.Collections.Generic;

namespace MatchesOfSports.Domain
{
    public class Sport
    {
        public Guid SportId{get;set;}
        public string Name{get; set;}
        public List<Team> ListOfTeams{get;set;}
 public bool WasDeleted {get;set;}

        
        public Sport(){
            Name="noName";
            ListOfTeams=new List<Team>();
            WasDeleted = false;
        }
        public Sport(string aName,bool wasDeleted,List<Team> ListOfTeams)
        {
            this.Name = aName;
            this.WasDeleted = wasDeleted;
            this.ListOfTeams=ListOfTeams;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Sport sport = obj as Sport;
            if (sport == null)
            {
                return false;
            }
            return this.SportId.Equals(sport.SportId);
        }

        public override int GetHashCode()
        {
            return this.SportId.GetHashCode();
        }

        
    }
}
