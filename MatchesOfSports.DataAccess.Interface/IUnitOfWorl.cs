using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchesOfSports.Domain;

namespace MatchesOfSports.DataAccess.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryOf<User> UserRepository { get; }
        IRepositoryOf<Match> MatchRepository { get; }
        IRepositoryOf<Sport> SportRepository { get; }
        IRepositoryOf<Comment> CommentRepository { get; }
        IRepositoryOf<Team> TeamRepository { get; } 
        void Save();
    }
}
