using System;
using System.Collections.Generic;

namespace MatchesOfSports.Domain
{
    public class Match
    {
        public  Guid  MatchId  {get;set;}
        public  DateTime DateAndTime {get; set;}
        public Team TeamOne { get; set; }
        public Team TeamTwo { get; set; }
        public List<Comment> Comments {get;set;}
        public Sport KindOfSport {get;set;}
        public bool WasDeleted {get;set;}

        
        public Match(){
            DateAndTime =DateTime.Now;
            TeamOne = new Team();
            TeamTwo = new Team();
            Comments = new List<Comment>();
            KindOfSport = new Sport();
            WasDeleted = false;
        }
    }
}
