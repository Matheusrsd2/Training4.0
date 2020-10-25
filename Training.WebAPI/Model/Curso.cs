using System;
using Training.Domain;
using System.Collections.Generic;

namespace Training.WebAPI.Model
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Classificacao { get; set; }
        public DateTime? DataCadastro { get; set; }
        public string Imagem { get; set; }
        public int CategoriaId { get; set; }
        public Categoria categoria { get; set; }
        public List <Aula> Aulas { get; set; }
    }
}