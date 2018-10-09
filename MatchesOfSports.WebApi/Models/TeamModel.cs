using System;
using System.Collections.Generic;
using System.Linq;
using MatchesOfSports.Domain;

namespace MatchesOfSports.WebApi.Models
{
    public class TeamModel : Model<Team, TeamModel>
    {
        public Guid TeamId { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }

        public TeamModel(Team entity)
        {
            SetModel(entity);
        }

        public override Team ToEntity() => new Team()
        {
            TeamId = this.TeamId,
            Name = this.Name,
            PhotoUrl = this.PhotoUrl,
        };

        protected override TeamModel SetModel(Team entity)
        {
            TeamId = entity.TeamId;
            Name = entity.Name;
            PhotoUrl = entity.PhotoUrl;
            return this;
        }

    }
}