public class UnitOfWork : IUnitOfWork
{
    private readonly MatchesOfSportsContext context;
    private IRpositoryOf<User> userRepository;
    private IRepositoryOf<Team> teamRepository;
    private IRepositoryOf<Match> matchRepository;
    private IRepositoryOf<Sport> sportRepository;
    private IRepositoryOf<Comment> commentRepository
    ;
    public UnitOfWork(MatchesOfSportsContext matchesContext)
    {
        context = matchesContext;
    }
    public IRpositoryOf<Comment> CommentRepository
    {
        get
        {
            return commentRepository = commentRepository ?? new IRepositoryOf<Comment>(context);
        }
    }
      public IRpositoryOf<Sport> SportRepository
    {
        get
        {
            return sportRepository = sportRepository ?? new IRepositoryOf<Sport>(context);
        }
    }
    public IRpositoryOf<Match> MatchRepository
    {
        get
        {
            return matchRepository = matchRepository ?? new IRepositoryOf<Match>(context);
        }
    }
    public IRpositoryOf<User> UserRepository
    {
        get
        {
            return userRepository = userRepository ?? new IRepositoryOf<User>(context);
        }
    }

    public IGenericRepository<Team> TeamRepository
    {
        get
        {
            return teamRepository = teamRepository ?? new IRepositoryOf<Team>(context);
        }
    }

    public void Save()
    {
        _bloggingContext.SaveChanges();
    }
}