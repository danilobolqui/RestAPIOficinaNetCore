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
    public class OrdemServicoConfig : IEntityTypeConfiguration<OrdemServico>
    {
        public void Configure(EntityTypeBuilder<OrdemServico> builder)
        {
            builder.ToTable("OrdemServico");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Defeito);
            builder.Property(p => p.KmEntrada);
            builder.Property(p => p.KmSaida);
            builder.Property(p => p.DataCadastro).IsRequired();
            builder.Property(p => p.DataEntrada).IsRequired();
            builder.Property(p => p.DataSaida);

            //FK para cliente veículo.
            builder
                .HasOne(p => p.ClienteVeiculo)
                .WithMany(p => p.ClienteVeiculosOrdermServico)
                .HasForeignKey(p => p.IdClienteVeiculo);

            //FK para cliente.
            builder
                .HasOne(p => p.ClienteDonoAtual)
                .WithMany(p => p.ClienteDonoAtualOrdemServicos)
                .HasForeignKey(p => p.IdClienteDonoAtual);
        }
    }
}
