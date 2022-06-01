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
    public class VeiculoFabricanteConfig : IEntityTypeConfiguration<VeiculoFabricante>
    {
        public void Configure(EntityTypeBuilder<VeiculoFabricante> builder)
        {
            builder.ToTable("VeiculoFabricante");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Status).IsRequired();
            builder.Property(p => p.Nome).IsRequired();
        }
    }
}
