public interface IEncontroRepository
{
    Task<List<Encontro>> GetAllAsync();
    Task<Encontro> GetByIdAsync(int id);
    Task AddAsync(Encontro entity);
    Task UpdateAsync(Encontro entity);
    Task DeleteAsync(Encontro entity);
}