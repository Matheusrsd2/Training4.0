using System;
using System.Collections.Generic;

namespace Training.Domain
{
    public class Aula
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string VideoAula { get; set; }
        public DateTime Duracao {get; set; }
        public DateTime DataCadastro {get; set; }
        public int? CursoId { get; set; }
        public Curso Curso { get; set; }
        public List<Pergunta> Perguntas { get; set; }
        
    }
}