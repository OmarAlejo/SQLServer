using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Venta_Renta_Vehículos
{
    class Venta
    {
        public Int64 id { get; set; }

        public Int64 IdVehiculo { get; set; }

        public Int64 IdCliente { get; set; }

        public Int64 IdEmpleado { get; set; }

        public string FechaVenta { get; set; }

        public Venta() { }

        public Venta(int idV, int idC, int idE, string fV)
        {
            IdVehiculo = idV;
            IdCliente = idC;
            IdEmpleado = idE;
            FechaVenta = fV;
        }

        public static int Agregar(Venta ven)
        {
            int respuesta = 0;
            Conexion cn = new Conexion();
            SqlConnection conn = cn.ConectaBD();
            try
            {
                SqlCommand comando = new SqlCommand(string.Format("INSERT INTO Servicios.Venta" +
                    "(IdVehiculo,IdCliente,IdEmpleado,FechaVenta)" +
                    "values('{0}','{1}','{2}','{3}')",
                    ven.IdVehiculo, ven.IdCliente, ven.IdEmpleado, DateTime.Now.ToString("M/d/yyyy")), conn);
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

        public static int Modificar(Venta ven)
        {
            int respuesta = 0;
            Conexion cn = new Conexion();
            SqlConnection conn = cn.ConectaBD();
            try
            {
                SqlCommand comando = new SqlCommand(string.Format("UPDATE Servicios.Venta SET " +
                    "IdVehiculo = '" + ven.IdVehiculo + "', " +
                    "IdCliente='" + ven.IdCliente +
                    "', IdEmpleado = '" + ven.IdEmpleado +
                    "' WHERE IdVenta   = " + ven.id), conn);
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

        public static int Eliminar(Venta ven)
        {
            int respuesta = 0;
            Conexion cn = new Conexion();
            SqlConnection conn = cn.ConectaBD();
            try
            {
                SqlCommand comando = new SqlCommand(string.Format("DELETE FROM Servicios.Venta WHERE IdVenta   = "
                    + ven.id), conn);
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

        public List<Venta> muestra()
        {
            List<Venta> lista = new List<Venta>();

            int respuesta = 0;
            Conexion cn = new Conexion();
            SqlConnection conn = cn.ConectaBD();
            SqlCommand comando = new SqlCommand(
                string.Format("SELECT * FROM Servicios.Venta"), conn);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Venta ven = new Venta();
                ven.id = reader.GetInt64(0);
                ven.IdVehiculo = reader.GetInt64(1);
                ven.IdCliente = reader.GetInt64(2);
                ven.IdEmpleado = reader.GetInt64(3);
                ven.FechaVenta = reader.GetDateTime(4).ToShortDateString();


                lista.Add(ven);

            }
            cn.CierraConexionBD();
            return lista;
        }
    }
}
