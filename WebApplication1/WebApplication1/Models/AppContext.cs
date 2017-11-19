using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class AppContext: DbContext
    {
        public AppContext() : base("TEstDB")
        {

        }

        public DbSet<TestDBmodel> TestDBmodels { get; set; }
    }
}