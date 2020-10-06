using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class ApuestasRepository
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

        internal List<Apuesta> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from APUESTAS";
            try
            {
                con.Open();
                MySqlDataReader resultado = command.ExecuteReader();

               Apuesta apuesta = null;
                List<Apuesta> apuestas = new List<Apuesta>();
                while (resultado.Read())
                {
                    Debug.WriteLine("Recuperado: " + resultado.GetInt32(0) + " " + resultado.GetInt32(1) + " "
                        + resultado.GetString(2) + " " + resultado.GetBoolean(3) + " " + resultado.GetDouble(4)
                        + " " + resultado.GetDouble(5) + " " + resultado.GetDateTime(6));

                    apuesta = new Apuesta(resultado.GetInt32(0), resultado.GetInt32(1),
                        resultado.GetString(2), resultado.GetBoolean(3), resultado.GetDouble(4),
                        resultado.GetDouble(5), resultado.GetDateTime(6));
                    apuestas.Add(apuesta);
                }
                con.Close();
                return apuestas;
            }
            catch (Exception)
            {

                Debug.WriteLine("Ha ocurrido un error.");
                return null;
            }
        }

    }
}