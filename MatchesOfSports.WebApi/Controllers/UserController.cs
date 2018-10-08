using System;
using Microsoft.AspNetCore.Mvc;
using MatchesOfSports.Domain;
using MatchesOfSports.BusinessLogic;
using MatchesOfSports.BusinessLogic.Services;

namespace MatchesOfSports.WebApi.Controllers
{
    [Route("api/users")]
    //[EnableCors(origins: "*",headers: "*", methods: "*")]
    public class UsersController : Controller
    {
        private IUsersService usersService;

        public UsersController(IUsersService usersService) : this()
        {
            this.usersService =usersService;
        }

        [AuthorizeRoles(Role.Admin)]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(users.GetAllUsers());
        }

        [AuthorizeRoles(Role.Admin)]
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetUserById(int id)
        {
            User userToRetrieve = service.GetUserById(id);
            if (userToRetrieve == null)
            {
                return NotFound();
            }
            return Ok(userToRetrieve);
        }

        [AuthorizeRoles(Role.Administrator)]
        [HttpDelete]
        [Route("{UserName}")]
        public IHttpActionResult DeleteUserByUserName(String userName)
        {
            try
            {
                if (service.DeleteUserByUserName(userName))
                {
                    return StatusCode(HttpStatusCode.NoContent);
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
                var user = users.Create(UserModel.ToEntity(model));
                return CreatedAtRoute("Get", new { userName = user.UserName }, UserModel.ToModel(user));
            } catch(ArgumentException e) {
                return BadRequest(e.Message);
            }
        }

        protected override void Dispose(bool disposing) 
        {
            try {
                base.Dispose(disposing);
            } finally {
                users.Dispose();
            }
        }
    }
}