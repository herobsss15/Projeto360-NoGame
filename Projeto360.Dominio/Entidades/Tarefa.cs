namespace Projeto360.Dominio.Entidades
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Completa { get; set; }

        public Tarefa()
        {
            Completa = true;
        }
    }
}