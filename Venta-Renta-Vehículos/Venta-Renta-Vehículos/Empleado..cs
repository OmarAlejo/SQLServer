using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Venta_Renta_Vehículos
{
    class Empleado
    {
        public Int64 id { get; set; }

        public Int64 idTipo { get; set; }

        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public string Domicilio { get; set; }

        public string Telefono { get; set; }

        public Empleado() { }

        public Empleado(int idT, string pN, string sN, string aP, string aM, string d, string t)
        {
            idTipo = idT;
            PrimerNombre = pN;
            SegundoNombre = sN;
            ApellidoPaterno = aP;
            ApellidoMaterno = aM;
            Domicilio = d;
            Telefono = t;
        }

        public static int Agregar(Empleado em)
        {
            int respuesta = 0;
            Conexion cn = new Conexion();
            SqlConnection conn = cn.ConectaBD();
            try
            {
                SqlCommand comando = new SqlCommand(string.Format("INSERT INTO Empleado.Empleado" +
                    "(IdTipo,PrimerNombre,SegundoNombre,ApellidoPaterno,ApellidoMaterno, Domicilio, Telefono)" +
                    "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                    em.idTipo, em.PrimerNombre, em.SegundoNombre, em.ApellidoPaterno, em.ApellidoMaterno, em.Domicilio, em.Telefono), conn);
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

        public static int Modificar(Empleado em)
        {
            int respuesta = 0;
            Conexion cn = new Conexion();
            SqlConnection conn = cn.ConectaBD();
            try
            {
                SqlCommand comando = new SqlCommand(string.Format("UPDATE Empleado.Empleado SET IdTipo = '"
                    + em.idTipo + "', PrimerNombre='" + em.PrimerNombre + "', SegundoNombre = '" + em.SegundoNombre +
                    "', ApellidoPaterno='" + em.ApellidoPaterno +
                    "', ApellidoMaterno='" + em.ApellidoMaterno +
                    "', Domicilio='" + em.Domicilio +
                    "', Telefono='" + em.Telefono + "' WHERE IdEmpleado  = " + em.id), conn);
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

        public static int Eliminar(Empleado em)
        {
            int respuesta = 0;
            Conexion cn = new Conexion();
            SqlConnection conn = cn.ConectaBD();
            try
            {
                SqlCommand comando = new SqlCommand(string.Format("DELETE FROM Empleado.Empleado WHERE IdEmpleado = "
                    + em.id), conn);
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

        public List<Empleado> muestra()
        {
            List<Empleado> lista = new List<Empleado>();

            int respuesta = 0;
            Conexion cn = new Conexion();
            SqlConnection conn = cn.ConectaBD();
            SqlCommand comando = new SqlCommand(
                string.Format("SELECT * FROM Empleado.Empleado"), conn);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Empleado em = new Empleado();
                em.id = reader.GetInt64(0);
                em.idTipo = reader.GetInt64(1);
                em.PrimerNombre = reader.GetString(2);
                em.SegundoNombre = reader.GetString(3);
                em.ApellidoPaterno = reader.GetString(4);
                em.ApellidoMaterno = reader.GetString(5);
                em.Domicilio = reader.GetString(6);
                em.Telefono = reader.GetString(7);

                lista.Add(em);

            }
            cn.CierraConexionBD();
            return lista;
        }
    }
}
