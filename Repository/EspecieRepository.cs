using Microsoft.EntityFrameworkCore;

public class EspecieRepository : IEspecieRepository
{
    private readonly DbContext _dbContext;
    private readonly DbSet<Especie> _dbSet;

    public EspecieRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<Especie>();
    }

    public async Task<List<Especie>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<Especie> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(Especie entity)
    {
        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Especie entity)
    {
        _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Especie entity)
    {
        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}