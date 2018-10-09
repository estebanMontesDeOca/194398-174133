using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MatchesOfSports.Domain;
using MatchesOfSports.DataAccess.Interface;
using MatchesOfSports.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly MatchesOfSportsContext context;
    private bool disposed = false;

    private IRepositoryOf<User> userRepository;
    private IRepositoryOf<Team> teamRepository;
    private IRepositoryOf<Match> matchRepository;
    private IRepositoryOf<Sport> sportRepository;
    private IRepositoryOf<Comment> commentRepository;
    public UnitOfWork(MatchesOfSportsContext MatchesContext)
    {
        context = MatchesContext;
    }
    public IRepositoryOf<Comment> CommentRepository
    {
        get
        {
            if(commentRepository==null){
                commentRepository = new CommentRepository(context);
            }
            return commentRepository;
        }
    }
      public IRepositoryOf<Sport> SportRepository
    {
        get
        {
            return sportRepository = sportRepository ?? new SportRepository(context);
        }
    }
    public IRepositoryOf<Match> MatchRepository
    {
        get
        {
            return matchRepository = matchRepository ?? new MatchRepository(context);
        }
    }
    public IRepositoryOf<User> UserRepository
    {
        get
        {
            return userRepository = userRepository ?? new UserRepository(context);
        }
    }

    public IRepositoryOf<Team> TeamRepository
    {
        get
        {
            return teamRepository = teamRepository ?? new TeamRepository(context);
        }
    }

    public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

     protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

    public void Save()
    {
        context.SaveChanges();
    }
}