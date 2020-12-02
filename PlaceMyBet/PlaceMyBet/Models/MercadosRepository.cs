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
    public class MercadosRepository
    {
        internal List<Mercado> Retrieve()
        {
        

                List<Mercado> mercados = new List<Mercado>();
                using (PlaceMyBetContext context = new PlaceMyBetContext())
                {
                mercados = context.Mercados.Include(p => p.Evento).ToList();
                }

                return mercados;
            
        }
        internal   void Save(Mercado mercado)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            context.Mercados.Add(mercado);
            context.SaveChanges();
        }
        internal Mercado Retrieve(int id)
        {
            Mercado mercado;        
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercado = context.Mercados.Where(m => m.MercadoId == id).FirstOrDefault();

            }
            return mercado;

        }
    

        internal List<MercadoDTO> RetrieveDTO()
        {
            return null;
        }


    }
}