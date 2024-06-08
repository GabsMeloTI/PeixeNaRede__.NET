public interface ICapturaRepository
{
    Task<List<Captura>> GetAllAsync();
    Task<Captura> GetByIdAsync(int id);
    Task AddAsync(Captura entity);
    Task UpdateAsync(Captura entity);
    Task DeleteAsync(Captura entity);
}