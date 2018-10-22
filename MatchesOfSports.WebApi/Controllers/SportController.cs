using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MatchesOfSports.BusinessLogic.Services;
using MatchesOfSports.WebApi.Models;
using MatchesOfSports.Domain;
using Newtonsoft.Json.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MatchesOfSports.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportController : ControllerBase
    {
        private ISportService sportService;

        public SportController(ISportService sportService)
        {
            this.sportService = sportService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Sport> result = sportService.GetAllSports();
            //JArray result = JArray.FromObject(sportService.GetAllSports());
            return Ok(result);
        }
         
        [HttpPost]
        public IActionResult Post([FromBody]Sport model)
        {
            try
            {
                var user = sportService.CreateSport(model);
                return CreatedAtRoute("Get", model);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
