using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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


        public bool IsAllowedToEditAllInformation() => Role.Equals(Role.Admin);
        public bool IsValid()
        {
            if (   IsNullOrEmpty(Name)
                || IsNullOrEmpty(Surname) 
                || IsNullOrEmpty(UserName) 
                || IsNullOrEmpty(Password)
                || IsValidEmail(Email)  
                || !ValidRole(Role))
           {
                return false;
            }
            return true;
        }

         bool invalid = false;

   public bool IsValidEmail(string strIn)
   {
       invalid = false;
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
   }

   private string DomainMapper(Match match)
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

        private bool ValidRole(object role)
        {
            return Role.IsDefined(typeof(Role), role);
        }
 
    }
}
