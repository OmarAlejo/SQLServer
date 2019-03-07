using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Venta_Renta_Vehículos
{
    class Conexion
    {
        SqlConnection conexion;
        public Conexion()
        {
            conexion = new SqlConnection("Data Source=DESKTOP-PRGA55T\\SQLANGEL; Initial Catalog=VentaRentaVehiculos; Integrated Security=True");
        }

        public SqlConnection ConectaBD()
        {
            try
            {
                conexion.Open();
                //MessageBox.Show("conexion Correcta");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
            return conexion;
        }

        public void CierraConexionBD()
        {
            try
            {
                conexion.Close();
                //MessageBox.Show("conexion Cerrada");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fallo al cerrar la conexion: " + ex.ToString());
            }
        }
    }
}
