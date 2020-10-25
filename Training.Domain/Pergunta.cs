using System.Collections.Generic;

namespace Training.Domain
{
    public class Pergunta
    {
        public int Id { get; set; }
        public string TextoResposta { get; set; }
        public string Imagem1 { get; set; }
        public string Imagem2 { get; set; }
        public string Imagem3 { get; set; }
        public int? AulaId { get; set; }
        public Aula Aula { get; set; }
        public int? UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public List<Resposta> Respostas {get; set; }
    }
}