using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiVenda.Application.DTOs
{
    public class ClienteDTO
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Nome do cliente obrigatorio")]
        [MinLength(3)]
        [MaxLength(250)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe a data do cadastro")]
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

    }
}
