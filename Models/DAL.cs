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

    }
}