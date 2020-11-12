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
                        resultado.GetString(2) ,resultado.GetBoolean(3), resultado.GetDouble(4),
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
        }*/

        internal List<ApuestaDTO> RetrieveDTObyEmail(string email,double tipoMercado)//utiliza estos para comprobar: luo.luo.ll14@gmail.com y 1.5
        {
            Comas();
            /* MySqlConnection con = Connect();
             MySqlCommand command = con.CreateCommand();
             command.CommandText = "SELECT nombreEquipo,visitante,fechaEvento,tipoapuesta,cuota,dineroapostado FROM apuestas " +
                 "INNER JOIN mercados on apuestas.id_mercado=mercados.idMercado INNER JOIN eventos ON mercados.id_evento=eventos.idEvento" +
                 " WHERE email_usuario=@A AND tipoMercado=@B; ";
             command.Parameters.AddWithValue("@A", email);
             command.Parameters.AddWithValue("@B", tipoMercado);
             try
             {
                 con.Open();
                 MySqlDataReader resultado = command.ExecuteReader();

                 ApuestaDTO apuesta = null;
                 List<ApuestaDTO> apuestas = new List<ApuestaDTO>();
                 while (resultado.Read())
                 {
                     Debug.WriteLine("Recuperado: " + resultado.GetString(0) + " " + resultado.GetString(1) + " " + resultado.GetDateTime(2) + " " + resultado.GetBoolean(3)
                         + " " + resultado.GetDouble(4) + " " + resultado.GetDouble(5));

                     apuesta = new ApuestaDTO(resultado.GetString(0), resultado.GetString(1), resultado.GetDateTime(2), resultado.GetBoolean(3),
                         resultado.GetDouble(4), resultado.GetDouble(5));
                     apuestas.Add(apuesta);
                 }
                 con.Close();
                 return apuestas;
             }
             catch (Exception)
             {

                 Debug.WriteLine("Ha ocurrido un error.");
                 return null;
             }*/
            return null;
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
            /*MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            double prob = 0;
            double dOver = 0;
            double dUnder = 0;
            command.CommandText = "Select dineroOver,dineroUnder from Mercados where idmercado="+apu.idMercados+";";

            try
            {
                con.Open();
                MySqlDataReader resultado = command.ExecuteReader();
                resultado.Read();
                dOver = resultado.GetDouble(0);
                dUnder = resultado.GetDouble(1);
                if (apu.tipoApuesta)
                {
                    prob = dOver / (dOver + dUnder);
                }
                else
                {
                    prob=dUnder / (dOver + dUnder);
                }
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return prob;
        }//Devuelve la probabilidad(double) Over/Under depente de tipo de apuesta

        public  double Cuota(Apuesta a)//Devuelve la cuota del mercado apostado
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            double cuota = 0;
            
            if (a.tipoApuesta)
            {
                command.CommandText = "Select cuotaOver from Mercados where idmercado="+a.idMercados+";";
                try
                {
                    con.Open();
                    MySqlDataReader resultado = command.ExecuteReader();
                    resultado.Read();
                    cuota = resultado.GetDouble(0);
                   
                    con.Close();
                }
                catch (Exception)
                {
                    Debug.WriteLine("Ha ocurrido un error.");

                    throw;
                }
                command.CommandText = "Update Mercados set dineroOver=dineroOver + " + a.dineroApostado + 
                                    " where idmercado="+a.idMercados+";" +
                                      "Update Mercados set cuotaOver=1/("+Probabilidad(a)+"*0.95) where idmercado = " + a.idMercados + "; ";
                Debug.WriteLine("comando " + command.CommandText);
                try
                {
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception)
                {
                    Debug.WriteLine("Ha ocurrido un error de conexion");
                    throw;
                }

            }
            else
            {
                command.CommandText = "Select cuotaUnder from Mercados where idMercado ="+a.idMercados+";";
                try
                {
                    con.Open();
                    MySqlDataReader resultado = command.ExecuteReader();
                    resultado.Read();
                    cuota = resultado.GetDouble(0);
                    
                    con.Close();
                }
                catch (Exception)
                {
                    Debug.WriteLine("Ha ocurrido un error.");
                    throw;

                }
                command.CommandText = "Update Mercados set dineroUnder=dineroUnder+" + a.dineroApostado +
                    " where idmercado=" + a.idMercados + ";" +
                    "Update Mercados set cuotaUnder=dineroUnder/(" + Probabilidad(a) + "*0.95) where idmercado = " + a.idMercados + "; ";
                Debug.WriteLine("comando " + command.CommandText);
                try
                {
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception)
                {
                    Debug.WriteLine("Ha ocurrido un error de conexion");
                    throw;
                }
            }
            return cuota;*/
            return 0;
        }

        internal void Insertar(Apuesta a)
        {
/*
            Comas();
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();

            double cuota = Cuota(a);
            

            command.CommandText = "Insert into Apuestas (idApuesta , id_mercado ,email_usuario ,tipoApuesta ,cuota,dineroApostado ,fechaApuesta) VALUES" +
                "("+a.idApuestas+","+a.idMercados+",'" +a.emailUsuarios+ "',"+ a.tipoApuesta+ ","+ cuota + ","+a.dineroApostado+ ",'"+DateTime.Now.ToString("yyyy/MM/dd") + "');";

            Debug.WriteLine("comando " + command.CommandText);
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                Debug.WriteLine("Ha ocurrido un error de conexion");
                throw;
            }
           */
        }
        internal List<ApuestaDTOmer> RetrieveDTObyMercado(int idMercado, string email)//utiliza estos para comprobar: luo.luo.ll14@gmail.com y 1

        {/*
            Comas();
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT tipoMercado,tipoapuesta,cuota,dineroapostado FROM apuestas " +
                "INNER JOIN mercados on apuestas.id_mercado=mercados.idMercado INNER JOIN eventos ON mercados.id_evento=eventos.idEvento" +
                " WHERE email_usuario=@A AND idMercado=@B; ";
            command.Parameters.AddWithValue("@A", email);
            command.Parameters.AddWithValue("@B", idMercado);
            try
            {
                con.Open();
                MySqlDataReader resultado = command.ExecuteReader();

                ApuestaDTOmer apuesta = null;
                List<ApuestaDTOmer> apuestas = new List<ApuestaDTOmer>();
                while (resultado.Read())
                {
                    Debug.WriteLine("Recuperado: " + resultado.GetDouble(0)  + resultado.GetBoolean(1)
                        + " " + resultado.GetDouble(2) + " " + resultado.GetDouble(3));

                    apuesta = new ApuestaDTOmer(resultado.GetDouble(0), resultado.GetBoolean(1),
                        resultado.GetDouble(2), resultado.GetDouble(3));
                    apuestas.Add(apuesta);
                }
                con.Close();
                return apuestas;
            }
            catch (Exception)
            {

                Debug.WriteLine("Ha ocurrido un error.");
                return null;
            }*/
            return null;
        }

    }
}