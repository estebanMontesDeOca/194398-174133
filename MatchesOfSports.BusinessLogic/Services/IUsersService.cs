using System;
using System.Collections.Generic; 
using MatchesOfSports.Domain;

namespace MatchesOfSports.BusinessLogic.Services
{
    public interface IUsersService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserByUserId(Guid id);
        bool DeleteUserByUserName(Guid id);
        bool CreateUser(User newUser);
        bool UpdateUser(Guid id, User updatedUser);
    }
}