using Projeto360.Dominio.Enumeradores;

namespace Projeto360.Api.Models.Resposta
{
    public class UsuarioResposta
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public TipoUsuario Tipo { get; set; }
    }
}