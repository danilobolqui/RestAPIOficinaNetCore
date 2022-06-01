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
    public class TipoPessoaConfig : IEntityTypeConfiguration<TipoPessoa>
    {
        public void Configure(EntityTypeBuilder<TipoPessoa> builder)
        {
            builder.ToTable("TipoPessoa");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Descricao).IsRequired();
            builder.Property(p => p.Status).IsRequired();
        }
    }
}
