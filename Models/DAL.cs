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
        public DbSet<CommonsSession> CommonsSessions { get; set; }
        public DbSet<Senate> Senate { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Ballot> Ballots { get; set; }
        public DbSet<VoteHistory> Hansard { get; set; }
        public DbSet<Update> Updates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Legislation>()
                        .HasRequired(s => s.Stage)
                        .WithRequiredPrincipal();

            modelBuilder.Entity<Stage>()
                        .HasOptional(b => b.BallotsCast)
                        .WithRequired();

            modelBuilder.Entity<VoteHistory>()
                        .HasOptional(b => b.BallotsCasted)
                        .WithOptionalPrincipal();

            modelBuilder.Entity<Role>()
                        .HasMany(m => m.WithMembers)
                        .WithMany();
        }
    
    }
    
    public class Update
    {
        public int UpdateID { get; set; }

        public DateTime UpdateTime { get; set; }

        public string Response { get; set; }
    }
}