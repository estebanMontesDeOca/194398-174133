using System;
using System.Collections.Generic;
using System.Linq;
using MatchesOfSports.Domain;

namespace MatchesOfSports.WebApi.Models
{
    public class CommentModel : Model<Comment, CommentModel>
    {
        public Guid CommentId { get; set; }
        public string TheComment { get; set; }
        public User UserWhoComment { get; set; }

        public CommentModel(){}
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