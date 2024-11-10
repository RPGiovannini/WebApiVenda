using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiVenda.Application.DTOs
{
    public class VendaDTO
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Cliente é obrigatorio")]
        public long IdCliente { get; set; }

        [Required(ErrorMessage = "Informe a data do cadastro")]
        public DateTime DataVenda { get; set; }

        [Required(ErrorMessage = "O valor total da venda")]
        [Range(1, 9999)]
        public decimal ValorVenda { get; set; }

        public int Status { get; set; }
        public bool Ativo { get; set; }

    }
}
