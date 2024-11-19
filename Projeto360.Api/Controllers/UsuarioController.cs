using Microsoft.AspNetCore.Mvc;
using Projeto360.Dominio.Entidades;
using Projeto360.Api.Models.Requisicao;
using Projeto360.Api.Models.Resposta;
using Projeto360.Aplicacao;
using Microsoft.EntityFrameworkCore.Storage;
using System.Windows.Markup;
using Projeto360.Dominio.Enumeradores;

namespace Projeto360.Api
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAplicacao _usuarioAplicacao;

        public UsuarioController(IUsuarioAplicacao usuarioAplicacao)
        {
            _usuarioAplicacao = usuarioAplicacao;
        }

        [HttpPost]
        [Route("Criar")]
        public async Task<ActionResult> CriarAsync([FromBody] UsuarioCriar usuarioCriar )
        {
            try
            {
                var usuarioDominio = new Usuario()
                {
                    Nome = usuarioCriar.Nome,
                    Email = usuarioCriar.Email,
                    Senha = usuarioCriar.Senha,
                    TipoDeUsuario = usuarioCriar.Tipo
                };

                var usuarioId = await _usuarioAplicacao.CriarAsync(usuarioDominio);

                return Ok(usuarioId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Obter/{usuarioId}")]
        public async Task<ActionResult> ObterAsync([FromRoute] int usuarioId)
        {
            try
            {
                var usuarioDominio = await _usuarioAplicacao.ObterAsync(usuarioId);

                var usuarioResposta = new UsuarioResposta()
                {
                    Id = usuarioDominio.Id,
                    Nome = usuarioDominio.Nome,
                    Email = usuarioDominio.Email,
                    Tipo = usuarioDominio.TipoDeUsuario
                };

                return Ok(usuarioResposta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<ActionResult> AtualizarAsync([FromBody] UsuarioAtualizar usuarioAtualizar)
        {
            try
            {
                var usuarioDominio = new Usuario()
                {
                    Id = usuarioAtualizar.Id,
                    Nome = usuarioAtualizar.Nome,
                    Email = usuarioAtualizar.Email,
                    TipoDeUsuario = usuarioAtualizar.Tipo
                };

                await _usuarioAplicacao.AtualizarAsync(usuarioDominio);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("AlterarSenha")]
        public async Task<ActionResult> AlterarSenhaAsync([FromBody] UsuarioAlterarSenha usuarioAlterarSenha)
        {
            try
            {
                var usuarioDominio = new Usuario()
                {
                    Id = usuarioAlterarSenha.Id,
                    Senha = usuarioAlterarSenha.Senha
                };

                await _usuarioAplicacao.AlterarSenhaAsync(usuarioDominio, usuarioAlterarSenha.SenhaAntiga);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Deletar/{usuarioId}")]
        public async Task<ActionResult> DeletarAsync([FromRoute] int usuarioId)
        {
            try
            {
                await _usuarioAplicacao.DeletarAsync(usuarioId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Restaurar/{usuarioId}")]
        public async Task<ActionResult> RestaurarAsync([FromRoute] int usuarioId)
        {
            try
            {
                await _usuarioAplicacao.RestaurarAsync(usuarioId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult> ListAsync()
        {
            try
            {
                var usuariosDominio = await _usuarioAplicacao.ListarAsync();

                var usuarios = usuariosDominio.Select(usuario => new UsuarioResposta()
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    Tipo = usuario.TipoDeUsuario
                }).ToList();

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ListarTipoUsuario")]
        public ActionResult ListarTipoUsuario()
        {
            try
            {
                var valores = _usuarioAplicacao.ListarValorUsuario();
                var nomes = _usuarioAplicacao.ListarNomeUsuario();

                var TiposUsuarios = new List<Object>();

                for (int i = 0; i < valores.Count(); i++)
                {
                    var usuario = new
                    {
                        Id = valores[i],
                        Nome = nomes[i]
                    };
                    TiposUsuarios.Add(usuario);
                }

                return Ok(TiposUsuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}