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
    [ApiController]
    public class TeamController : ControllerBase
    {
        private TeamService TeamService { get; set; }

        public TeamController(TeamService teamService, UnitOfWork unitOfWork)
        {
            TeamService = teamService;
            teamService.UnitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAllTeams()
        {
            try
            {
                IEnumerable<Team> allTeams = TeamService.GetAllTeams();
                if (allTeams == null)
                {
                    return NotFound();
                }
                return Ok(TeamModel.ToModel(allTeams));
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }

        [Route("GetTeamById/{id}")]
        [HttpGet]
        public IActionResult GetTeamById(Guid id)
        {
            var team = TeamService.GetTeamById(id);
            if (team == null) 
            {
                return NotFound();
            }
            return Ok(TeamModel.ToModel(team));
        }
        [Route("GetSportsOfaTeam/{id}")]
        [HttpGet]
        public IActionResult GetSportsOfaTeam(Guid id)
        {
            Sport team = TeamService.SportsOfATeam(id);
            if (team == null) 
            {
                return NotFound();
            }
            return Ok(SportModel.ToModel(team));
        }
        [Route("GetMatchesOfaTeam/{id}")]
        [HttpGet]
        public IActionResult GetMatchesOfaTeam(Guid id)
        {
         IEnumerable<Match> team = TeamService.MatchesOfaTeam(id);
            if (team == null) 
            {
                return NotFound();
            }
            return Ok(MatchModel.ToModel(team));   
        }
   
       // [ProtectFilter("Admin")]
        [HttpPost]
        public IActionResult CreateTeam([FromBody]Team model)
        {
            try {
                var team = TeamService.Create(model);
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
                if (TeamService.UpdateTeam(id, updatedTeam))
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
                if (TeamService.DeleteTeamByName(id))
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