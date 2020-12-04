using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class EventosRepository
    {
        /*private MySqlConnection Connect()
        {
            string server = "server=localhost;";
            string port = "port=3306;";
            string database = "database=PlaceMyBet;";
            string usuario = "uid=root;";
            string password = "pwd=;";
            string convert = "Convert Zero Datetime=True;";
            string connectionstring = server + port + database + usuario + password + convert;

            MySqlConnection conexion = new MySqlConnection(connectionstring);
            return conexion;
        }


        internal List<Evento> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from eventos";
            try
            {
                con.Open();
                MySqlDataReader resultado = command.ExecuteReader();
                Evento evento = null;
                List<Evento> eventos = new List<Evento>();
                while (resultado.Read())
                {
                    Debug.WriteLine("Recuperado: " + resultado.GetInt32(0) + " " + resultado.GetString(1) + " "
                        + resultado.GetInt32(2) + " " + resultado.GetDateTime(3));
                    evento = new Evento(resultado.GetInt32(0), resultado.GetString(1),
                        resultado.GetInt32(2), resultado.GetDateTime(3));
                    eventos.Add(evento);
                }
                con.Close();
                return eventos;
            }
            catch (Exception)
            {
                Debug.WriteLine("Ha ocurrido un error.");
                return null;
            }
        }*/
        internal List<Evento> Retrieve()
        {

            List<Evento> eventos = new List<Evento>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                eventos = context.Eventos.ToList();
            }
            return eventos;
        }
        public EventoDTO ToDTO(Evento e)
        {
            return new EventoDTO(e.NombreEquipo, e.Visitante,e.FechaEvento);
        }


        internal List<EventoDTO> RetrieveDTO()
        {
            List<Evento> eventos = new List<Evento>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                eventos = context.Eventos.ToList();
            }
            
            List<EventoDTO> eventos1 = new List<EventoDTO>();

            foreach (var evento in eventos)
            {
                eventos1.Add(ToDTO(evento));
            }
            return eventos1;

        }

        internal void save(Evento evento)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            context.Eventos.Add(evento);
            context.SaveChanges();
        }

        internal void Delete(int id)
        {
            Evento evento;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                evento = context.Eventos.Where(e => e.EventoId == id).FirstOrDefault();
                context.Eventos.Remove(evento);
                context.SaveChanges();

            }

        }
        internal void Update(int id,Evento evento1) {
            Evento evento;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                evento = context.Eventos.Where(e => e.EventoId == id).FirstOrDefault();
                evento.NombreEquipo = evento1.NombreEquipo;
                evento.Visitante = evento1.Visitante;

                context.Eventos.Update(evento);
                context.SaveChanges();

            }

        }




        internal List<Evento> RetriveByEvento(int idEve, int idMer)
        {
           
            return null;
        }
 /*MySqlConnection con = Connect();
             MySqlCommand command = con.CreateCommand();
             command.CommandText = "SELECT * FROM mercados WHERE id_evento=@A AND tipoMercado=@B";
             command.Parameters.AddWithValue("@A", idEve);
             command.Parameters.AddWithValue("@B", idMer);
             try
             {
                 con.Open();
                 MySqlDataReader resultado = command.ExecuteReader();

                 Evento evento = null;
                 List<Evento> eventos = new List<Evento>();
                 while (resultado.Read())
                 {
                     Debug.WriteLine("Recuperado: " + resultado.GetInt32(0) + " " + resultado.GetString(1) + " "
                         + resultado.GetInt32(2) + " " + resultado.GetDateTime(3));
                     evento = new Evento(resultado.GetInt32(0), resultado.GetString(1),
                         resultado.GetInt32(2), resultado.GetDateTime(3));
                     eventos.Add(evento);
                 }
                 con.Close();
                 return eventos;
             }
             catch (Exception)
             {
                 Debug.WriteLine("Ha ocurrido un error.");
                 return null;
             }
             */
    }
}