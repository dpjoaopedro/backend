namespace Backend.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public Turma Turma { get; set; }
        public object TurmaId { get; internal set; }
    }
}