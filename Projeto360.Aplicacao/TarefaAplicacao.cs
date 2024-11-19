using Projeto360.Dominio.Entidades;
using Projeto360.Servicos.Interfaces;
using Projeto360.Servicos.JsonPlaceHolderServico;

namespace Projeto360.Aplicacao
{
    public class TarefaAplicacao : ITarefaAplicacao
    {
        private readonly IJsonPlaceHolderServico _jasonPlaceHolderServico;

        public TarefaAplicacao(IJsonPlaceHolderServico jsonPlaceHolderServico)
        {
            _jasonPlaceHolderServico = jsonPlaceHolderServico;
        }

        public List<Tarefa> ListarTarefa()
        {
           return _jasonPlaceHolderServico.ListarTarefas().Result;
        }
    }
}