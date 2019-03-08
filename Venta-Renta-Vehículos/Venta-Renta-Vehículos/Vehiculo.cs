using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Venta_Renta_Vehículos
{
    class Vehiculo
    {
        public Int64 id { get; set; }

        public string placas { get; set; }

        public string marca { get; set; }

        public string modelo { get; set; }

        public string anio { get; set; }

        public string descripcion { get; set; }

        public string numSeguro { get; set; }

        public double precioVenta { get; set; }

        public string vendido { get; set; }

        public double precioRenta { get; set; }

        public string disponible { get; set; }

        public Vehiculo()
        {
        }

        public Vehiculo(String p, String ma, String mo, String a, String d, String ns, double pv, string v, double pr, string di)
        {
            placas = p;
            marca = ma;
            modelo = mo;
            anio = a;
            descripcion = d;
            numSeguro = ns;
            precioVenta = pv;
            precioRenta = pr;
            vendido = v;
            disponible = di;
        }

        public static int Agregar(Vehiculo veh)
        {
            int respuesta = 0;
            Conexion cn = new Conexion();
            SqlConnection conn = cn.ConectaBD();
            try
            {
                SqlCommand comando = new SqlCommand(string.Format("INSERT INTO Servicios.Vehiculo" +
                    "(Placas,Marca,Modelo,Año,Descripcion, NumSeguro, Vendido, PrecioVenta, Disponible, PrecioRenta)" +
                    "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')",
                    veh.placas, veh.marca, veh.modelo, veh.anio, veh.descripcion, veh.numSeguro, veh.vendido, veh.precioVenta,
                    veh.disponible, veh.precioRenta), conn);
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

        public static int Modificar(Vehiculo veh)
        {
            int respuesta = 0;
            Conexion cn = new Conexion();
            SqlConnection conn = cn.ConectaBD();
            try
            {
                SqlCommand comando = new SqlCommand(string.Format("UPDATE Servicios.Vehiculo SET Placas = '"
                    + veh.placas + "', Marca='" + veh.marca + "', Modelo = '" + veh.modelo +
                    "', Año='" + veh.anio +
                    "', Descripcion='" + veh.descripcion +
                    "', NumSeguro='" + veh.numSeguro +
                    "', Vendido='" + veh.vendido +
                    "', PrecioVenta='" + veh.precioVenta +
                    "', Disponible='" + veh.disponible +
                    "', PrecioRenta='" + veh.precioRenta + "' WHERE IdVehiculo = " + veh.id), conn);
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

        public static int Eliminar(Vehiculo veh)
        {
            int respuesta = 0;
            Conexion cn = new Conexion();
            SqlConnection conn = cn.ConectaBD();
            try
            {
                SqlCommand comando = new SqlCommand(string.Format("DELETE FROM Servicios.Vehiculo WHERE IdVehiculo = "
                    + veh.id), conn);
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

        public List<Vehiculo> muestra()
        {
            List<Vehiculo> lista = new List<Vehiculo>();

            int respuesta = 0;
            Conexion cn = new Conexion();
            SqlConnection conn = cn.ConectaBD();
            SqlCommand comando = new SqlCommand(
                string.Format("SELECT * FROM Servicios.Vehiculo"), conn);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Vehiculo veh = new Vehiculo();
                veh.id = reader.GetInt64(0);
                veh.placas = reader.GetString(1);
                veh.marca = reader.GetString(2);
                veh.modelo = reader.GetString(3);
                veh.anio = reader.GetString(4);
                veh.descripcion = reader.GetString(5);
                veh.numSeguro = reader.GetString(6);
                veh.vendido = reader.GetBoolean(7).ToString();
                veh.precioVenta = reader.GetSqlMoney(8).ToDouble();
                veh.disponible = reader.GetBoolean(9).ToString();
                veh.precioRenta = reader.GetSqlMoney(10).ToDouble();


                lista.Add(veh);

            }
            cn.CierraConexionBD();
            return lista;
        }
    }
}
