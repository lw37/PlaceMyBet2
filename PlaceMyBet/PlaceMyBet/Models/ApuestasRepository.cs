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

            return new ApuestaDTO(a.UsuarioId,mercado.EventoId,a.TipoApuesta,a.Cuota,a.DineroApostado,a.Mercado);
        }

        internal void Save(Apuesta apuesta)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            context.Apuestas.Add(apuesta);
            context.SaveChanges();
            Mercado mercado;
            int id = apuesta.MercadoId;
            using (PlaceMyBetContext context1 = new PlaceMyBetContext())
            {
                mercado = context1.Mercados.Where(m => m.MercadoId == id).FirstOrDefault();
                if (apuesta.TipoApuesta == true)
                {
                    mercado.DineroOver += apuesta.DineroApostado;
                    double prob = mercado.DineroOver / (mercado.DineroOver + mercado.DineroUnder);
                    mercado.CuotaOver = 1 / prob * 0.95;
                }
                else 
                {
                    mercado.DineroUnder += apuesta.DineroApostado;
                    double prob = mercado.DineroUnder / (mercado.DineroOver + mercado.DineroUnder); 
                    mercado.CuotaUnder = 1 / prob * 0.95;
                }

                context1.SaveChanges();
            }


        }

        public void Comas()
        {
            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;
        }

        public double Probabilidad(Apuesta apu)
        {
           
            return 0;
        }
 
        internal void Insertar(Apuesta a)
        {

        }

        
    }
}