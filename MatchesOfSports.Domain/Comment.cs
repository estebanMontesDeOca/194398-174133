using System;
namespace MatchesOfSports.Domain
{
    public class Comment
    {
        public Guid Commet {get;set;}
        public string TheComment {get; set;}  
        public User   UserWhoComment {get;set;}

        
        public Comment(){
            TheComment = "noComment"; 
            UserWhoComment = new User();
        } 

        public Comment(string AComment, User TheUser)
        {
            TheComment = AComment;
            UserWhoComment = TheUser;
        }
    }
}
