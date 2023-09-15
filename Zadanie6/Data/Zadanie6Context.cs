using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Zadanie6;
using Zadanie6.Models;

namespace Zadanie6.Data
{
    public partial class Zadanie6Context : DbContext
    {
        public Zadanie6Context()
        {
        }

        public Zadanie6Context(DbContextOptions<Zadanie6Context> options)
            : base(options)
        {
        }
        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}

