using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class ContactForm
    {
        public int Id { get; set; }
        [EmailAdress]
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }

    internal class EmailAdressAttribute : Attribute
    {
    }
}