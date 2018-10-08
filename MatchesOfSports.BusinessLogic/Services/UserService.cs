using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchesOfSports.Domain;
using MatchesOfSports.DataAccess.Interface;
using MatchesOfSports.BusinessLogic.Services;

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

            unitOfWork.UserRepository.Add(newUser);
            unitOfWork.Save();
            return true;
        }

        public bool UpdateUser(Guid id, User updatedUser)
        {
            if (updatedUser == null)
            {
                return false;
            }

            if (!updatedUser.IsValid())
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidUserData);
            }
            
            User userEntity = unitOfWork.UserRepository.Get(id);

            if( userEntity == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidUserData);
            }
                userEntity.UserId= updatedUser.UserId;
                userEntity.Name = updatedUser.Name;
                userEntity.Surname = updatedUser.Surname;
                userEntity.UserName = updatedUser.UserName;
                userEntity.Password = updatedUser.Password;
                userEntity.Email     = updatedUser.Email;
                userEntity.WasDeleted = updatedUser.WasDeleted;
                userEntity.UserRole = updatedUser.UserRole;

            unitOfWork.UserRepository.Update(userEntity);
            unitOfWork.Save();
            return true;
        }

        private bool ExistsUser(User user)
        {
            return unitOfWork.UserRepository.Get(user.UserId)!=null;
        }
        public bool DeleteUserByUserName(Guid id)
        {
            try
            {
                User user = GetUserByUserId(id);
                User updatedUser = new User();
                user.UserId      = updatedUser.UserId;
                user.Name        = updatedUser.Name;
                user.Surname    = updatedUser.Surname;
                user.UserName    = updatedUser.UserName;
                user.Password   = updatedUser.Password;
                user.Email       = updatedUser.Email;
                updatedUser.WasDeleted = true;
                user.UserRole = updatedUser.UserRole;
                UpdateUser(user.UserId ,updatedUser);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }


        public User GetUserByUserId(Guid id) 
        {
            return unitOfWork.UserRepository.Get(id);
        }

         public IEnumerable<User> GetAllUsers()
         {
             return unitOfWork.UserRepository.GetAll();
         }
    }
}