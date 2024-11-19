using Projeto360.Dominio.Enumeradores;

namespace Projeto360.Api.Models.Requisicao
{
    public class UsuarioCriar
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public TipoUsuario Tipo { get; set; }
        public string Senha { get; set; }
    }
}