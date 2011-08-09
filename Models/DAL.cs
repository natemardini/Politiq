using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Politiq.Models.ObjectModel;

namespace Politiq.Models
{
    public class DAL : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Legislation> Legislations { get; set; }
        public DbSet<Provision> Provisions { get; set; }
        public DbSet<OiC> OiCs { get; set; }
        public DbSet<LegislativeSession> LegislativeSessions { get; set; }
        //public DbSet<Enactment> Enactments { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Provision>().HasRequired(p => p.Enactment).WithRequiredPrincipal();
        //}
    }
}