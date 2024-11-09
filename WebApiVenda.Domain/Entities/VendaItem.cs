using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiVenda.Domain.Validation;

namespace WebApiVenda.Domain.Entities
{
    public class VendaItem : Entity
    {
        public VendaItem(long idVenda, long idProduto, decimal quantidade, int idFinalizadora, decimal precoUnitario)
        {
            ValidateDomain(idVenda, idProduto, quantidade, idFinalizadora, precoUnitario);
        }

        public long IdVenda { get; private set; }
        public long IdProduto { get; private set; }
        public decimal Quantidade { get; private set; }
        public int IdFinalizadora { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        private void ValidateDomain(long idVenda, long idProduto, decimal quantidade, int idFinalizadora, decimal precoUnitario)
        {
            DomainExceptionValidation.When(idVenda < 0, "Id da venda invalido");
            DomainExceptionValidation.When(idProduto < 0, "Id do produto invalido");
            DomainExceptionValidation.When(quantidade < 0, "Quantidade invalida");
            DomainExceptionValidation.When(idFinalizadora < 0, "Id da finalizadora invalido");
            DomainExceptionValidation.When(precoUnitario < 0, "Valor unitario invalido");

            IdVenda = idVenda;
            IdProduto = idProduto;
            Quantidade = quantidade;
            IdFinalizadora = idFinalizadora;
            PrecoUnitario = precoUnitario;
        }
        public Venda Venda { get; set; }
        public Produto Produto { get; set; }
    }
}
