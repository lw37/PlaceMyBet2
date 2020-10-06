using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class UsuariosRepository
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

        internal List<Usuario> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from usuarios";
            try
            {
                con.Open();
                MySqlDataReader resultado = command.ExecuteReader();

                Usuario usuario = null;
                List<Usuario> usuarios = new List<Usuario>();
                while (resultado.Read())
                {
                    Debug.WriteLine("Recuperado: " + resultado.GetString(0) + " " + resultado.GetString(1) + " "
                        + resultado.GetString(2) + " " + resultado.GetInt32(3));
                    usuario = new Usuario(resultado.GetString(0), resultado.GetString(1),
                        resultado.GetString(2), resultado.GetInt32(3));
                    usuarios.Add(usuario);
                }
                con.Close();
                return usuarios;
            }
            catch (Exception )
            {

                Debug.WriteLine("Ha ocurrido un error.");
                return null;
            }



        }
    }
}