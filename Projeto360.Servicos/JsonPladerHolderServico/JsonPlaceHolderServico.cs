using Newtonsoft.Json;
using Projeto360.Dominio.Entidades;
using Projeto360.Servicos.Interfaces;
using Projeto360.Servicos.JsonPlaceHolderServico.Models;

public class JsonPlaceHolderServico : IJsonPlaceHolderServico
{
    private readonly HttpClient _httpClient;

    public JsonPlaceHolderServico()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
    }

    public async Task<List<Tarefa>> ListarTarefas()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("todos");
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        var todos = JsonConvert.DeserializeObject<List<Todo>>(responseBody);

        var tarefas = todos.Select(todo => new Tarefa
        {
            Id = todo.Id,
            Nome = todo.Title,
            Completa = todo.Completed
        }).ToList();

        return tarefas;
    }
}