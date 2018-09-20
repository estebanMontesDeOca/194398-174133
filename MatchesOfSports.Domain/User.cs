using System;
using System.Collections.Generic;

namespace MatchesOfSports.Domain
{
    enum Role
    {
        Admin,
        Folower,
        noRole
    }
    public class User
    {
        private string Name {get; set;}  
        private string Surname{get;set;}
        private string UserName{get;set;}
        private string Password{get;set;}
        private string Email{get;set;}
        private Role   userRole {get;set;}
        private List<Comment> ListOfComments {get;set;}
        private List<Team>    ListOfFavouriteTeams {get;set;}
    
  
        public User(){
            Name = "noName"; 
            Surname = "noSurename";
            UserName =  "noUserName";
            Password = "noPassword";
            Email =  "noEmail";
            userRole = Role.noRole;
        } 
 
    }
}
