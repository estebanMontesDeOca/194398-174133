using System;
using System.Collections.Generic;
using System.Linq;
using MatchesOfSports.Domain;

namespace MatchesOfSports.WebApi.Models
{
    public class SportModel : Model<Sport, SportModel>
    { 
        public Guid SportId{get;set;}
        public string Name{get; set;}
        public List<Team> ListOfTeams{get;set;}

        public SportModel(){}

        public SportModel(Sport entity)
        {
            SetModel(entity);
        }

        public override Sport ToEntity() => new Sport()
        {
            SportId = this.SportId,
            Name = this.Name, 
            ListOfTeams=this.ListOfTeams,
        };

        protected override SportModel SetModel(Sport entity)
        {
            SportId = entity.SportId;
            Name = entity.Name; 
            ListOfTeams=entity.ListOfTeams;
            return this;
        }

    }
}