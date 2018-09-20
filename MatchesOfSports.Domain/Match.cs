using System;
using System.Collections.Generic;

namespace MatchesOfSports.Domain
{
    public class Match
    {
        private DateTime DateAndTime {get; set;}
        private Team TeamOne { get; set; }
        private Team TeamTwo { get; set; }
        private List<Comment> Comments {get;set;}
        private Sport KindOfSport {get;set;}

        
        public Match(){
            DateAndTime =DateTime.Now;
            TeamOne = new Team();
            TeamTwo = new Team();
            Comments = new List<Comment>();
            KindOfSport = new Sport();
        } 
    }
}
