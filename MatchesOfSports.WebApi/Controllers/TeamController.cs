using System;
using Microsoft.AspNetCore.Mvc;
using MatchesOfSports.BusinessLogic.Services;
using MatchesOfSports.WebApi.Models;

namespace MatchesOfSports.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        private ITeamService teams;

        public TeamController(ITeamService teams) : base()
        {
            this.teams = teams;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(TeamModel.ToModel(teams.GetAll()));
        }

        [HttpGet("{id}", Name = "GetTeam")]
        public IActionResult Get(Guid id)
        {
            var team = teams.Get(id);
            if (team == null) 
            {
                return NotFound();
            }
            return Ok(TeamModel.ToModel(team));
        }

        protected override void Dispose(bool disposing) 
        {
            try {
                base.Dispose(disposing);
            } finally {
                exercises.Dispose();
            }
        }
    }
}