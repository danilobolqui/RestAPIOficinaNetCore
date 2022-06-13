using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIOficina.Data.Context
{
    public class WebAPIOficinaDbContext : DbContext
    {
        public WebAPIOficinaDbContext(DbContextOptions<WebAPIOficinaDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuração das entidades por reflection.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebAPIOficinaDbContext).Assembly);

            //Chama base.
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Configura lazy loading para este contexto.
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
