using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(): base("movie")
         {

        }
        public DbSet<aktorzy> aktorzy { get; set; }
        public DbSet<filmy> filmy { get; set; }
        public DbSet<rezyserzy> rezyserzy { get; set; }
    }
}