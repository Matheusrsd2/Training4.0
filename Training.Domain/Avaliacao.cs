using System;
using System.Collections.Generic;

namespace Training.Domain
{
    public class Avaliacao
    {
        public decimal Nota {get;set;}
        public decimal Media {get;set;}
        public int TotalNotas {get;set; }
        public int CursoId {get;set;}
        public Curso Curso {get; set;}
    }
}
