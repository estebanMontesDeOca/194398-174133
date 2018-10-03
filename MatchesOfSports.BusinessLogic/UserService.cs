using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchesOfSports.Domain;
using MatchesOfSports.DataAccess;

namespace MatchesOfSports.BusinessLogic.Services
{
    public class UserService : IUsersService
    {
        private IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException();
            }
            this.unitOfWork = unitOfWork;
        }

        public int CreateUser(User newUser)
        {
            if (!newUser.IsValid())
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidUserData);
            }
            if (ExistsUser(newUser))
            {
                throw new InvalidOperationException(ExceptionMessages.ExistingUserError);
            }

            unitOfWork.UserRepository.Insert(newUser);
            unitOfWork.Save();
            return newUser.Id;
        }

        public bool UpdateUser(int userId, User updatedUser)
        {
            if (updatedUser == null)
            {
                return false;
            }

            if (!updatedUser.IsValid())
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidUserData);
            }
            
            User userEntity = unitOfWork.UserRepository.GetById(userId);

            if( userEntity == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidUserData);
            }

            userEntity.Name = updatedUser.Name;
            userEntity.Password = updatedUser.Password;
            userEntity.Phone = updatedUser.Phone;
            userEntity.Role = updatedUser.Role;
            userEntity.Surname = updatedUser.Surname;
            userEntity.Username = updatedUser.Username;

            unitOfWork.UserRepository.Update(userEntity);
            unitOfWork.Save();
            return true;
        }

        private bool ExistsUser(User user)
        {
            return unitOfWork.UserRepository.Get(u => u.Username == user.Username).Count() > 0;
        }

        public bool DeleteUserById(int userId)
        {
            try
            {
                //Obtengo los administradores restantes que quedarían si borro este user (sólo si el user a borrar es admin).
                User user = GetUserById(userId);
                if(user != null && user.Role == Role.Administrator)
                {
                    IEnumerable<User> users = unitOfWork.UserRepository.Get(u => u.Role.ToString().Equals(Role.Administrator.ToString()) && u.Id != userId);
                    if (users.Count() == 0)
                    {
                        throw new InvalidOperationException(ExceptionMessages.LastDeletedAdmin);
                    }
                    else
                    {
                        unitOfWork.UserRepository.Delete(userId);
                        unitOfWork.Save();
                        return true;
                    }
                }
                else
                {
                    unitOfWork.UserRepository.Delete(userId);
                    unitOfWork.Save();
                    return true;
                }
                  
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            return unitOfWork.UserRepository.Get(null, null, "");
        }

        public User GetUserById(int id)
        {
            return unitOfWork.UserRepository.GetById(id);
        }

        public User FindAdminUser(string userName, string password)
        {
            return unitOfWork.UserRepository.GetFirst(u => u.Username.Equals(userName) && u.Password.Equals(password) && u.Role == Role.Administrator, null, "");
        }
    }
}