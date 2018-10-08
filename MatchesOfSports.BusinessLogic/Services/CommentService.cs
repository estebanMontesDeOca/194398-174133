using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;
using MatchesOfSports.DataAccess.Interface;
using MatchesOfSports.Domain; 
using MatchesOfSports.BusinessLogic.Services;

namespace MatchesOfSports.BusinessLogic.Services
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
            unitOfWork.CommentRepository.Add(newComment);
            unitOfWork.Save();
            return true;
        }
        public Comment GetCommentById(Guid id)
        {
            return unitOfWork.CommentRepository.Get(id);
        }

         public bool CommentOfDeletedUser(Comment theComment)
         {
             return theComment.UserWhoComment.WasDeleted;
         }

         public IEnumerable<Comment> GetAllComments()
         {
             return unitOfWork.CommentRepository.GetAll();
         }


    }
}