using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TesteBack.Model.Model;

namespace TesteBack.Repository
{
    public class TesteContext : DbContext
    {

        public TesteContext(DbContextOptions<TesteContext> options) : base(options) { }

        public DbSet<Livro> Livro { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }

}

