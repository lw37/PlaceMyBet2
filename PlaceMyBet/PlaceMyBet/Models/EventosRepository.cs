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
        private MySqlConnection Connect()
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
        }


        internal List<EventoDTO> RetrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select nombreEquipo,visitante,fechaEvento from eventos";
            try
            {
                con.Open();
                MySqlDataReader resultado = command.ExecuteReader();
                EventoDTO evento = null;
                List<EventoDTO> eventos = new List<EventoDTO>();
                while (resultado.Read())
                {
                    Debug.WriteLine("Recuperado: "
                        + resultado.GetString(0) + " " + resultado.GetString(1) + " " + resultado.GetDateTime(2));
                    evento = new EventoDTO(
                        resultado.GetString(0), resultado.GetString(1), resultado.GetDateTime(2));
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
        }


        internal List<Evento> RetriveByEvento(int idEve, int idMer)
        {
            MySqlConnection con = Connect();
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

        }
    }
}