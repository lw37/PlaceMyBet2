using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Apuesta
    {
        public int ApuestaId { get; set; }
        public bool TipoApuesta { get; set; }
        public double Cuota { get; set; }
        public double DineroApostado { get; set; }
        public DateTime FechaApuesta { get; set; }
        public int MercadoId { get; set; }
        public int UsuarioId { get; set; }

        public Apuesta() { }

        public Apuesta(int idApuestas, bool tipoApuesta, double cuotas, double dineroApostado, DateTime fechaApuestas, int idMercados, int emailUsuarios)
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

    /*
    public int idApuestas { get; set; }
    public int idMercados { get; set; }
    public string emailUsuarios { get; set; }

    public bool tipoApuesta { get; set; }
    public double cuotas { get; set; }
    public double dineroApostado { get; set; }
    public DateTime fechaApuestas { get; set; }

    public Apuesta(int idApuestas, int idMercados, string emailUsuarios, bool tipoApuesta, double cuotas, double dineroApostado, DateTime fechaApuestas)
    {
        this.idApuestas = idApuestas;
        this.idMercados = idMercados;
        this.emailUsuarios = emailUsuarios;

        this.tipoApuesta = tipoApuesta;
        this.cuotas = cuotas;
        this.dineroApostado = dineroApostado;
        this.fechaApuestas = fechaApuestas;
    }*/

    public class ApuestaDTO
{
    public string nombreEquipo { get; set; }
    public string visitante { get; set; }
    public DateTime fechaEvento { get; set; }
    public bool tipoApuesta { get; set; }
    public double cuotas { get; set; }
    public double dineroApostado { get; set; }

    public ApuestaDTO(string nombreEquipo, string visitante, DateTime fechaEvento, bool tipoApuesta, double cuotas, double dineroApostado)
    {
        this.nombreEquipo = nombreEquipo;
        this.visitante = visitante;
        this.fechaEvento = fechaEvento;
        this.tipoApuesta = tipoApuesta;
        this.cuotas = cuotas;
        this.dineroApostado = dineroApostado;
    }
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