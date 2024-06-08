using Microsoft.EntityFrameworkCore;

public class PescariaRepository : IPescariaRepository
{
    private readonly DbContext _dbContext;
    private readonly DbSet<Pescaria> _dbSet;

    public PescariaRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<Pescaria>();
    }

    public async Task<List<Pescaria>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<Pescaria> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(Pescaria entity)
    {
        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Pescaria entity)
    {
        _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Pescaria entity)
    {
        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}