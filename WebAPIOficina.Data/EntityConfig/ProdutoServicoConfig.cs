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
    public class ProdutoServicoConfig : IEntityTypeConfiguration<ProdutoServico>
    {
        public void Configure(EntityTypeBuilder<ProdutoServico> builder)
        {
            builder.ToTable("ProdutoServico");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).IsRequired();
            builder.Property(p => p.Produto).IsRequired();
            builder.Property(p => p.Valor).IsRequired().HasColumnType("numeric(10,2)");
            builder.Property(p => p.Status).IsRequired();
        }
    }
}
