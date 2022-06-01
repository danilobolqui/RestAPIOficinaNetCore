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
    public class VeiculoModeloConfig : IEntityTypeConfiguration<VeiculoModelo>
    {
        public void Configure(EntityTypeBuilder<VeiculoModelo> builder)
        {
            builder.ToTable("VeiculoModelo");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Status).IsRequired();
            builder.Property(p => p.Nome).IsRequired();
            builder.Property(p => p.IdVeiculoFabricante).IsRequired();

            //FK veículo fabricante.
            builder
                .HasOne(p => p.VeiculoFabricante)
                .WithMany(p => p.VeiculoModelos)
                .HasForeignKey(p => p.IdVeiculoFabricante);
        }
    }
}
