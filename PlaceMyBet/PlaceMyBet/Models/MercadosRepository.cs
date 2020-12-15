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
        internal void Save(Mercado mercado)
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

        public ApuestaDTO ToDTO(Apuesta a)
        {
            
            Usuario usuario;
          
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
               
                usuario = context.Usuarios.Where(u => u.UsuarioId == a.UsuarioId).FirstOrDefault();
            }
            return new ApuestaDTO(a.DineroApostado,a.TipoApuesta, usuario.Nombre);
        }

        internal List<ApuestaDTO> RetrieveDTO(int id)
        {

            List<Apuesta> apuestas = new List<Apuesta>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuestas = context.Apuestas.Where(a => a.MercadoId == id).ToList();
            }

            List<ApuestaDTO> apuestas1 = new List<ApuestaDTO>();

            foreach (var apuesta in apuestas)
            {
                apuestas1.Add(ToDTO(apuesta));
            }





            return apuestas1;
        }


    }
}