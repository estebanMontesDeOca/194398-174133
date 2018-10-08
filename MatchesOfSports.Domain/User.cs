using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MatchesOfSports.Domain
{
    public enum Role
    {
        Admin,
        Folower,
        noRole
    }
    public class User
    {
        public Guid   UserId {get;set;}
        public string Name {get; set;}  
        public string Surname{get;set;}
        public string UserName{get;set;}
        public string Password{get;set;}
        public string Email{get;set;}
        public bool   WasDeleted{get;set;}
        public Role UserRole {get;set;}
        public List<Comment> ListOfComments {get;set;}
        public List<Team>    ListOfFavouriteTeams {get;set;}
    
  
        public User(){
            Name = "noName"; 
            Surname = "noSurename";
            UserName =  "noUserName";
            Password = "noPassword";
            Email =  "noEmail";
            WasDeleted =false;
            ListOfComments= new List<Comment>();
            ListOfFavouriteTeams= new List<Team>();
            UserRole = Role.noRole;
        }


        public bool IsAllowedToEditAllInformation() => UserRole.Equals(Role.Admin);
        public bool IsValid()
        {
            if (   IsNullOrEmpty(Name)
                || IsNullOrEmpty(Surname) 
                || IsNullOrEmpty(UserName) 
                || IsNullOrEmpty(Password)
                || IsValidEmail(Email)  
                || !ValidRole(UserRole))
           {
                return false;
            }
            return true;
        }

         //bool invalid = false;

   private bool IsNullOrEmpty(string value)
    {
        return string.IsNullOrWhiteSpace(value);
    }
   public bool IsValidEmail(string strIn)
   {
       return true;
      /* invalid = false;
       if (String.IsNullOrEmpty(strIn))
          return false;

       // Use IdnMapping class to convert Unicode domain names.
       try {
          strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper,
                                RegexOptions.None, TimeSpan.FromMilliseconds(200));
       }
       catch (RegexMatchTimeoutException) {
         return false;
       }

        if (invalid)
           return false;

       // Return true if strIn is in valid email format.
       try {
          return Regex.IsMatch(strIn,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
       }
       catch (RegexMatchTimeoutException) {
          return false;
       }
       */
   }

   /*private string DomainMapper(Match match)
   {
      // IdnMapping class with default property values.
      IdnMapping idn = new IdnMapping(); 
      string domainName = match.Groups[2].Value;
      try {
         domainName = idn.GetAscii(domainName);
      }
      catch (ArgumentException) {
         invalid = true;
      }
      return match.Groups[1].Value + domainName;
   }
        private bool IsNullOrEmpty(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        private bool IsNumerical(string value) => Regex.IsMatch(value, @"^\d+$");
 
*/
        private bool ValidRole(object role)
        {
            return Role.IsDefined(typeof(Role), role);
        }

    public bool isItDeleted()
    {
        return WasDeleted;
    }
    }

    
}
