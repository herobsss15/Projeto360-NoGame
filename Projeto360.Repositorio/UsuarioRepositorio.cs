using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Projeto360.Dominio.Entidades;
using Projeto360.Dominio.Enumeradores;

namespace DataAccess.Repositorio
{
    public class UsuarioRepositorio : BaseRepositorio, IUsuarioRepositorio
    {
        public UsuarioRepositorio(Projeto360Contexto contexto) : base(contexto)
        {
        }

        public async Task<int> SalvarAsync(Usuario usuario)
        {
            _contexto.Usuarios.Add(usuario);
            await _contexto.SaveChangesAsync();

            return usuario.Id;
        }

        public async Task AtualizarAsync(Usuario usuario)
        {
            _contexto.Usuarios.Update(usuario);
            await _contexto.SaveChangesAsync();
        }

        public async Task<Usuario> ObterAsync(int usuarioId)
        {
            return await _contexto.Usuarios
                        .Where(usuario => usuario.Id == usuarioId)
                        .Where(usuario => usuario.Ativo == true)
                        .FirstOrDefaultAsync();
        }

        public async Task<Usuario> ObterDesativadoAsync(int usuarioId)
        {
            return await _contexto.Usuarios
                        .Where(usuario => usuario.Id == usuarioId)
                        .Where(usuario => usuario.Ativo == false)
                        .FirstOrDefaultAsync();
        }

        public async Task<Usuario> ObterPorEmailAsync(string email)
        {
            return await _contexto.Usuarios
                        .Where(usuario => usuario.Email == email)
                        .Where(usuario => usuario.Ativo == true)
                        .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Usuario>> ListarAsync()
        {
            return await _contexto.Usuarios.Where(usuario => usuario.Ativo == true).ToListAsync();
        }
    }
}