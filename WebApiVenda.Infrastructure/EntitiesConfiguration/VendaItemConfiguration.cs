using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiVenda.Domain.Entities;

namespace WebApiVenda.Infrastructure.EntitiesConfiguration
{
    public class VendaItemConfiguration : IEntityTypeConfiguration<VendaItem>
    {
        public void Configure(EntityTypeBuilder<VendaItem> builder)
        {
            builder.HasKey(vi => vi.Id);

            builder.Property(vi => vi.Quantidade)
                .IsRequired();

            builder.Property(vi => vi.PrecoUnitario)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.HasOne(vi => vi.Venda)
                .WithMany(v => v.VendaItems)
                .HasForeignKey(vi => vi.IdVenda);

            builder.HasOne(vi => vi.Produto)
                .WithMany(p => p.VendaItems)
                .HasForeignKey(vi => vi.IdProduto);
        }
    }
}
