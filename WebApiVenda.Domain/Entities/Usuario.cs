using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebApiVenda.Domain.Validation;

namespace WebApiVenda.Domain.Entities
{
    public class Usuario : Entity
    {
        public Usuario(long id, string email, string nome, string senha)
        {
            ValidateDomain(email, nome, senha);
            Id = id;
        }
        public Usuario() { }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }

        private void ValidateDomain(string email, string nome, string senha)
        {
            if (string.IsNullOrWhiteSpace(email) || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                throw new DomainExceptionValidation("Email inválido.");
            }

            if (string.IsNullOrWhiteSpace(senha) || senha.Length < 6)
            {
                throw new DomainExceptionValidation("Senha deve ter pelo menos 6 caracteres.");
            }

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
