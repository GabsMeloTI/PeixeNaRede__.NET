using Microsoft.EntityFrameworkCore;

public class EncontroRepository : IEncontroRepository
{
    private readonly DbContext _dbContext;
    private readonly DbSet<Encontro> _dbSet;

    public EncontroRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<Encontro>();
    }

    public async Task<List<Encontro>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<Encontro> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(Encontro entity)
    {
        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Encontro entity)
    {
        _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Encontro entity)
    {
        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}