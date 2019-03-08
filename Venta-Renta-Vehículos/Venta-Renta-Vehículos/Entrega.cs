using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Venta_Renta_Vehículos
{
    class Entrega
    {
        public Int64 id { get; set; }

        public Int64 IdRenta { get; set; }

        public Int64 IdEmpleado { get; set; }

        public string FechaEntrega { get; set; }

        public double Cargos { get; set; }

        public string DescripcionMantenimiento { get; set; }

        public double Costo { get; set; }

        public Entrega() { }

        public Entrega(int idR, int idE, string fE, double c, string d, double cos)
        {
            IdRenta = idR;
            IdEmpleado = idE;
            FechaEntrega = fE;
            Cargos = c;
            DescripcionMantenimiento = d;
            Costo = cos;
        }

        public static int Agregar(Entrega ren)
        {
            int respuesta = 0;
            Conexion cn = new Conexion();
            SqlConnection conn = cn.ConectaBD();
            try
            {
                SqlCommand comando = new SqlCommand(string.Format("INSERT INTO Servicios.Entrega" +
                    "(IdRenta,IdEmpleado,FechaEntrega,Cargos,DescripcionMantenimiento, Costo)" +
                    "values('{0}','{1}','{2}','{3}','{4}','{5}')",
                    ren.IdRenta, ren.IdEmpleado, DateTime.Parse(ren.FechaEntrega).ToShortDateString(), ren.Cargos,
                    ren.DescripcionMantenimiento, ren.Costo), conn);
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

        public static int Modificar(Entrega ren)
        {
            int respuesta = 0;
            Conexion cn = new Conexion();
            SqlConnection conn = cn.ConectaBD();
            try
            {
                SqlCommand comando = new SqlCommand(string.Format("UPDATE Servicios.Entrega SET " +
                    "IdRenta = '" + ren.IdRenta + "', " +
                    "IdEmpleado='" + ren.IdEmpleado +
                    "', FechaEntrega = '" + DateTime.Parse(ren.FechaEntrega).ToShortDateString() +
                    "', Cargos='" + ren.Cargos +
                    "', DescripcionMantenimiento='" + ren.DescripcionMantenimiento +
                    "', Costo='" + ren.Costo + "' WHERE IdEntrega  = " + ren.id), conn);
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

        public static int Eliminar(Entrega ren)
        {
            int respuesta = 0;
            Conexion cn = new Conexion();
            SqlConnection conn = cn.ConectaBD();
            try
            {
                SqlCommand comando = new SqlCommand(string.Format("DELETE FROM Servicios.Entrega WHERE IdEntrega  = "
                    + ren.id), conn);
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

        public List<Entrega> muestra()
        {
            List<Entrega> lista = new List<Entrega>();

            int respuesta = 0;
            Conexion cn = new Conexion();
            SqlConnection conn = cn.ConectaBD();
            SqlCommand comando = new SqlCommand(
                string.Format("SELECT * FROM Servicios.Entrega"), conn);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Entrega cli = new Entrega();
                cli.id = reader.GetInt64(0);
                cli.IdRenta = reader.GetInt64(1);
                cli.IdEmpleado = reader.GetInt64(2);
                cli.FechaEntrega = reader.GetDateTime(3).ToShortDateString();
                cli.Cargos = reader.GetDouble(4);
                cli.DescripcionMantenimiento = reader.GetString(5);
                cli.Costo = reader.GetDouble(6);

                lista.Add(cli);

            }
            cn.CierraConexionBD();
            return lista;
        }
    }
}
