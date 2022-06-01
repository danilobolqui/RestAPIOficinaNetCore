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
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.CpfCnpj).IsRequired();
            builder.Property(p => p.IdTipoPessoa).IsRequired();
            builder.Property(p => p.Nome).IsRequired();
            builder.Property(p => p.Telefone).IsRequired();
            builder.Property(p => p.Status).IsRequired();

            //FK para tipo pessoa.
            builder
                .HasOne(p => p.TipoPessoa)
                .WithMany(p => p.Clientes)
                .HasForeignKey(p => p.IdTipoPessoa);
        }
    }
}
