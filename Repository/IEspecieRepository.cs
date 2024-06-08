public interface IEspecieRepository
{
    Task<List<Especie>> GetAllAsync();
    Task<Especie> GetByIdAsync(int id);
    Task AddAsync(Especie entity);
    Task UpdateAsync(Especie entity);
    Task DeleteAsync(Especie entity);
}