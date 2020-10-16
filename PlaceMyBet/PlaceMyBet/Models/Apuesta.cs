using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Apuesta
    {
        public int idApuestas { get; set; }
        public int idMercados { get; set; }
        public string emailUsuarios { get; set; }
        public double tipoMercado { get; set; }
        public bool tipoApuesta { get; set; }
        public double cuotas { get; set; }
        public double dineroApostado { get; set; }
        public DateTime fechaApuestas { get; set; }

        public Apuesta(int idApuestas, int idMercados, string emailUsuarios, double tipoMercado, bool tipoApuesta, double cuotas, double dineroApostado, DateTime fechaApuestas)
        {
            this.idApuestas = idApuestas;
            this.idMercados = idMercados;
            this.emailUsuarios = emailUsuarios;
            this.tipoMercado = tipoMercado;
            this.tipoApuesta = tipoApuesta;
            this.cuotas = cuotas;
            this.dineroApostado = dineroApostado;
            this.fechaApuestas = fechaApuestas;
        }
    }
        public class ApuestaDTO
        {

            public string emailUsuarios { get; set; }
            public double tipoMercado { get; set; }
            public bool tipoApuesta { get; set; }
            public double cuotas { get; set; }
            public double dineroApostado { get; set; }
            public DateTime fechaApuestas { get; set; }

            public ApuestaDTO(string emailUsuarios,double tipoMercado, bool tipoApuesta, double cuotas, double dineroApostado, DateTime fechaApuestas)
            {
                this.emailUsuarios = emailUsuarios;
                this.tipoMercado = tipoMercado;
                this.tipoApuesta = tipoApuesta;
                this.cuotas = cuotas;
                this.dineroApostado = dineroApostado;
                this.fechaApuestas = fechaApuestas;
            }
        }
    
}