using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiVenda.Domain.Entities;

namespace WebApiVenda.Infrastructure.Configurations
{
    public class VendaConfiguration : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.IdCliente)
                .IsRequired();

            builder.Property(v => v.DataVenda)
                .IsRequired();

            builder.Property(v => v.ValorVenda)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(v => v.Status)
                .IsRequired();

            builder.HasOne(v => v.Cliente)
                .WithMany(c => c.Vendas)
                .HasForeignKey(v => v.IdCliente);
        }
    }
}
