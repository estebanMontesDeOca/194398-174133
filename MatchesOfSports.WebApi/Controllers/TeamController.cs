using System;
using Microsoft.AspNetCore.Mvc;
using MatchesOfSports.BusinessLogic.Services;
using MatchesOfSports.WebApi.Models;
using MatchesOfSports.Domain;
using MatchesOfSports.WebApi.Filters;

namespace MatchesOfSports.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        private ITeamService teamService;

        public TeamController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(TeamModel.ToModel(teamService.GetAllTeams()));
        }

        [HttpGet("{id}", Name = "GetTeam")]
        public IActionResult Get(Guid id)
        {
            var team = teamService.GetTeamById(id);
            if (team == null) 
            {
                return NotFound();
            }
            return Ok(TeamModel.ToModel(team));
        }

        [ProtectFilter("Admin")]
        [HttpPost]
        public IActionResult Post([FromBody]Team model)
        {
            try {
                var team = teamService.Create(model);
                return CreatedAtRoute("Get", model);
            } catch(ArgumentException e) {
                return BadRequest(e.Message);
            }
        }
      
/* 
private bool disposedValue = false;
     protected override void Dispose(bool disposing) 
        {
            if (!disposedValue)
            {S
                if (disposing)
                {
                    teamService.Dispose();
                }
                disposedValue = true;
            }
        }
         public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        } 
        */
    }
}