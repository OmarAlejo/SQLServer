using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Venta_Renta_Vehículos
{
    class Renta
    {
        public Int64 id { get; set; }

        public Int64 IdVehiculo { get; set; }

        public Int64 IdCliente { get; set; }

        public Int64 IdEmpleado { get; set; }

        public string DiaPrestamo { get; set; }

        public string DiaDevolucion { get; set; }

        public double Total { get; set; }

        public Renta() { }

        public Renta(int idV, int idC, int idE, string dP, string dD, double t)
        {
            IdVehiculo = idV;
            IdCliente = idC;
            IdEmpleado = idE;
            DiaPrestamo = dP;
            DiaDevolucion = dD;
            Total = t;
        }

        public static int Agregar(Renta ren)
        {
            int respuesta = 0;
            Conexion cn = new Conexion();
            SqlConnection conn = cn.ConectaBD();
            SqlCommand comando = new SqlCommand(string.Format("INSERT INTO Servicios.Renta" +
                "(IdVehiculo,IdCliente,IdEmpleado,DiaPrestamo,DiaDevolucion)" +
                "values('{0}','{1}','{2}','{3}','{4}')",
                ren.IdVehiculo,ren.IdCliente,ren.IdEmpleado, DateTime.Parse(ren.DiaPrestamo).ToShortDateString(),
                DateTime.Parse(ren.DiaDevolucion).ToShortDateString()), conn);
            respuesta = comando.ExecuteNonQuery();
            cn.CierraConexionBD();
            return respuesta;
        }

        public static int Modificar(Renta ren)
        {
            int respuesta = 0;
            Conexion cn = new Conexion();
            SqlConnection conn = cn.ConectaBD();
            SqlCommand comando = new SqlCommand(string.Format("UPDATE Servicios.Renta SET " +
                "IdVehiculo = '" + ren.IdVehiculo + "', " +
                "IdCliente='" + ren.IdCliente +
                "', IdEmpleado = '" + ren.IdEmpleado +
                "', DiaPrestamo='" + DateTime.Parse(ren.DiaPrestamo).ToShortDateString() +
                "', DiaDevolucion='" + DateTime.Parse(ren.DiaDevolucion).ToShortDateString() +
                "', Total='" + ren.Total + "' WHERE IdRenta   = " + ren.id), conn);
            respuesta = comando.ExecuteNonQuery();
            cn.CierraConexionBD();
            return respuesta;
        }

        public static int Eliminar(Renta ren)
        {
            int respuesta = 0;
            Conexion cn = new Conexion();
            SqlConnection conn = cn.ConectaBD();
            SqlCommand comando = new SqlCommand(string.Format("DELETE FROM Servicios.Renta WHERE IdRenta   = "
                + ren.id), conn);
            respuesta = comando.ExecuteNonQuery();
            cn.CierraConexionBD();
            return respuesta;
        }

        public List<Renta> muestra()
        {
            List<Renta> lista = new List<Renta>();

            int respuesta = 0;
            Conexion cn = new Conexion();
            SqlConnection conn = cn.ConectaBD();
            SqlCommand comando = new SqlCommand(
                string.Format("SELECT * FROM Servicios.Renta"), conn);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Renta cli = new Renta();
                cli.id = reader.GetInt64(0);
                cli.IdVehiculo = reader.GetInt64(1);
                cli.IdCliente = reader.GetInt64(2);
                cli.IdEmpleado = reader.GetInt64(3);
                cli.DiaPrestamo = reader.GetDateTime(4).ToShortDateString();
                cli.DiaDevolucion = reader.GetDateTime(5).ToShortDateString();
                cli.Total = reader.GetDouble(6);


                lista.Add(cli);

            }
            cn.CierraConexionBD();
            return lista;
        }
    }
}
