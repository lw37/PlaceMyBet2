using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Mercado
    {
        public int MercadoId { get; set; }
        public double TipoMercado { get; set; }
        public double CuotaOver { get; set; }
        public double CuotaUnder { get; set; }
        public double DineroOver { get; set; }
        public double DineroUnder { get; set; }
        public int EventoId { get; set; }
        public Evento Evento{ get; set; }
        public List<Apuesta> Apuesta { get; set; }

        public Mercado() { }

        public Mercado(int idMercados, double tipoMercados,  double cuotaOver, double cuotaUnder, double dineroOver, double dineroUnder,int idEventos)
        {
            MercadoId = idMercados;
            TipoMercado = tipoMercados;
            CuotaOver = cuotaOver;
            CuotaUnder = cuotaUnder;
            DineroOver = dineroOver;
            DineroUnder = dineroUnder;
            EventoId = idEventos;
        }
        /*
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
        }*/
    }
    public class MercadoDTO
    {

        public double tipoMercados { get; set; }
        public double cuotaOver { get; set; }
        public double cuotaUnder { get; set; }


        public MercadoDTO( double tipoMercados, double cuotaOver, double cuotaUnder)
        {
            this.tipoMercados = tipoMercados;
            this.cuotaOver = cuotaOver;
            this.cuotaUnder = cuotaUnder;
           
        }
    }
}