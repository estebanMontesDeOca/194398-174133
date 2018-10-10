using System;
using System.Net;
using System.Web.Http; 
using Microsoft.AspNetCore.Mvc;
using MatchesOfSports.Domain;
using MatchesOfSports.BusinessLogic;
using MatchesOfSports.BusinessLogic.Services;
using MatchesOfSports.WebApi.Filters;

namespace MatchesOfSports.WebApi.Controllers
{
    [Route("api/users")]
    //[EnableCors(origins: "*",headers: "*", methods: "*")]
    public class UsersController : Controller
    {
        private IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService =usersService;
        }

        [ProtectFilter("Admin")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(usersService.GetAllUsers());
        }

        [ProtectFilter("Admin")]
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUserById(Guid id)
        {
            User userToRetrieve = usersService.GetUserByUserId(id);
            if (userToRetrieve == null || userToRetrieve.WasDeleted)
            {
                return NotFound();
            }
            return Ok(userToRetrieve);
        }

        [ProtectFilter("Admin")]
        [HttpDelete]
        [Route("{UserName}")]
        public IActionResult DeleteUserByUserName(Guid id)
        {
            try
            {
                if (usersService.DeleteUserByUserName(id))
                {
                    //Status No Content -> 204
                    return StatusCode(0xCC);
                }
                return NotFound();
            }catch(InvalidOperationException ioex)
            {
                return BadRequest(ioex.Message);
            }
            
        }

        [HttpPost]
        public IActionResult Post([FromBody]User model)
        {
            try {
                var user = usersService.CreateUser(model);
                return CreatedAtRoute("Get", model);
            } catch(ArgumentException e) {
                return BadRequest(e.Message);
            }
        }
    }
}