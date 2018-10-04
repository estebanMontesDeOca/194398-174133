using System.Collections.Generic; 
using MatchesOfSports.Domain;

namespace MatchesOfSports.BusinessLogic.Services
{
    public interface IUsersService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserByUserName(string userName);
        bool DeleteUserByUserName(string userName);
        bool CreateUser(User newUser);
        bool UpdateUser(string userName, User updatedUser);
    }
}