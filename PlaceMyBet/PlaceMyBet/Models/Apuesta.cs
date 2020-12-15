using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Apuesta
    {

        //Herramienta->Nuget->Consola    Remove-Migration   add-migration m1 -Context PlaceMyBetContext   update-database -Context PlaceMyBetContext
        public int ApuestaId { get; set; }
        public bool TipoApuesta { get; set; }
        public double Cuota { get; set; }
        public double DineroApostado { get; set; }
        public DateTime FechaApuesta { get; set; }
        public int MercadoId { get; set; }
        public String UsuarioId { get; set; }
        public Usuario Usuario { get; set;}
        public Mercado Mercado { get; set; }

        public Apuesta() { }

        public Apuesta(int idApuestas, bool tipoApuesta, double cuotas, double dineroApostado, DateTime fechaApuestas, int idMercados, String emailUsuarios)
        {
            ApuestaId = idApuestas;
            MercadoId = idMercados;
            UsuarioId = emailUsuarios;
            TipoApuesta = tipoApuesta;
            Cuota = cuotas;
            DineroApostado = dineroApostado;
            FechaApuesta = fechaApuestas;
        }
    }


    public class ApuestaDTO
    {
        public ApuestaDTO(double dineroApostado, bool tipo, string nombre)
        {
            DineroApostado = dineroApostado;
            Tipo = tipo;
            Nombre = nombre;
        }

        public double DineroApostado { get; set; }
        public bool Tipo { get; set; }
        public string Nombre { get; set; }



    }
    public class ApuestaDTOmer
    {
        public ApuestaDTOmer(double tipoMercado, bool tipoApuesta, double cuotas, double dineroApostado)
        {
            this.tipoMercado = tipoMercado;
            this.tipoApuesta = tipoApuesta;
            this.cuotas = cuotas;
            this.dineroApostado = dineroApostado;
        }
        
        public double tipoMercado { get; set; }
        public bool tipoApuesta { get; set; }
        public double cuotas { get; set; }
        public double dineroApostado { get; set; }



    }
    
}