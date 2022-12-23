using System;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using backend.Entity;

namespace backend.Models
{

    public class WendyDbContext : DbContext
    {

        private readonly string _connectionString;

        public WendyDbContext(DbContextOptions<WendyDbContext> options)  : base(options)
        {
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        //      optionsBuilder.UseSqlServer(_connectionString);
        // }

        //entities
        public DbSet<Horse> Horse { get; set; }
        public DbSet<Owner> Owner { get; set; }
    }

}