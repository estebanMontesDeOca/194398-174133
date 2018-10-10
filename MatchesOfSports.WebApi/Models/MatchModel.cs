using System;
using System.Collections.Generic;
using System.Linq;
using MatchesOfSports.Domain;

namespace MatchesOfSports.WebApi.Models
{
    public class MatchModel : Model<Match, MatchModel>
    {
       
        public Guid  MatchId  {get;set;}
        public DateTime DateAndTime {get; set;}
        public Sport TheSport {get;set;}       
        public Guid TeamOne { get; set; }     
        public Guid TeamTwo { get; set; }
        public List<Comment> Comments {get;set;}
        public Sport KindOfSport {get;set;}
        public bool WasDeleted {get;set;}

        public MatchModel(){}
        public MatchModel(Match entity)
        {
            SetModel(entity);
        }

        public override Match ToEntity() => new Match()
        {
            DateAndTime = this.DateAndTime,
            TheSport = this.TheSport,
            TeamOne = this.TeamOne,
            TeamTwo = this.TeamTwo,
            Comments = this.Comments,
            KindOfSport = this.KindOfSport,
            WasDeleted = this.WasDeleted, 
        };

        protected override MatchModel SetModel(Match entity)
        {
             DateAndTime = entity.DateAndTime;
            TheSport = entity.TheSport;
            TeamOne = entity.TeamOne;
            TeamTwo = entity.TeamTwo;
            Comments = entity.Comments;
            KindOfSport = entity.KindOfSport;
            WasDeleted = entity.WasDeleted;
            return this;
        }

    }
}