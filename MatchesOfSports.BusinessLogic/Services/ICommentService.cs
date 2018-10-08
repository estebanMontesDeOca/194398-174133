using System;
using System.Collections.Generic;
using MatchesOfSports.Domain;
using MatchesOfSports.BusinessLogic.Services;

namespace MatchesOfSports.BusinessLogic.Services
{
    public interface ICommentService
    {
        IEnumerable<Comment> GetAllComments();
        Comment GetCommentById(Guid id);
        bool CommentOfDeletedUser(Comment theComment);
        bool CreateComment(Comment newComment);
    }
}