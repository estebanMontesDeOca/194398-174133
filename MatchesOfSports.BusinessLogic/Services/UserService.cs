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
                throw new InvalidOperationException("Could not create user - Invalid data");
            }
            if (ExistsUser(newUser))
            {
                throw new InvalidOperationException("Could not create user - The user already exist");
            }

            unitOfWork.UserRepository.Insert(newUser);
            unitOfWork.Save();
            return true;
        }

        public bool UpdateUser(Guid id, User updatedUser)
        {
            if (updatedUser == null)
            {
                 throw new InvalidOperationException("Could not update user - Invalid data");
            }

            if (!updatedUser.IsValid())
            {
                throw new InvalidOperationException("Could not update user - Invalid User");
            }
            
            User userEntity = unitOfWork.UserRepository.GetById(id);

            if( userEntity == null)
            {
                throw new InvalidOperationException("Could not update user - Invalid data");
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
            return unitOfWork.UserRepository.GetById(user.UserId)!=null;
        }
        public bool DeleteUserByUserName(Guid id)
        {
            try
            {   
                User user = GetUserByUserId(id);
                if (!user.WasDeleted){
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
                return false;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }


        public User GetUserByUserId(Guid id) 
        {
           try{
                return unitOfWork.UserRepository.GetById(id);
           } catch (ArgumentNullException)
            {
               throw new InvalidOperationException("Could not get user - User does not exist");
            }
        }

         public IEnumerable<User> GetAllUsers()
         {
            try{ 
             IEnumerable<User> getUsers = unitOfWork.UserRepository.Get();
             List<User> getUsersNoDeleted = new List<User>();
             foreach (User user in getUsers)
             {
                 if(!user.WasDeleted)
                 {
                     getUsersNoDeleted.Add(user);
                 }
             }
             return getUsersNoDeleted;
            }catch(ArgumentNullException)
            {
                return new List<User>();
                //throw new InvalidOperationException("Could not get users- DB is empty");
            }
         }
    }
}