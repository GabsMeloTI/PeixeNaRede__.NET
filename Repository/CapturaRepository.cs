using Microsoft.EntityFrameworkCore;

public class CapturaRepository : ICapturaRepository
{
    private readonly DbContext _dbContext;
    private readonly DbSet<Captura> _dbSet;

    public CapturaRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<Captura>();
    }

    public async Task<List<Captura>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<Captura> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(Captura entity)
    {
        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Captura entity)
    {
        _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Captura entity)
    {
        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}