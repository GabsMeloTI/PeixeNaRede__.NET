public interface IPescariaRepository
{
    Task<List<Pescaria>> GetAllAsync();
    Task<Pescaria> GetByIdAsync(int id);
    Task AddAsync(Pescaria entity);
    Task UpdateAsync(Pescaria entity);
    Task DeleteAsync(Pescaria entity);
}