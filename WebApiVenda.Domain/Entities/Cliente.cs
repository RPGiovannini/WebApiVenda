using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiVenda.Domain.Validation;

namespace WebApiVenda.Domain.Entities
{
    public class Cliente : Entity
    {
        public Cliente(long id, string nome, DateTime dataCadastro)
        {
            ValidateDomain(nome, dataCadastro);
            Id = id;
        }
        public Cliente()
        {
        }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }

        public ICollection<Venda> Vendas { get; set; }
        private void ValidateDomain(string nome, DateTime dataCadastro)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Descricao invalida");

            Nome = nome;
            DataCadastro = dataCadastro;
        }

    }
}
