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
        private  UnitOfWork unitOfWork;

        public CommentService( UnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException();
            }
            this.unitOfWork = unitOfWork;
        }

        public bool CreateComment(Comment newComment)
        {
           if(newComment==null){
               throw new InvalidOperationException("Could not create comment - Comment empty");
           }else{
                unitOfWork.CommentRepository.Insert(newComment);
                unitOfWork.Save();
                return true;
           }
        }
        public Comment GetCommentById(Guid id)
        {
          try{  
            return unitOfWork.CommentRepository.GetById(id);
          }catch(ArgumentNullException)
            {
                throw new InvalidOperationException("Could not get comment - Comment  does not exists");
            }
        }

         public bool CommentOfDeletedUser(Comment theComment)
         {
             return theComment.UserWhoComment.WasDeleted;
         }

         public IEnumerable<Comment> GetAllComments()
         {
             try{
                return unitOfWork.CommentRepository.Get();
             }catch(ArgumentNullException)
            {
                throw new InvalidOperationException("Could not get all comments - Data Base empty");
            }

         }


    }
}