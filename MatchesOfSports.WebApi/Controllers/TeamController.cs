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
        public IActionResult GetAllTeams()
        {
            return Ok(TeamModel.ToModel(teamService.GetAllTeams()));
        }

        [HttpGet("{id}", Name = "GetTeamById")]
        public IActionResult GetTeamById(Guid id)
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
        public IActionResult CreateTeam([FromBody]Team model)
        {
            try {
                var team = teamService.Create(model);
                return CreatedAtRoute("Get", model);
            } catch(ArgumentException e) {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")] 
        [ProtectFilter("Admin")] 
        public IActionResult UpdateTeam(Guid id, [FromBody]Team updatedTeam)
        {
            try
            {
                if (teamService.UpdateTeam(id, updatedTeam))
                {
                    //Status No Content -> 204
                    return StatusCode(0xCC);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (InvalidOperationException ioe)
            {
                return BadRequest(ioe.Message);
            }
        }
    }
}