using System;
using System.Collections.Generic;


namespace Training.Domain
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Classificacao { get; set; }
        public DateTime? DataCadastro { get; set; }
        public string TempoDuracao { get; set; }
        public string Imagem { get; set; }
        public int CategoriaId { get; set; }
        public Categoria categoria { get; set; }

        public virtual ICollection<Aula> Aulas { get; set; }
    }
}