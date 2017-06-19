using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using MyCarClassifieds.Models;
using System.Web;

namespace MyCarClassifieds.db
{
    public class AppDbContext : DbContext
    {
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleFeature> VehicleFeatures { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleFeature>().HasKey(vf =>
            new
            {
                vf.VehicleId,
                vf.FeatureId
            });

            base.OnModelCreating(modelBuilder);
        }


        public AppDbContext() : base(HttpRuntime.AppDomainAppPath + @"\db\MyCarClassifiedsDB.sdf")
        {
            
        }
    }
}
