using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApiVenda.Application.DTOs
{
    public class VendaItemDTO
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Id da venda é obrigatorio")]
        public long IdVenda { get; set; }
        [Required(ErrorMessage = "Id do produto é obrigatorio")]
        public long IdProduto { get; set; }
        [Required(ErrorMessage = "Quantidade é obrigatorio")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantidade { get; set; }
        [Required(ErrorMessage = "Id da finalizadora é obrigatorio")]
        public int IdFinalizadora { get; set; }
        [Required(ErrorMessage = "Preço unitario é obrigatorio")]
        [Column(TypeName = "decimal(18,2)")]
        [JsonIgnore]
        public decimal PrecoUnitario { get; set; }
        [Required(ErrorMessage = "Informe a data do cadastro")]
        public DateTime DataCadastro { get; set; }
        [Required(ErrorMessage = "Informe se o item está ativo")]
        public bool Ativo { get; set; }
    }
}
