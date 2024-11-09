using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiVenda.Domain.Enums;
using WebApiVenda.Domain.Validation;

namespace WebApiVenda.Domain.Entities
{
    public class Venda : Entity
    {
        public Venda(long idCliente, DateTime dataVenda, decimal valorVenda)
        {
            ValidateDomain(idCliente, dataVenda, valorVenda);
        }
        public DateTime DataVenda { get; set; }
        public decimal ValorVenda { get; set; }
        public int Status { get; set; }


        private void ValidateDomain(long idCliente, DateTime dataVenda, decimal valorVenda)
        {
            DomainExceptionValidation.When(idCliente < 0, "Id do cliente invalido");
            DomainExceptionValidation.When(valorVenda < 0, "Valor da venda invalido");

            IdCliente = idCliente;
            DataVenda = dataVenda;
            ValorVenda = valorVenda;
        }
        public long IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<VendaItem> VendaItems { get; set; }

    }
}
