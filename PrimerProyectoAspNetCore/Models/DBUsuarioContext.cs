using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerProyectoAspNetCore.Models
{
    public class DBUsuarioContext : DbContext
    {

        public DBUsuarioContext(DbContextOptions<DBUsuarioContext> options) : base(options)
        {

        }

        public DbSet<Usuario> dataUsuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(

                new Usuario
                {
                    id = 1,
                    nombre = "Tiago",
                    email = "tiagoviezzoli@gmail.com",
                    edad = 21
                }
            );
        }

        
    }
}
