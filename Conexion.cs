using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dual
{
    class Conexion
    {
        public static MySqlConnection conexion()
        {
            string servidor = "localhost";
            string puerto = "3306";
            string usuario = "root";
            string password = "4519";
            string bd = "itm";

            string cadenaConexion = "Database=" + bd + "; Data Source=" + servidor + ";port =" + puerto + "; User id= " + usuario + "; Password=" + password + "";

            //string cadenaConexion = "datasource=localhost;Port=3306;username=root;password=4519;database=itm";


            try
            {
                MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
                return conexionBD;


            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }

        }
    }
}
