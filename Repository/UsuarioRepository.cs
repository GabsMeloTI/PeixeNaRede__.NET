using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeixeNaRede.Models;
using Microsoft.EntityFrameworkCore;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly Contexto _contexto;

    public UsuarioRepository(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<List<Usuario>> ListarTodosAsync()
    {
        return await _contexto.Usuario.OrderBy(x => x.CdUsuario).ToListAsync();
    }

    public async Task<Usuario> ObterUmAsync(int id)
    {
        return await _contexto.Usuario.FirstOrDefaultAsync(x => x.CdUsuario == id);
    }

    public async Task<Usuario> SalvarUsuarioAsync(Usuario model)
    {
        _contexto.Usuario.Add(model);
        await _contexto.SaveChangesAsync();
        return model;
    }

    public async Task<Usuario> EditarUsuarioAsync(int id, Usuario model)
    {
        var usuario = await _contexto.Usuario.FirstOrDefaultAsync(x => x.CdUsuario == id);
        if (usuario != null)
        {
            usuario.NmUsuario = model.NmUsuario;
            usuario.DsEmail = model.DsEmail;
            usuario.DsSenha = model.DsSenha;
            usuario.DsTipo = model.DsTipo;
            usuario.DsLocalizacao = model.DsLocalizacao;
            usuario.DsFotoPerfil = model.DsFotoPerfil;
            usuario.CdPescaria = model.CdPescaria;

            await _contexto.SaveChangesAsync();

            return usuario;
        }

        return null;
    }

    public async Task<Usuario> ExcluirUsuarioAsync(int id)
    {
        var usuario = await _contexto.Usuario.FirstOrDefaultAsync(x => x.CdUsuario == id);
        if (usuario != null)
        {
            _contexto.Usuario.Remove(usuario);
            await _contexto.SaveChangesAsync();

            return usuario;
        }

        return null;
    }

    public List<Pescaria> ListarTodasPescarias()
    {
        return _contexto.Pescaria.ToList();
    }
}
