using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaReservaLibros.Models
{
    public class Books
    {
        public int idBook { get; set; }
        public string varTitle { get; set;}
        public string varCode { get; set; }
        public bool bitStatus { get; set; }
        public string dmeDateCreate { get; set; }
        public string dmeDateUpdate { get; set; }
        public string isActive { get; set; }
    }
}