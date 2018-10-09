using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MatchesOfSports.Domain;

namespace MatchesOfSports.WebApi.Models
{
    public class UserModel : Model<User, UserModel>
    {
        //public Guid   UserId {get;set;}
        public string Name {get; set;}  
        public string Surname{get;set;}
        public string UserName{get;set;}
        public string Password{get;set;}
        public string Email{get;set;}
        public bool   WasDeleted{get;set;}
        public Role UserRole {get;set;}
        public List<Comment> ListOfComments {get;set;}
        public List<Team>    ListOfFavouriteTeams {get;set;}
        
        public UserModel(User entity)
        {
            SetModel(entity);
        }
         public UserModel(){}

        public override User ToEntity() => new User()
        {
            Name=this.Name, 
            Surname =this.Surname,
            UserName = this.UserName,
            Password = this.Password,
            Email = this.Email,
            WasDeleted= this.WasDeleted,
            UserRole =this.UserRole,    
            ListOfComments = this.ListOfComments,
            ListOfFavouriteTeams = this.ListOfFavouriteTeams,
        };
 

        protected override UserModel  SetModel (User entity)
        {
            Name=entity.Name; 
            Surname =entity.Surname;
            UserName =entity.UserName;
            Password = entity.Password;
            Email = entity.Email;
            WasDeleted= entity.WasDeleted;
            UserRole =entity.UserRole;  
            ListOfComments = entity.ListOfComments;
            ListOfFavouriteTeams = entity.ListOfFavouriteTeams;
            return this;
        }

    }
}