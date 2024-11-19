using Microsoft.AspNetCore.Mvc;
using Projeto360.Aplicacao;
using Projeto360.Api.Models.Tarefas.Resposta;

namespace Projeto360.Api
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaAplicacao _tarefaAplicacao;

        public TarefaController(ITarefaAplicacao tarefaAplicacao)
        {
            _tarefaAplicacao = tarefaAplicacao;
        }


        [HttpGet]
        [Route("Listar")]
        public ActionResult Listar()
        {
            try
            {
                var tarefas =  _tarefaAplicacao.ListarTarefa();

                var tarefasResposta = tarefas.Select(tarefa => new TarefaResposta
                {
                    Id = tarefa.Id,
                    Nome = tarefa.Nome,
                    Completa = tarefa.Completa
                });

                return Ok(tarefasResposta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}