using System;
using Microsoft.AspNetCore.Mvc;
using MatchesOfSports.Domain;
using MatchesOfSports.BusinessLogic.Interface;

namespace MatchesOfSports.WebApi.Controllers
{
    [Route("api/users")]
    [EnableCors(origins: "*",headers: "*", methods: "*")]
    public class UsersController : Controller
    {
        private IUserService users;

        public UsersController(IUserLogic users) : base()
        {
            this.users = new UserService(new UnitOfWork(new MatchesOfSportsContext()));
        }

        public UsersController(IUsersService service)
        {
            if(service == null)
            {
                throw new ArgumentNullException();
            }
            users = service;
        }

        [AuthorizeRoles(Role.Administrator)]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(users.GetAllUsers());
        }

        [AuthorizeRoles(Role.Administrator)]
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