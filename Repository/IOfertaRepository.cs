public interface IOfertaRepository
{
    Task<List<Oferta>> GetAllAsync();
    Task<Oferta> GetByIdAsync(int id);
    Task AddAsync(Oferta entity);
    Task UpdateAsync(Oferta entity);
    Task DeleteAsync(Oferta entity);
}