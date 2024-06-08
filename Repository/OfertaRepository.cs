using Microsoft.EntityFrameworkCore;

public class OfertaRepository : IOfertaRepository
{
    private readonly DbContext _dbContext;
    private readonly DbSet<Oferta> _dbSet;

    public OfertaRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<Oferta>();
    }

    public async Task<List<Oferta>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<Oferta> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(Oferta entity)
    {
        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Oferta entity)
    {
        _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Oferta entity)
    {
        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}