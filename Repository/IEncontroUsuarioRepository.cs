public interface IEncontroUsuarioRepository
{
    Task<List<EncontroUsuario>> GetAllAsync();
    Task<EncontroUsuario> GetByIdAsync(int userId, int meetingId);
    Task AddAsync(EncontroUsuario entity);
    Task UpdateAsync(EncontroUsuario entity);
    Task DeleteAsync(EncontroUsuario entity);
}