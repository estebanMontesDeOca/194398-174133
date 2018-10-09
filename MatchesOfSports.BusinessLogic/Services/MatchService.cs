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
    public class MatchService : IMatchService
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

        public IEnumerable<Match> GetAllTheMatches()
        {
            try{
                return unitOfWork.MatchRepository.GetAll();
            }catch(ArgumentNullException){
                throw new InvalidOperationException("Could not get all matches - Data Base empty");
            } 
        }
        Match GetMatchById(Guid id);
        bool DeleteMatch(Guid Id);
        bool CreateMathc(Match newMatch);
        bool UpdateMatch(string userName, User updatedUser);

    }
