using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Evento
    {
        public int EventoId { get; set; }
        public String NombreEquipo { get; set; }
        public String Visitante { get; set; }
        public DateTime FechaEvento { get; set; }
        public List<Mercado> Mercado { get; set; }

        public Evento() { }

        public Evento(int idEventos, string nombreEquipos, string visitantes, DateTime fechaEventos)
        {
            EventoId = idEventos;
            NombreEquipo = nombreEquipos;
            Visitante = visitantes;
            FechaEvento = fechaEventos;
            //Mercado = mercado;
        }

        /* public int idEventos { get; set; }
         public String nombreEquipos { get; set; }
         public int visitantes { get; set; }
         public DateTime fechaEventos { get; set; }

         public Evento(int idEventos, string nombreEquipos, int visitantes, DateTime fechaEventos)
         {
             this.idEventos = idEventos;
             this.nombreEquipos = nombreEquipos;
             this.visitantes = visitantes;
             this.fechaEventos = fechaEventos;
         }*/
    }

    public class EventoDTO  
    {
        public EventoDTO(string nombreEquipo, string visitante, DateTime fechaEvento)
        {
            NombreEquipo = nombreEquipo;
            Visitante = visitante;
            FechaEvento = fechaEvento;
        }

        public String NombreEquipo { get; set; }
        public String Visitante { get; set; }
        public DateTime FechaEvento { get; set; }
        public List<Mercado> Mercado { get; set; }

    }
}