using System;
using System.Collections.Generic;

namespace MatchesOfSports.Domain
{
    public class Comment
    {
        private string TheComment {get; set;}  
        private User   UserWhoComment {get;set;}

        
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
