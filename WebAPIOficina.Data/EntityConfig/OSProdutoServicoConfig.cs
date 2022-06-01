using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIOficina.Domain.Models;

namespace WebAPIOficina.Data.EntityConfig
{
    public class OSProdutoServicoConfig : IEntityTypeConfiguration<OSProdutoServico>
    {
        public void Configure(EntityTypeBuilder<OSProdutoServico> builder)
        {
            builder.ToTable("OSProdutoServico");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Valor).IsRequired();
            builder.Property(p => p.Desconto).IsRequired();

            //FK OS.
            builder
                .HasOne(p => p.OrdemServico)
                .WithMany(p => p.OSProdutoServicos)
                .HasForeignKey(p => p.IdOrdemServico);

            //FK Produto Serviço.
            builder
                .HasOne(p => p.ProdutoServico)
                .WithMany(p => p.OSProdutoServicos)
                .HasForeignKey(p => p.IdProdutoServico);
        }
    }
}
