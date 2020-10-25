namespace Training.Domain
{
    public class Resposta
    {
         public int Id { get; set; }
        public string TextoResposta { get; set; }
        public string Imagem1 { get; set; }
        public string Imagem2 { get; set; }
        public string Imagem3 { get; set; }
        public int? PerguntaId { get; set; }
        public Pergunta Pergunta { get; set; }
        public int? UsuarioId { get; set; }
        public Usuario Usuario { get; set; }


    }
}