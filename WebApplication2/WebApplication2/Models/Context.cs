﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Context : DbContext
    {
        public Context():base("prod")
        {

        }
        public DbSet<ZadanieDB> Zadanie { get; set; }
    }
}