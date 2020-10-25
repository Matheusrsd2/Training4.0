using System;
using System.Collections.Generic;

namespace Training.Domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Profissao { get; set; }
        public string Cpf { get; set; }

	    public enum TipoUsuario 
        {
            Aluno,
            Instrutor,
            Empresa ,
        };
        public string NumeroCartao { get; set; }
        public string CodigoCartao { get; set; }
        public DateTime DataNascimento { get; set; }
        public List <UsuarioCurso> UsuariosCursos { get; set; }
    }
}