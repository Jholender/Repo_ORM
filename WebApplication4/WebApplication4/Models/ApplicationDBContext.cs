using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class ApplicationDBContext : DbContext
    {



        public ApplicationDBContext() : base("ContactForm")
        {

        }
        public DbSet<ContactForm> Zadanie { get; set; }
    }
}

