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

        internal List<ApuestaDTO> RetrieveDTO()
        {
            List<Apuesta> apuestas = new List<Apuesta>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuestas = context.Apuestas.Include(m => m.Mercado).ToList();

            }

            List<ApuestaDTO> apuestas1 = new List<ApuestaDTO>();

            foreach (var apuesta in apuestas)
            {
                apuestas1.Add(ToDTO(apuesta));

            }
            return apuestas1;
        }

        public ApuestaDTO ToDTO(Apuesta a)
        {
    

            Mercado mercado;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercado = context.Mercados.Where(m => m.MercadoId == a.MercadoId).FirstOrDefault();

            }

            return new ApuestaDTO(a.UsuarioId,mercado.EventoId,a.TipoApuesta,a.Cuota,a.DineroApostado);
        }

        internal void Save(Apuesta apuesta)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            context.Apuestas.Add(apuesta);
            
            Mercado mercado;
            int id = apuesta.MercadoId;
            using (PlaceMyBetContext context1 = new PlaceMyBetContext())
            {
                mercado = context1.Mercados.Where(m => m.MercadoId == id).FirstOrDefault();
                if (apuesta.TipoApuesta == true)
                {
                    apuesta.Cuota = mercado.CuotaOver;
                    mercado.DineroOver += apuesta.DineroApostado;
                    double prob = mercado.DineroOver / (mercado.DineroOver + mercado.DineroUnder);
                    mercado.CuotaOver = 1 / prob * 0.95;
                   
                }
                else 
                {
                    apuesta.Cuota = mercado.CuotaUnder;
                    mercado.DineroUnder += apuesta.DineroApostado;
                    double prob = mercado.DineroUnder / (mercado.DineroOver + mercado.DineroUnder); 
                    mercado.CuotaUnder = 1 / prob * 0.95;
                  
                }
                
                context1.Mercados.Update(mercado);
                context.SaveChanges();
                context1.SaveChanges();
            }


        }





    }
}