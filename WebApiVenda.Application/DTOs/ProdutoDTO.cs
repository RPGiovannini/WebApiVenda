using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiVenda.Application.DTOs
{
    public class ProdutoDTO
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "O descricao do produto é obrigatório")]
        [MinLength(3)]
        [MaxLength(250)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe o preço")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O estoque é obrigatório")]
        [Range(0, 9999)]
        public decimal Estoque { get; set; }

        [Required(ErrorMessage = "Informe a data do cadastro")]
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
    }
}
