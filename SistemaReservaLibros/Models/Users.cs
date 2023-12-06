using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SistemaReservaLibros.Models
{
    [DataContract]
    public class Users
    {
        [DataMember]
        public int idUser { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string password { get; set; }
        [DataMember]
        public bool status { get; set; }

    }
}