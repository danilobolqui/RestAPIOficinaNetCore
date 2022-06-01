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
    public class ClienteVeiculoConfig : IEntityTypeConfiguration<ClienteVeiculo>
    {
        public void Configure(EntityTypeBuilder<ClienteVeiculo> builder)
        {
            builder.ToTable("ClienteVeiculo");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Placa).IsRequired();
            builder.Property(p => p.Ano).IsRequired();
            builder.Property(p => p.Detalhe).IsRequired();
            builder.Property(p => p.Observacao);

            //FK para cliente.
            builder
                .HasOne(p => p.Cliente)
                .WithMany(p => p.ClienteVeiculos)
                .HasForeignKey(p => p.IdCliente);

            //FK para veículo modelo.
            builder
                .HasOne(p => p.VeiculoModelo)
                .WithMany(p => p.ClientesVeiculo)
                .HasForeignKey(p => p.IdVeiculoModelo);
            
            //FK para veículo cor.
            builder
                .HasOne(p => p.VeiculoCor)
                .WithMany(p => p.ClientesVeiculo)
                .HasForeignKey(p => p.IdVeiculoCor);
        }
    }
}
