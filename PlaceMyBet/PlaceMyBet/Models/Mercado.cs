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
       
    }
    public class MercadoDTO
    {
        public MercadoDTO(double tipoMercado, double cuotaOver, double cuotaUnder)
        {
            TipoMercado = tipoMercado;
            CuotaOver = cuotaOver;
            CuotaUnder = cuotaUnder;
        }

        public double TipoMercado { get; set; }
        public double CuotaOver { get; set; }
        public double CuotaUnder { get; set; }


    }
}