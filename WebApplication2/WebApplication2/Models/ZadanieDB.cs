using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class ZadanieDB
    {
        public int Id { get; set; }
        public string Towar { get; set; }
        public DateTime DataWprow { get; set; }
        public DateTime DataModyf { get; set; }
    }

}