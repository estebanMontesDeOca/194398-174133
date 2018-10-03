using System.Collections.Generic; 
using MatchesOfSports.Domain;

namespace MatchesOfSports.BusinessLogic.Services
{
    public interface IUsersService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        bool DeleteUserById(int userId);
        int CreateUser(User newUser);
        bool UpdateUser(int userId, User updatedUser);
        User FindAdminUser(string userName, string password);
    }
}