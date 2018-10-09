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
            return commentRepository = commentRepository ?? new IRepositoryOf<Comment>(context);
        }
    }
      public IRepositoryOf<Sport> SportRepository
    {
        get
        {
            return sportRepository = sportRepository ?? new IRepositoryOf<Sport>(context);
        }
    }
    public IRepositoryOf<Match> MatchRepository
    {
        get
        {
            return matchRepository = matchRepository ?? new IRepositoryOf<Match>(context);
        }
    }
    public IRepositoryOf<User> UserRepository
    {
        get
        {
            return userRepository = userRepository ?? new IRepositoryOf<User>(context);
        }
    }

    public IRepositoryOf<Team> TeamRepository
    {
        get
        {
            return teamRepository = teamRepository ?? new IRepositoryOf<Team>(context);
        }
    }

    public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    public void Save()
    {
        context.SaveChanges();
    }
}