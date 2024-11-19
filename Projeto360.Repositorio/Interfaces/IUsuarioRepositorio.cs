using Projeto360.Dominio.Entidades;

public interface IUsuarioRepositorio
{
    Task<int> SalvarAsync(Usuario usuario);
    Task AtualizarAsync(Usuario usuario);
    Task<Usuario> ObterAsync(int usuarioId);
    Task<Usuario> ObterDesativadoAsync(int usuarioId);
    Task<Usuario> ObterPorEmailAsync(string email);
    Task<IEnumerable<Usuario>> ListarAsync();
}