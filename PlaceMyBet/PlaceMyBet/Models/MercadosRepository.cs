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

        internal List<Mercado> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercados";
            try
            {
                con.Open();
                MySqlDataReader resultado = command.ExecuteReader();

                Mercado mercado = null;
                List<Mercado> mercados = new List<Mercado>();
                while (resultado.Read())
                {
                    Debug.WriteLine("Recuperado: " + resultado.GetInt32(0) + " " + resultado.GetDouble(1) + " "
                        + resultado.GetInt32(2) + " " + resultado.GetDouble(3) + " " + resultado.GetDouble(4)
                        + " " + resultado.GetDouble(5) + " " + resultado.GetDouble(6));

                    mercado = new Mercado(resultado.GetInt32(0), resultado.GetDouble(1),
                        resultado.GetInt32(2), resultado.GetDouble(3), resultado.GetDouble(4),
                        resultado.GetDouble(5), resultado.GetDouble(6));
                    mercados.Add(mercado);
                }
                con.Close();
                return mercados;
            }
            catch (Exception)
            {

                Debug.WriteLine("Ha ocurrido un error.");
                return null;
            }
        }

        internal List<MercadoDTO> RetrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select tipoMercado,cuotaOver,cuotaUnder from mercados";
            try
            {
                con.Open();
                MySqlDataReader resultado = command.ExecuteReader();

                MercadoDTO mercado = null;
                List<MercadoDTO> mercados = new List<MercadoDTO>();
                while (resultado.Read())
                {
                    Debug.WriteLine("Recuperado: " + resultado.GetDouble(0) + " "
                        + resultado.GetDouble(1) + " " + resultado.GetDouble(2));

                    mercado = new MercadoDTO( resultado.GetDouble(0), resultado.GetDouble(1), resultado.GetDouble(2)
                      );
                    mercados.Add(mercado);
                }
                con.Close();
                return mercados;
            }
            catch (Exception)
            {

                Debug.WriteLine("Ha ocurrido un error.");
                return null;
            }
        }


        internal List<Mercado> RetrieveByMercadoEvento(int idEve,double tpMer)
        {
            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * FROM mercados WHERE id_evento=@A AND tipoMercado=@B";
            command.Parameters.AddWithValue("@A", idEve);
            command.Parameters.AddWithValue("@B", tpMer);
            try
            {
                con.Open();
                MySqlDataReader resultado = command.ExecuteReader();

                Mercado mercado = null;
                List<Mercado> mercados = new List<Mercado>();
                while (resultado.Read())
                {
                    Debug.WriteLine("Recuperado: " + resultado.GetInt32(0) + " " + resultado.GetDouble(1) + " "
                        + resultado.GetInt32(2) + " " + resultado.GetDouble(3) + " " + resultado.GetDouble(4)
                        + " " + resultado.GetDouble(5) + " " + resultado.GetDouble(6));

                    mercado = new Mercado(resultado.GetInt32(0), resultado.GetDouble(1),
                        resultado.GetInt32(2), resultado.GetDouble(3), resultado.GetDouble(4),
                        resultado.GetDouble(5), resultado.GetDouble(6));
                    mercados.Add(mercado);
                }
                con.Close();
                return mercados;
            }
            catch (Exception)
            {

                Debug.WriteLine("Ha ocurrido un error.");
                return null;
            }
        }
    }
}