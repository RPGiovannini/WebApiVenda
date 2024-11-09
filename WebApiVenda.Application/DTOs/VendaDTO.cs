using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiVenda.Application.DTOs
{
    public class VendaDTO
    {
        public long Id { get; set; }
        public long IdCliente { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal ValorTotal { get; set; }
        public int Status { get; set; }
        public ClienteDTO? Cliente { get; set; }

    }
}
