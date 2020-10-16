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
                        + " " + resultado.GetDouble(5) + " " + resultado.GetDouble(6) + " " + resultado.GetDateTime(7));

                    apuesta = new Apuesta(resultado.GetInt32(0), resultado.GetInt32(1),
                        resultado.GetString(2),resultado.GetDouble(3) ,resultado.GetBoolean(4), resultado.GetDouble(5),
                        resultado.GetDouble(6), resultado.GetDateTime(7));
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

        internal List<ApuestaDTO> RetrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            try
            {
                con.Open();
                MySqlDataReader resultado = command.ExecuteReader();

                ApuestaDTO apuesta = null;
                List<ApuestaDTO> apuestas = new List<ApuestaDTO>();
                while (resultado.Read())
                {
                    Debug.WriteLine("Recuperado: " + resultado.GetString(0) + " " + resultado.GetDouble(1) + " " + resultado.GetBoolean(2) + " " + resultado.GetDouble(3)
                        + " " + resultado.GetDouble(4) + " " + resultado.GetDateTime(5));

                    apuesta = new ApuestaDTO(resultado.GetString(0), resultado.GetDouble(1), resultado.GetBoolean(2), resultado.GetDouble(3),
                        resultado.GetDouble(4), resultado.GetDateTime(5));
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

        public double Probabilidad(Apuesta apu)
        {
            MySqlConnection con = Connect();
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
                command.CommandText = "Select cuotaOver from Mercados where idMercado =1;";
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
                command.CommandText = "Update Mercados set dineroOver=dineroOver+" + a.dineroApostado + 
                                    " where idmercado="+a.idMercados+"" +
                                      "Update Mercados set cuotaOver=1/"+Probabilidad(a)+"*0.95 where idmercado = " + a.idMercados + "; ";
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
                command.CommandText = "Select cuotaUnder from Mercados where idMercado =1;";
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
                    "Update Mercados set cuotaUnder=dineroUnder/" + Probabilidad(a) + "*0.95 where idmercado = " + a.idMercados + "; ";
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
            return cuota;
        }

        internal void Insertar(Apuesta a)//No me deja enviar datos a bbdd por fallo de punto y comas de la cuota
        {

         
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
           
        }
    }
}