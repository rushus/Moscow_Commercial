using Microsoft.EntityFrameworkCore;
using Commercialobj.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Commercialobj.ApplicationServices.Synchronization;
namespace Commercialobj.InfrastructureServices.Gateways.Database
{
    public class CommercialobjContext : DbContext
    {
        public DbSet<commercialobj> Commercialobjs { get; set; }

        public CommercialobjContext(DbContextOptions options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var v = new UseCaseCommercialobj();

            modelBuilder.Entity<commercialobj>().HasData(v.commercialobjs);
        }
    }
}
