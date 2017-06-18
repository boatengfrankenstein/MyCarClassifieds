using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCarClassifieds.Models;

namespace MyCarClassifieds.db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
    }
}
