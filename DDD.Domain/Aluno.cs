
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DDD.Domain
{
    public class Aluno
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }

        
        public string Email { get; set; }

    
        public DateTime DataCadastro { get; set; }

       
        public bool Ativo { get; set; }

        public List<Disciplina> Disciplinas { get; set; }

    }
}
