using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Usuario
    {
        public String UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public List<Apuesta> Apuestas { get; set; }
        public Cuenta Cuentas { get; set; }

        public Usuario() { }

        public Usuario(String email, string nombre, string apellido, int edad)
        {
            UsuarioId = email;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
        }
        /*
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
        }*/
    }
}