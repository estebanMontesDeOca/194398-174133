using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchesOfSports.Domain;
using MatchesOfSports.DataAccess;

namespace MatchesOfSports.BusinessLogic
{
    public class CommentService : ICommentService
    {
        private IUnitOfWork unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException();
            }
            this.unitOfWork = unitOfWork;
        }

        public bool CreateComment(Comment newComment)
        {
            //COMPROBAR QUE NO SEA NULL
            unitOfWork.CommentRepository.Insert(newComment);
            unitOfWork.Save();
            return true;
        }

        Comment GetCommentByText(string theComment)
        {
            return unitOfWork.CommentRepository.Get(theComment);
        }

         bool CommentOfDeletedUser(Comment theComment)
         {
             return theComment.UserWhoComment.WasDeleted;
         }


    }
}