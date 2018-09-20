using System;
using System.Collections.Generic;

namespace MatchesOfSports.Domain
{
    public class Comment
    {
        private string TheComment {get; set;}  

        
        public Comment(){
            TheComment = "noComment"; 
        } 

        public Comment(string AComment)
        {
            TheComment = AComment;
        }
    }
}
