using Projeto360.Dominio.Entidades;
using Projeto360.Dominio.Enumeradores;

namespace Projeto360.Aplicacao
{
    public interface IUsuarioAplicacao
    {
        Task<int> CriarAsync(Usuario usuario);
        Task AtualizarAsync(Usuario usuario);
        Task AlterarSenhaAsync(Usuario usuario, string senhaAntiga);
        Task DeletarAsync(int usuarioId);
        Task RestaurarAsync(int usuarioId);
        Task<Usuario> ObterAsync(int usuarioId);
        Task<Usuario> ObterPorEmailAsync(string email);
        Task<IEnumerable<Usuario>> ListarAsync();
        List<int> ListarValorUsuario();
        List<string> ListarNomeUsuario();
    }
}