using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class ApuestasRepository
    {
        internal List<Apuesta> Retrieve()
        {
            List<Apuesta> apuestas = new List<Apuesta>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
               
                apuestas = context.Apuestas.Include(m=>m.Mercado).ToList();
            }
            return apuestas;
        }

        internal Apuesta Retrieve(int id)
        {
            Apuesta apuesta;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuesta = context.Apuestas.Where(a => a.ApuestaId == id).FirstOrDefault();
            }
            return apuesta;
        }

        internal List<ApuestaDTOdro> RetrieveDTO(double dineroApostado)
        {
            List<Apuesta> apuestas = new List<Apuesta>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuestas = context.Apuestas.Where(a=>a.DineroApostado==dineroApostado).ToList();

            }

            List<ApuestaDTOdro> apuestas1 = new List<ApuestaDTOdro>();

            foreach (var apuesta in apuestas)
            {
                apuestas1.Add(ToDTO(apuesta));

            } 
            return apuestas1;
        }

      public ApuestaDTOdro ToDTO(Apuesta a)
        {
    

            Mercado mercado;
            Evento evento;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercado = context.Mercados.Where(m => m.MercadoId == a.MercadoId).FirstOrDefault();
                evento = context.Eventos.Where(e => e.EventoId == mercado.EventoId).FirstOrDefault();
            }

          return new ApuestaDTOdro(a.TipoApuesta,evento.NombreEquipo,evento.Visitante);
        }

        internal void Save(Apuesta apuesta)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            Mercado mercado;
            int id = apuesta.MercadoId;
            using (PlaceMyBetContext context1 = new PlaceMyBetContext())
            {
                mercado = context1.Mercados.Where(m => m.MercadoId == id).FirstOrDefault();
                if (apuesta.TipoApuesta == true)
                {
                    apuesta.Cuota = mercado.CuotaOver;
                    mercado.DineroOver += apuesta.DineroApostado;
                }
                else 
                {
                    apuesta.Cuota = mercado.CuotaUnder;
                    mercado.DineroUnder += apuesta.DineroApostado;
                }

                double probOver = mercado.DineroUnder / (mercado.DineroOver + mercado.DineroUnder);
                mercado.CuotaUnder = 1 / probOver * 0.95;
                double probUnder = mercado.DineroOver / (mercado.DineroOver + mercado.DineroUnder);
                mercado.CuotaOver = 1 / probUnder * 0.95;
                context1.Mercados.Update(mercado);
                context.Apuestas.Add(apuesta);
                context.SaveChanges();
                context1.SaveChanges();
            }


        }





    }
}