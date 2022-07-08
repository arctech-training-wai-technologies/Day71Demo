namespace Day71Demo;

public class PlayerService : IPlayerService
{
    private readonly ApplicationDbContext _dbContext;

    public PlayerService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddPlayerToDatabase(Player player)
    {
        await _dbContext.Players.AddAsync(player);
        _dbContext.SaveChanges();
    }
}