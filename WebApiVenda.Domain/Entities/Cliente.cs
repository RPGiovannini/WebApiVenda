using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiVenda.Domain.Validation;

namespace WebApiVenda.Domain.Entities
{
    public class Cliente :Entity
    {
        public Cliente (string nome,DateTime dataCadastro) 
        {
            ValidateDomain(nome, dataCadastro);
        }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        private void ValidateDomain(string nome, DateTime dataCadastro) 
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Descricao invalida");
            DomainExceptionValidation.When(dataCadastro < DateTime.Now, "Data de cadastro invalida");

            Nome = nome;
            DataCadastro = dataCadastro;
        }
        public ICollection<Venda> Vendas { get; set; }
    }
}
