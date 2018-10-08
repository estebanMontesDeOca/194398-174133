using System.Collections.Generic; 
using MatchesOfSports.Domain;

namespace MatchesOfSports.BusinessLogic.Services
{
    public interface ICommentService
    {
        IEnumerable<Comment> GetAllComments();
        Comment GetCommentByText(string theComment);
        bool CommentOfDeletedUser(Comment theComment);
        bool CreateComment(Comment newComment);
        //bool UpdateComment(string userName, User updatedUser);
    }
}