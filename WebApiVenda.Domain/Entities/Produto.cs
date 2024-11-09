using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiVenda.Domain.Validation;

namespace WebApiVenda.Domain.Entities
{
    public sealed class Produto : Entity
    {
        public Produto(string descricao, decimal preco, decimal estoque, DateTime dataCadastro)
        {
            ValidateDomain(descricao, preco, estoque, dataCadastro);
        }

        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public decimal Estoque { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public bool Ativo { get; set; }
        private void ValidateDomain(string descricao, decimal preco, decimal estoque, DateTime dataCadastro)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(descricao) || descricao.Length<3, "Descricao invalida");
            DomainExceptionValidation.When(preco < 0, "Preço invalido");
            DomainExceptionValidation.When(estoque < 0, "Estoque invalido");

            Descricao = descricao;
            Preco = preco;
            Estoque = estoque;
            DataCadastro = dataCadastro;

        }


    }
}
