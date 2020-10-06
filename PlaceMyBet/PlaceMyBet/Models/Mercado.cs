using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Mercado
    {
        public int idMercados { get; set; }
        public double tipoMercados { get; set; }
        public int idEventos { get; set; }
        public double cuotaOver { get; set; }
        public double cuotaUnder { get; set; }
        public double dineroOver { get; set; }
        public double dineroUnder { get; set; }

        public Mercado(int idMercados, double tipoMercados, int idEventos, double cuotaOver, double cuotaUnder, double dineroOver, double dineroUnder)
        {
            this.idMercados = idMercados;
            this.tipoMercados = tipoMercados;
            this.idEventos = idEventos;
            this.cuotaOver = cuotaOver;
            this.cuotaUnder = cuotaUnder;
            this.dineroOver = dineroOver;
            this.dineroUnder = dineroUnder;
        }
    }
}