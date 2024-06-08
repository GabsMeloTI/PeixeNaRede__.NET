using Microsoft.EntityFrameworkCore;

public class EncontroUsuarioRepository : IEncontroUsuarioRepository
{
    private readonly DbContext _dbContext;
    private readonly DbSet<EncontroUsuario> _dbSet;

    public EncontroUsuarioRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<EncontroUsuario>();
    }

    public async Task<List<EncontroUsuario>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<EncontroUsuario> GetByIdAsync(int userId, int meetingId)
    {
        return await _dbSet.FindAsync(userId, meetingId);
    }

    public async Task AddAsync(EncontroUsuario entity)
    {
        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(EncontroUsuario entity)
    {
        _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(EncontroUsuario entity)
    {
        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}