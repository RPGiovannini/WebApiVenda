using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiVenda.Domain.Entities
{
    public class Usuario : Entity
    {
        public Usuario(string email, string nome,string senha)
        {
            ValidateDomain(email,nome,senha);
        }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }

        private void ValidateDomain(string email, string nome, string senha) 
        {

            //adicionar as validacoes
            Email = email;
            Nome = nome;
            Senha = senha;
        }
        public bool ValidatePassword(string senha)
        {
            return Senha == senha;
        }
    }
}
