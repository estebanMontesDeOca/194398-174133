using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchesOfSports.Domain;
using MatchesOfSports.DataAccess;

namespace MatchesOfSports.BusinessLogic
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

        public bool CreateUser(User newUser)
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
            return true;
        }

        public bool UpdateUser(string userName, User updatedUser)
        {
            if (updatedUser == null)
            {
                return false;
            }

            if (!updatedUser.IsValid())
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidUserData);
            }
            
            User userEntity = unitOfWork.UserRepository.GetUserByUserName(userName);

            if( userEntity == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidUserData);
            }

                user.Name = updatedUser.Name;
                user.SureName = updatedUser.SureName;
                user.UserName = updatedUser.UserName;
                user.Passrword = updatedUser.Password;
                user.Email     = updatedUser.Email;
                user.WasDeleted = updatedUser.WasDeleted;
                user.UserRole = updatedUser.UserRole;
                UpdateUser(userName,updatedUser);

            unitOfWork.UserRepository.Update(userEntity);
            unitOfWork.Save();
            return true;
        }

        private bool ExistsUser(User user)
        {
            return unitOfWork.UserRepository.Get(u => u.UserName == user.UserName).Count() > 0;
        }

        public void DeleteUser(string userName)
        {
            unitOfWork.UserRepository.Delete(userName);
            unitOfWork.Save();
        }

        public bool DeleteUserByUserName(string userName)
        {
            try
            {
                User user = GetUserByUserName(userName);
                User updatedUser = new User();
                user.Name        = updatedUser.Name;
                user.SureName    = updatedUser.SureName;
                user.UserName    = updatedUser.UserName;
                user.Passrword   = updatedUser.Password;
                user.Email       = updatedUser.Email;
                updatedUser.WasDeleted = true;
                user.UserRole = updatedUser.UserRole;
                UpdateUser(userName,updatedUser);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }


        public User GetUserByUserName(string userNam)
        {
            return unitOfWork.UserRepository.Get(UserName);
        }
    }
}