using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dual
{
    class CtrlAlumnos : Conexion
    {
        public List<Object> consulta(string dato)
        {
            MySqlDataReader reader;
            List<Object> lista = new List<object>();
            string sql;
            
            if (dato == null)
            {
                
                sql = "SELECT idAlumno, matrícula, nombreCompleto, semestre, modalidad, celular, correo FROM alumno ORDER BY nombreCompleto ASC";
            }
            else
            {
                
                sql = "SELECT  idAlumno, matrícula, nombreCompleto, semestre, modalidad, celular, correo FROM alumno WHERE matrícula LIKE '%" + @dato + "%' OR nombreCompleto LIKE'"+@dato+ "%' OR semestre LIKE'" + @dato + "%' OR modalidad LIKE'" + @dato + "%' OR celular LIKE'" + @dato + "%'  OR correo LIKE'"+@dato+"%'  ORDER BY idAlumno ASC";
            }
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            try
            {
                
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Alumnos _alumno = new Alumnos();
                    _alumno.IdAlumno = int.Parse(reader.GetString(0));
                    _alumno.Matrícula = reader[1].ToString();
                    _alumno.NombreCompleto = reader[2].ToString();
                    _alumno.Semestre = reader[3].ToString();
                    _alumno.Modalidad = reader[4].ToString();
                    _alumno.Celular = reader[5].ToString();
                    _alumno.Correo = reader[6].ToString();
                    lista.Add(_alumno);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
            return lista;

        }

        public bool insertar(Alumnos datos)
        {
            bool bandera = false;
            string sql = "INSERT INTO alumno (matrícula, nombreCompleto, semestre, modalidad, celular, correo) VALUES ('" + @datos.Matrícula + "', '" + @datos.NombreCompleto + "', '" + @datos.Semestre + "', '" + @datos.Modalidad + "', '" + @datos.Celular + "', '" + @datos.Correo + "')";
            try
            {
                MySqlConnection conexionBD = Conexion.conexion();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                bandera = true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                bandera = false;
            }
            return bandera;
        }

        public bool actualizar(Alumnos datos)
        {
            bool bandera = false;
            string sql = "UPDATE alumno SET matrícula = '" + @datos.Matrícula + "',  nombreCompleto='"+ @datos.NombreCompleto + "', semestre='" + @datos.Semestre + "', modalidad='" + @datos.Modalidad + "',  celular= '" + @datos.Celular + "', correo='" + @datos.Correo + "' WHERE idAlumno='"+@datos.IdAlumno+"'";
            
            try
            {
                MySqlConnection conexionBD = Conexion.conexion();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                bandera = true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                bandera = false;
            }
            return bandera;
        }
        public bool eliminar(int IdAlumno)
        {
            bool bandera = false;
            string sql = "DELETE FROM alumno WHERE idAlumno='" + @IdAlumno + "'";

            try
            {
                MySqlConnection conexionBD = Conexion.conexion();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                bandera = true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                bandera = false;
         
            }
            return bandera;
        }

    }


}
