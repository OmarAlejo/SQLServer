using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Venta_Renta_Vehículos
{
    class Tipo
    {
        public Int64 id { get; set; }

        public float sueldo { get; set; }

        public string tipoEmpleado { get; set; }

        public Tipo()
        {
        }

        public Tipo(string t, float s)
        {
            tipoEmpleado = t;
            sueldo = s;
        }

        public static int Agregar(Tipo tipo)
        {
            int respuesta = 0;
            Conexion cn = new Conexion();
            SqlConnection conn = cn.ConectaBD();
            try
            {
                SqlCommand comando = new SqlCommand(string.Format("INSERT INTO Empleado.Tipo" +
                    "(Tipo,Sueldo)" +
                    "values('{0}','{1}')",
                    tipo.tipoEmpleado, tipo.sueldo), conn);
                respuesta = comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                respuesta = 0;
            }
            cn.CierraConexionBD();
            return respuesta;
        }

        public static int Modificar(Tipo tipo)
        {
            int respuesta = 0;
            Conexion cn = new Conexion();
            SqlConnection conn = cn.ConectaBD();
            try
            {
                SqlCommand comando = new SqlCommand(string.Format("UPDATE Empleado.Tipo SET Tipo = '"
                    + tipo.tipoEmpleado + "', Sueldo='" + tipo.sueldo + "' WHERE IdTipo  = " + tipo.id), conn);
                respuesta = comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                respuesta = 0;
            }
            cn.CierraConexionBD();
            return respuesta;
        }

        public static int Eliminar(Tipo tipo)
        {
            int respuesta = 0;
            Conexion cn = new Conexion();
            SqlConnection conn = cn.ConectaBD();
            try
            {
                SqlCommand comando = new SqlCommand(string.Format("DELETE FROM Empleado.Tipo WHERE IdTipo = "
                    + tipo.id), conn);
                respuesta = comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                respuesta = 0;
            }
            cn.CierraConexionBD();
            return respuesta;
        }

        public List<Tipo> muestra()
        {
            List<Tipo> lista = new List<Tipo>();

            int respuesta = 0;
            Conexion cn = new Conexion();
            SqlConnection conn = cn.ConectaBD();
            SqlCommand comando = new SqlCommand(
                string.Format("SELECT * FROM Empleado.tipo"), conn);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Tipo t = new Tipo();
                t.id = reader.GetInt64(0);
                t.tipoEmpleado = reader.GetString(1);
                t.sueldo = reader.GetFloat(2);

                lista.Add(t);

            }
            cn.CierraConexionBD();
            return lista;
        }
    }
}
