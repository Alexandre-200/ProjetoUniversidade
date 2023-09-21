using DDD.Domain.SecretariaContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.UserManagementContext
{
    public class User
    {
        public int UserId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }


        public string Email { get; set; }


        public DateTime DataCadastro { get; set; }


        public bool Ativo { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}
