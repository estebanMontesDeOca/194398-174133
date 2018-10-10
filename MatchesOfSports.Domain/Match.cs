using System;
using System.Collections.Generic;


namespace MatchesOfSports.Domain
{
    
    public class Match
    {
        public Guid  MatchId  {get;set;}
        public DateTime DateAndTime {get; set;}
        public Sport TheSport {get;set;}         
        public Guid TeamOne { get; set; }         
        public Guid TeamTwo { get; set; }
        public List<Comment> Comments {get;set;}
        public Sport KindOfSport {get;set;}
        public bool WasDeleted {get;set;}

        
        public Match(){
            DateAndTime =DateTime.Now;
            TeamOne = new Guid();
            TeamTwo = new Guid();
            Comments = new List<Comment>();
            KindOfSport = new Sport();
            WasDeleted = false;
        }
    }
}
