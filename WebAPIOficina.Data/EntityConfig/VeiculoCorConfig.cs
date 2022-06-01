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
    public class VeiculoCorConfig : IEntityTypeConfiguration<VeiculoCor>
    {
        public void Configure(EntityTypeBuilder<VeiculoCor> builder)
        {
            builder.ToTable("VeiculoCor");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Status).IsRequired();
            builder.Property(p => p.Nome).IsRequired();
        }
    }
}
