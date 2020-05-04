using System.Collections.Generic;

namespace Backend.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public int EscolaId { get; internal set; }
        public Escola Escola { get; set; }
        public List<Aluno> Alunos { get; set; }
    }
}