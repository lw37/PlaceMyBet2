using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Usuario
    {
        public string email { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int edad { get; set; }

        public Usuario(string email, string nombre, string apellido, int edad)
        {
            this.email = email;
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
        }
    }
}