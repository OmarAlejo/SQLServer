using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Venta_Renta_Vehículos
{
    class Cliente
    {
        public Int64 id { get; set; }

        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }
        
        public string Domicilio { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public string NumTarjeta { get; set; }

        public Cliente() { }

        public Cliente(string pN, string sN, string aP, string aM, string d, string t, string e, string n)
        {
            PrimerNombre = pN;
            SegundoNombre = sN;
            ApellidoPaterno = aP;
            ApellidoMaterno = aM;
            Domicilio = d;
            Telefono = t;
            Email = e;
            NumTarjeta = n;
        }

        public static int Agregar(Cliente cli)
        {
            int respuesta = 0;
            Conexion cn = new Conexion();
            SqlConnection conn = cn.ConectaBD();
            try
            {
                SqlCommand comando = new SqlCommand(string.Format("INSERT INTO Servicios.Cliente" +
                    "(PrimerNombre,SegundoNombre,ApellidoPaterno,ApellidoMaterno,Domicilio, Telefono, Email, NumTarjeta)" +
                    "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
                    cli.PrimerNombre, cli.SegundoNombre, cli.ApellidoPaterno, cli.ApellidoMaterno, cli.Domicilio,
                    cli.Telefono, cli.Email, cli.NumTarjeta), conn);
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

        public static int Modificar(Cliente cli)
        {
            int respuesta = 0;
            Conexion cn = new Conexion();
            SqlConnection conn = cn.ConectaBD();
            try
            {
                SqlCommand comando = new SqlCommand(string.Format("UPDATE Servicios.Cliente SET " +
                    "PrimerNombre = '" + cli.PrimerNombre + "', " +
                    "SegundoNombre='" + cli.SegundoNombre +
                    "', ApellidoPaterno = '" + cli.ApellidoPaterno +
                    "', ApellidoMaterno='" + cli.ApellidoMaterno +
                    "', Domicilio='" + cli.Domicilio +
                    "', Telefono='" + cli.Telefono +
                    "', Email='" + cli.Email +
                    "', NumTarjeta='" + cli.NumTarjeta + "' WHERE IdCliente  = " + cli.id), conn);
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

        public static int Eliminar(Cliente cli)
        {
            int respuesta = 0;
            Conexion cn = new Conexion();
            SqlConnection conn = cn.ConectaBD();
            try
            {
                SqlCommand comando = new SqlCommand(string.Format("DELETE FROM Servicios.Cliente WHERE IdCliente  = "
                    + cli.id), conn);
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

        public List<Cliente> muestra()
        {
            List<Cliente> lista = new List<Cliente>();

            int respuesta = 0;
            Conexion cn = new Conexion();
            SqlConnection conn = cn.ConectaBD();
            SqlCommand comando = new SqlCommand(
                string.Format("SELECT * FROM Servicios.Cliente"), conn);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Cliente cli = new Cliente();
                cli.id = reader.GetInt64(0);
                cli.PrimerNombre = reader.GetString(1);
                cli.SegundoNombre = reader.GetString(2);
                cli.ApellidoPaterno = reader.GetString(3);
                cli.ApellidoMaterno = reader.GetString(4);
                cli.Domicilio = reader.GetString(5);
                cli.Telefono = reader.GetString(6);
                cli.Email = reader.GetString(7);
                cli.NumTarjeta = reader.GetString(8);


                lista.Add(cli);

            }
            cn.CierraConexionBD();
            return lista;
        }
    }
}
