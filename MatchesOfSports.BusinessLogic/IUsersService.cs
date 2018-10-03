using System.Collections.Generic; 
using MatchesOfSports.Domain;

namespace MatchesOfSports.BusinessLogic.Services
{
    public interface IUsersService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserByUserName(int id);
        bool DeleteUserByUserName(int userId);
        int CreateUser(User newUser);
        bool UpdateUser(string userName, User updatedUser);
        User FindAdminUser(string userName, string password);
    }
}