using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Context : DbContext
    {
        public Context() : base("uzytki")
        {

        }
        public DbSet<UzytkownicyDB> Zadanie { get; set; }
    }
}