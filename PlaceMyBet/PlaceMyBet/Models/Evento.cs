using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Evento
    {
        public int idEventos { get; set; }
        public String nombreEquipos { get; set; }
        public int visitantes { get; set; }
        public DateTime fechaEventos { get; set; }

        public Evento(int idEventos, string nombreEquipos, int visitantes, DateTime fechaEventos)
        {
            this.idEventos = idEventos;
            this.nombreEquipos = nombreEquipos;
            this.visitantes = visitantes;
            this.fechaEventos = fechaEventos;
        }
    }
}