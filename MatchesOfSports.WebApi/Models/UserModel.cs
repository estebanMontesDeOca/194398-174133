using System;
using System.Collections.Generic;
using System.Linq;
using MatchesOfSports.Domain;

namespace MatchesOfSports.WebApi.Models
{
    public class CommentModel : Model<Comment, CommentModel>
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
        
        public CommentModel(Comment entity)
        {
            SetModel(entity);
        }

        public override Comment ToEntity() => new Comment()
        {
            CommentId = this.CommentId,
            TheComment = this.TheComment,
            UserWhoComment = this.UserWhoComment,
        };

        protected override CommentModel SetModel(Comment entity)
        {
            CommentId = entity.CommentId;
            TheComment = entity.TheComment;
            UserWhoComment = entity.UserWhoComment;
            return this;
        }

    }
}