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
        public DbSet<Commons> Commons { get; set; }
        public DbSet<Senate> Senate { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Update> Updates { get; set; }
    }

    public class Update
    {
        public int UpdateID { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Response { get; set; }
    }
}