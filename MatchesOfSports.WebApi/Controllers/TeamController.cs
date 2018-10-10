using System;
using System.Collections.Generic; 
using Microsoft.AspNetCore.Mvc;
using MatchesOfSports.BusinessLogic.Services;
using MatchesOfSports.WebApi.Models;
using MatchesOfSports.Domain;
using MatchesOfSports.WebApi.Filters;

namespace MatchesOfSports.WebApi.Controllers
{
    [Route("api/team")]
    public class TeamController : Controller
    {
        private ITeamService teamService;

        public TeamController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Team>> GetAllTeams()
        {
            IEnumerable<Team> allTeams =TeamModel.ToModel(teamService.GetAllTeams());
            if (allTeams == null) 
            {
                return NotFound();
            }
            return Ok(TeamModel.ToModel(allTeams)); 
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
            } catch(ArgumentException) {
                return StatusCode(500, "Internal server error");
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
            catch (InvalidOperationException)
            {
               return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        [ProtectFilter("Admin")] 
        public IActionResult DeleteTeam(Guid id)
        {
              try
            {
                if (teamService.DeleteTeamByName(id))
                {
                    //Status No Content -> 204
                    return StatusCode(0xCC);;
                }
                return NotFound();
            }catch(InvalidOperationException)
            {
               return StatusCode(500, "Internal server error");
            }
        }
    }
}