using System.Collections.Generic;
using System.Threading.Tasks;

public interface IUsuarioRepository
{
    Task<List<Usuario>> ListarTodosAsync();
    Task<Usuario> ObterUmAsync(int id);
    Task<Usuario> SalvarUsuarioAsync(Usuario model);
    Task<Usuario> EditarUsuarioAsync(int id, Usuario model);
    Task<Usuario> ExcluirUsuarioAsync(int id);
    List<Pescaria> ListarTodasPescarias();
}
