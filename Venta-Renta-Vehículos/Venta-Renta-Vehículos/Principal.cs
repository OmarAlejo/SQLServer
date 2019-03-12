using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Venta_Renta_Vehículos
{
    public partial class Principal : Form
    {
        private Vehiculo vehiculo;
        private Empleado empleado;
        private Cliente cliente;
        private Tipo tipo;
        private Entrega entrega;
        private Venta venta;
        private Renta renta;

        public Principal()
        {
            InitializeComponent();
            vehiculo = new Vehiculo();
            dataGridView1.DataSource = vehiculo.muestra();
            empleado = new Empleado();
            dataGridView2.DataSource = empleado.muestra();
            cliente = new Cliente();
            dataGridView4.DataSource = cliente.muestra();
            tipo = new Tipo();
            dataGridView3.DataSource = tipo.muestra();
            entrega = new Entrega();
            dataGridView7.DataSource = entrega.muestra();
            venta = new Venta();
            dataGridView5.DataSource = venta.muestra();
            renta = new Renta();
            dataGridView6.DataSource = renta.muestra();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E646D");
            this.tabPage1.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E646D");
            this.tabPage2.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E646D");
            this.tabPage3.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E646D");
            this.tabPage4.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E646D");
            this.tabPage5.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E646D");
            this.tabPage6.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E646D");
            this.tabPage7.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E646D");
            buttonModificarC.Enabled = false;
            buttonEliminarC.Enabled = false;
            buttonModificarE.Enabled = false;
            buttonEliminarE.Enabled = false;
            buttonModificarEE.Enabled = false;
            buttonEliminarEE.Enabled = false;
            buttonModificarR.Enabled = false;
            buttonEliminarR.Enabled = false;
            buttonModificarT.Enabled = false;
            buttonEliminarT.Enabled = false;
            buttonModificarV.Enabled = false;
            buttonEliminarV.Enabled = false;
            buttonModificarVV.Enabled = false;
            buttonEliminarVV.Enabled = false;
        }

        private void buttonAgregarV_Click(object sender, EventArgs e)
        {
            Vehiculo veh = new Vehiculo();
            veh.placas = textBoxPlacas.Text;
            veh.marca = textBoxMarca.Text;
            veh.modelo = textBoxModelo.Text;
            veh.anio = textBoxAno.Text;
            veh.disponible = "True";
            veh.vendido = "False";
            veh.precioVenta = Double.Parse(textBoxVenta.Text);
            veh.precioRenta = Double.Parse(textBoxRenta.Text);
            veh.numSeguro = textBoxNumSeguro.Text;
            veh.descripcion = textBoxDesVeh.Text;

            if (Vehiculo.Agregar(veh) > 0)
            {
                //MessageBox.Show("Bien");
                dataGridView1.DataSource = vehiculo.muestra();
                Clear();
            }
            else
                MessageBox.Show("Mal");
        }

        private void buttonModificarV_Click(object sender, EventArgs e)
        {
            Vehiculo veh = new Vehiculo();
            veh.id = vehiculo.id;
            veh.placas = textBoxPlacas.Text;
            veh.marca = textBoxMarca.Text;
            veh.modelo = textBoxModelo.Text;
            veh.anio = textBoxAno.Text;
            veh.precioVenta = Double.Parse(textBoxVenta.Text);
            veh.precioRenta = Double.Parse(textBoxRenta.Text);
            veh.numSeguro = textBoxNumSeguro.Text;
            veh.descripcion = textBoxDesVeh.Text;

            if (Vehiculo.Modificar(veh) > 0)
            {
                //MessageBox.Show("Bien");
                dataGridView1.DataSource = vehiculo.muestra();
                Clear();
            }
            else
                MessageBox.Show("Mal");
        }

        private void buttonEliminarV_Click(object sender, EventArgs e)
        {
            Vehiculo veh = new Vehiculo();
            veh.id = vehiculo.id;
            veh.placas = textBoxPlacas.Text;
            veh.marca = textBoxMarca.Text;
            veh.modelo = textBoxModelo.Text;
            veh.anio = textBoxAno.Text;
            veh.precioVenta = Double.Parse(textBoxVenta.Text);
            veh.precioRenta = Double.Parse(textBoxRenta.Text);
            veh.numSeguro = textBoxNumSeguro.Text;
            veh.descripcion = textBoxDesVeh.Text;

            if (Vehiculo.Eliminar(veh) > 0)
            {
                //MessageBox.Show("Bien");
                dataGridView1.DataSource = vehiculo.muestra();
                Clear();
            }
            else
                MessageBox.Show("Mal");
        }

        private void buttonAgregarE_Click(object sender, EventArgs e)
        {
            Empleado veh = new Empleado();
            veh.PrimerNombre = textBoxPNombreE.Text;
            veh.SegundoNombre = textBoxSNombreE.Text;
            veh.ApellidoPaterno = textBoxAPaternoE.Text;
            veh.ApellidoMaterno = textBoxAMaternoE.Text;
            veh.Domicilio = textBoxDomicilioE.Text;
            veh.idTipo = Int64.Parse(textBox7.Text);
            veh.Telefono = textBoxTelefonoE.Text;

            if (Empleado.Agregar(veh) > 0)
            {
                //MessageBox.Show("Bien");
                dataGridView2.DataSource = empleado.muestra();
                Clear();
            }
            else
                MessageBox.Show("Mal");
        }

        private void buttonModificarE_Click(object sender, EventArgs e)
        {
            Empleado veh = new Empleado();
            veh.id = empleado.id;
            veh.PrimerNombre = textBoxPNombreE.Text;
            veh.SegundoNombre = textBoxSNombreE.Text;
            veh.ApellidoPaterno = textBoxAPaternoE.Text;
            veh.ApellidoMaterno = textBoxAMaternoE.Text;
            veh.Domicilio = textBoxDomicilioE.Text;
            veh.idTipo = Int64.Parse(textBox7.Text);
            veh.Telefono = textBoxTelefonoE.Text;

            if (Empleado.Modificar(veh) > 0)
            {
                //MessageBox.Show("Bien");
                dataGridView2.DataSource = empleado.muestra();
                Clear();
            }
            else
                MessageBox.Show("Mal");
        }

        private void buttonEliminarE_Click(object sender, EventArgs e)
        {
            Empleado veh = new Empleado();
            veh.id = empleado.id;
            veh.PrimerNombre = textBoxPNombreE.Text;
            veh.SegundoNombre = textBoxSNombreE.Text;
            veh.ApellidoPaterno = textBoxAPaternoE.Text;
            veh.ApellidoMaterno = textBoxAMaternoE.Text;
            veh.Domicilio = textBoxDomicilioE.Text;
            veh.idTipo = Int64.Parse(textBox7.Text);
            veh.Telefono = textBoxTelefonoE.Text;

            if (Empleado.Eliminar(veh) > 0)
            {
                //MessageBox.Show("Bien");
                dataGridView2.DataSource = empleado.muestra();
                Clear();
            }
            else
                MessageBox.Show("Mal");
        }

        private void buttonAgregarT_Click(object sender, EventArgs e)
        {
            Tipo veh = new Tipo();
            veh.tipoEmpleado = textBoxTipo.Text;
            veh.sueldo = Convert.ToSingle(textBoxSueldo.Text);

            if (Tipo.Agregar(veh) > 0)
            {
                //MessageBox.Show("Bien");
                dataGridView3.DataSource = tipo.muestra();
                Clear();
            }
            else
                MessageBox.Show("Mal");
        }

        private void buttonModificarT_Click(object sender, EventArgs e)
        {
            Tipo veh = new Tipo();
            veh.id = tipo.id;
            veh.tipoEmpleado = textBoxTipo.Text;
            veh.sueldo = Convert.ToSingle(textBoxSueldo.Text);

            if (Tipo.Modificar(veh) > 0)
            {
                //MessageBox.Show("Bien");
                dataGridView3.DataSource = tipo.muestra();
                Clear();
            }
            else
                MessageBox.Show("Mal");
        }

        private void buttonEliminarT_Click(object sender, EventArgs e)
        {
            Tipo veh = new Tipo();
            veh.id = tipo.id;
            veh.tipoEmpleado = textBoxTipo.Text;
            veh.sueldo = Convert.ToSingle(textBoxSueldo.Text);

            if (Tipo.Eliminar(veh) > 0)
            {
                //MessageBox.Show("Bien");
                dataGridView3.DataSource = tipo.muestra();
                Clear();
            }
            else
                MessageBox.Show("Mal");
        }

        private void buttonAgregarC_Click(object sender, EventArgs e)
        {
            Cliente veh = new Cliente();
            veh.PrimerNombre = textBoxPNombreC.Text;
            veh.SegundoNombre = textBoxSNombreC.Text;
            veh.ApellidoPaterno = textBoxAPaternoC.Text;
            veh.ApellidoMaterno = textBoxAMaternoC.Text;
            veh.Domicilio = textBoxDomicilioC.Text;
            veh.Telefono = textBoxTelefonoC.Text;
            veh.NumTarjeta = textBoxNumTarjeta.Text;
            veh.Email = textBoxEmail.Text;

            if (Cliente.Agregar(veh) > 0)
            {
                //MessageBox.Show("Bien");
                dataGridView4.DataSource = cliente.muestra();
                Clear();
            }
            else
                MessageBox.Show("Mal");
        }

        private void buttonModificarC_Click(object sender, EventArgs e)
        {
            Cliente veh = new Cliente();
            veh.id = cliente.id;
            veh.PrimerNombre = textBoxPNombreC.Text;
            veh.SegundoNombre = textBoxSNombreC.Text;
            veh.ApellidoPaterno = textBoxAPaternoC.Text;
            veh.ApellidoMaterno = textBoxAMaternoC.Text;
            veh.Domicilio = textBoxDomicilioC.Text;
            veh.Telefono = textBoxTelefonoC.Text;
            veh.NumTarjeta = textBoxNumTarjeta.Text;
            veh.Email = textBoxEmail.Text;

            if (Cliente.Modificar(veh) > 0)
            {
                //MessageBox.Show("Bien");
                dataGridView4.DataSource = cliente.muestra();
                Clear();
            }
            else
                MessageBox.Show("Mal");
        }

        private void buttonEliminarC_Click(object sender, EventArgs e)
        {
            Cliente veh = new Cliente();
            veh.id = cliente.id;
            veh.PrimerNombre = textBoxPNombreC.Text;
            veh.SegundoNombre = textBoxSNombreC.Text;
            veh.ApellidoPaterno = textBoxAPaternoC.Text;
            veh.ApellidoMaterno = textBoxAMaternoC.Text;
            veh.Domicilio = textBoxDomicilioC.Text;
            veh.Telefono = textBoxTelefonoC.Text;
            veh.NumTarjeta = textBoxNumTarjeta.Text;
            veh.Email = textBoxEmail.Text;

            if (Cliente.Eliminar(veh) > 0)
            {
                //MessageBox.Show("Bien");
                dataGridView4.DataSource = cliente.muestra();
                Clear();
            }
            else
                MessageBox.Show("Mal");
        }

        private void buttonAgregarVV_Click(object sender, EventArgs e)
        {
            Venta veh = new Venta();
            veh.IdCliente = Int64.Parse(textBoxIdClienteV.Text);
            veh.IdEmpleado = Int64.Parse(textBoxIdEmpleadoV.Text);
            veh.IdVehiculo = Int64.Parse(textBoxIdVehiculoV.Text);

            Conexion cn = new Conexion();
            SqlConnection conn = cn.ConectaBD();
            SqlCommand comando = new SqlCommand(
                string.Format("SELECT Disponible, Vendido FROM Servicios.Vehiculo WHERE IdVehiculo = " + veh.IdVehiculo), conn);
            SqlDataReader reader = comando.ExecuteReader();
            Boolean disponible = false, vendido = false;
            while (reader.Read())
            {
                disponible = reader.GetBoolean(0);
                vendido = reader.GetBoolean(1);

            }
            reader.Close();

            if (disponible && !vendido)
            {
                if (Venta.Agregar(veh) > 0)
                {
                    //MessageBox.Show("Bien");
                    dataGridView5.DataSource = venta.muestra();
                    Clear();
                }
                else
                    MessageBox.Show("Mal");
            }
            else
                MessageBox.Show("El vehículo no está disponible para la venta");
            
        }

        private void buttonModificarVV_Click(object sender, EventArgs e)
        {
            Venta veh = new Venta();
            veh.id = venta.id;
            veh.IdCliente = Int64.Parse(textBoxIdClienteV.Text);
            veh.IdEmpleado = Int64.Parse(textBoxIdEmpleadoV.Text);
            veh.IdVehiculo = Int64.Parse(textBoxIdVehiculoV.Text);
            

            if (Venta.Modificar(veh) > 0)
            {
                //MessageBox.Show("Bien");
                dataGridView5.DataSource = venta.muestra();
                Clear();
            }
            else
                MessageBox.Show("Mal");
        }

        private void buttonEliminarVV_Click(object sender, EventArgs e)
        {
            Venta veh = new Venta();
            veh.id = venta.id;
            veh.IdCliente = Int64.Parse(textBoxIdClienteV.Text);
            veh.IdEmpleado = Int64.Parse(textBoxIdEmpleadoV.Text);
            veh.IdVehiculo = Int64.Parse(textBoxIdVehiculoV.Text);
            

            if (Venta.Eliminar(veh) > 0)
            {
                //MessageBox.Show("Bien");
                dataGridView5.DataSource = venta.muestra();
                Clear();
            }
            else
                MessageBox.Show("Mal");
        }

        private void buttonAgregarR_Click(object sender, EventArgs e)
        {
            Renta veh = new Renta();
            veh.IdCliente = Int64.Parse(textBox2.Text);
            veh.IdEmpleado = Int64.Parse(textBox1.Text);
            veh.IdVehiculo = Int64.Parse(textBox3.Text);
            
            veh.DiaDevolucion = comboBox11.Text + "-" + comboBox10.Text + "-" + comboBox9.Text;
            //veh.Total = Double.Parse(textBox6.Text);

            DateTime devolucion = Convert.ToDateTime(veh.DiaDevolucion);
            DateTime prestamo = Convert.ToDateTime(DateTime.Now.ToString("M/d/yyyy"));

            Conexion cn = new Conexion();
            SqlConnection conn = cn.ConectaBD();
            SqlCommand comando = new SqlCommand(
                string.Format("SELECT Disponible FROM Servicios.Vehiculo WHERE IdVehiculo = " + veh.IdVehiculo), conn);
            SqlDataReader reader = comando.ExecuteReader();
            Boolean disponible = false;
            while (reader.Read())
            {
                 disponible = reader.GetBoolean(0);
            }
            reader.Close();

            if (disponible)
            {
                if (Renta.Agregar(veh) > 0 && devolucion > prestamo)
                {
                    //MessageBox.Show("Bien");
                    dataGridView6.DataSource = renta.muestra();
                    Clear();
                }
                else
                    MessageBox.Show("La fecha de devolución debe ser después del día de hoy.");
            }
            else
                MessageBox.Show("El vehículo no está disponible");
        }

        private void buttonModificarR_Click(object sender, EventArgs e)
        {
            Renta veh = new Renta();
            veh.id = renta.id;
            veh.IdCliente = Int64.Parse(textBox2.Text);
            veh.IdEmpleado = Int64.Parse(textBox1.Text);
            veh.IdVehiculo = Int64.Parse(textBox3.Text);
            
            veh.DiaDevolucion = comboBox11.Text + "-" + comboBox10.Text + "-" + comboBox9.Text;
            //veh.Total = Double.Parse(textBox6.Text);

            if (Renta.Modificar(veh) > 0)
            {
                //MessageBox.Show("Bien");
                dataGridView6.DataSource = renta.muestra();
                Clear();
            }
            else
                MessageBox.Show("Mal");
        }

        private void buttonEliminarR_Click(object sender, EventArgs e)
        {
            Renta veh = new Renta();
            veh.id = renta.id;
            veh.IdCliente = Int64.Parse(textBox2.Text);
            veh.IdEmpleado = Int64.Parse(textBox1.Text);
            veh.IdVehiculo = Int64.Parse(textBox3.Text);
            
            veh.DiaDevolucion = comboBox11.Text + "-" + comboBox10.Text + "-" + comboBox9.Text;
            //veh.Total = Double.Parse(textBox6.Text);

            if (Renta.Eliminar(veh) > 0)
            {
                //MessageBox.Show("Bien");
                dataGridView6.DataSource = renta.muestra();
                Clear();
            }
            else
                MessageBox.Show("Mal");
        }

        private void buttonAgregarEE_Click(object sender, EventArgs e)
        {
            Entrega veh = new Entrega();
            veh.IdRenta = Int64.Parse(textBoxIdRenta.Text);
            veh.IdEmpleado = Int64.Parse(textBoxIdEmpleadoE.Text);
            veh.FechaEntrega = comboBox14.Text + "-" + comboBox13.Text + "-" + comboBox12.Text;
            veh.Cargos = Double.Parse(textBoxCargos.Text);
            veh.DescripcionMantenimiento = textBoxDescripcionM.Text;
            veh.Costo = Double.Parse(textBox8.Text);

            if (Entrega.Agregar(veh) > 0)
            {
                //MessageBox.Show("Bien");
                dataGridView7.DataSource = entrega.muestra();
                Clear();
            }
            else
                MessageBox.Show("Mal");
        }

        private void buttonModificarEE_Click(object sender, EventArgs e)
        {
            Entrega veh = new Entrega();
            veh.id = entrega.id;
            veh.IdRenta = Int64.Parse(textBoxIdRenta.Text);
            veh.IdEmpleado = Int64.Parse(textBoxIdEmpleadoE.Text);
            veh.FechaEntrega = comboBox14.Text + "-" + comboBox13.Text + "-" + comboBox12.Text;
            veh.Cargos = Double.Parse(textBoxCargos.Text);
            veh.DescripcionMantenimiento = textBoxDescripcionM.Text;
            veh.Costo = Double.Parse(textBox8.Text);

            if (Entrega.Modificar(veh) > 0)
            {
                //MessageBox.Show("Bien");
                dataGridView7.DataSource = entrega.muestra();
                Clear();
            }
            else
                MessageBox.Show("Mal");
        }

        private void buttonEliminarEE_Click(object sender, EventArgs e)
        {
            Entrega veh = new Entrega();
            veh.id = entrega.id;
            veh.IdRenta = Int64.Parse(textBoxIdRenta.Text);
            veh.IdEmpleado = Int64.Parse(textBoxIdEmpleadoE.Text);
            veh.FechaEntrega = comboBox14.Text + "-" + comboBox13.Text + "-" + comboBox12.Text;
            veh.Cargos = Double.Parse(textBoxCargos.Text);
            veh.DescripcionMantenimiento = textBoxDescripcionM.Text;
            veh.Costo = Double.Parse(textBox8.Text);

            if (Entrega.Eliminar(veh) > 0)
            {
                //MessageBox.Show("Bien");
                dataGridView7.DataSource = entrega.muestra();
                Clear();
            }
            else
                MessageBox.Show("Mal");
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void tabControl_TabIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            dataGridView1.DataSource = vehiculo.muestra();
            dataGridView2.DataSource = empleado.muestra();

            labelFechaVenta.Text = DateTime.Now.ToString("d/M/yyyy");
            labelFechaPrestamo.Text = DateTime.Now.ToString("d/M/yyyy");

            int respuesta = 0;
            Conexion cn = new Conexion();
            SqlConnection conn = cn.ConectaBD();
            SqlCommand comando = new SqlCommand(
                string.Format("SELECT CONCAT(IdTipo, '_', Tipo) FROM Empleado.Tipo"), conn);
            SqlDataReader reader = comando.ExecuteReader();

            cbTipo.Items.Clear();
            while (reader.Read())
            {
                cbTipo.Items.Add(reader.GetString(0));
            }
            reader.Close();

            SqlCommand comando2 = new SqlCommand(
                string.Format("SELECT CONCAT(IdVehiculo, '_', Marca, '_', Modelo, ' ' ,Año) FROM Servicios.Vehiculo"), conn);
            SqlDataReader reader2 = comando2.ExecuteReader();
            cbVehiculo1.Items.Clear();
            cbVehiculo2.Items.Clear();
            while (reader2.Read())
            {
                cbVehiculo1.Items.Add(reader2.GetString(0));
                cbVehiculo2.Items.Add(reader2.GetString(0));
            }
            reader2.Close();

            SqlCommand comando3 = new SqlCommand(
                string.Format("SELECT CONCAT(IdCliente, '_', PrimerNombre, ' ', SegundoNombre, ' ' , ApellidoPaterno, ' ', ApellidoMaterno) FROM Servicios.Cliente"), conn);
            SqlDataReader reader3 = comando3.ExecuteReader();
            cbCliente1.Items.Clear();
            cbCliente2.Items.Clear();
            while (reader3.Read())
            {
                cbCliente1.Items.Add(reader3.GetString(0));
                cbCliente2.Items.Add(reader3.GetString(0));
            }
            reader3.Close();

            SqlCommand comando4 = new SqlCommand(
                string.Format("SELECT CONCAT(IdEmpleado, '_', PrimerNombre, ' ', SegundoNombre, ' ' , ApellidoPaterno, ' ', ApellidoMaterno) FROM Empleado.Empleado"), conn);
            SqlDataReader reader4 = comando4.ExecuteReader();
            cbEmpleado1.Items.Clear();
            cbEmpleado2.Items.Clear();
            cbEmpleado4.Items.Clear();
            while (reader4.Read())
            {
                cbEmpleado1.Items.Add(reader4.GetString(0));
                cbEmpleado2.Items.Add(reader4.GetString(0));
                cbEmpleado4.Items.Add(reader4.GetString(0));
            }
            reader4.Close();

            dataGridView4.DataSource = cliente.muestra();
            dataGridView3.DataSource = tipo.muestra();
            dataGridView7.DataSource = entrega.muestra();
            dataGridView5.DataSource = venta.muestra();
            dataGridView6.DataSource = renta.muestra();
        }

        private void Clear()
        {
            buttonModificarC.Enabled = false;
            buttonEliminarC.Enabled = false;
            buttonModificarE.Enabled = false;
            buttonEliminarE.Enabled = false;
            buttonModificarEE.Enabled = false;
            buttonEliminarEE.Enabled = false;
            buttonModificarR.Enabled = false;
            buttonEliminarR.Enabled = false;
            buttonModificarT.Enabled = false;
            buttonEliminarT.Enabled = false;
            buttonModificarV.Enabled = false;
            buttonEliminarV.Enabled = false;
            buttonModificarVV.Enabled = false;
            buttonEliminarVV.Enabled = false;

            textBoxPlacas.Text="";
            textBoxMarca.Text="";
            textBoxModelo.Text="";
            textBoxAno.Text="";
            cbTipo.Text="";
            textBoxVenta.Text="";
            textBoxRenta.Text="";
            textBoxNumSeguro.Text="";
            textBoxDesVeh.Text="";

            textBoxPNombreE.Text="";
            textBoxSNombreE.Text="";
            textBoxAPaternoE.Text="";
            textBoxAMaternoE.Text="";
            textBoxDomicilioE.Text="";
            textBox7.Text="";
            textBoxTelefonoE.Text="";

            textBoxTipo.Text="";
            textBoxSueldo.Text="";

            textBoxPNombreC.Text ="";
            textBoxSNombreC.Text="";
            textBoxAPaternoC.Text="";
            textBoxAMaternoC.Text="";
            textBoxDomicilioC.Text="";
            textBoxTelefonoC.Text="";
            textBoxNumTarjeta.Text="";
            textBoxEmail.Text="";

            textBoxIdClienteV.Text="";
            textBoxIdEmpleadoV.Text="";
            textBoxIdVehiculoV.Text="";
            

            textBox2.Text="";
            textBox1.Text="";
            textBox3.Text="";
            
            comboBox11.Text = "Mes";
            comboBox10.Text = "Dia";
            comboBox9.Text="Año";

            textBoxIdRenta.Text="";
            textBoxIdEmpleadoE.Text="";
            comboBox14.Text = "Mes";
            comboBox13.Text = "Dia";
            comboBox12.Text="Año";
            textBoxCargos.Text="";
            textBoxDescripcionM.Text="";
            textBox8.Text="";
        }

        private void dataGridView7_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            buttonModificarEE.Enabled = true;
            buttonEliminarEE.Enabled = true;
            entrega.id = Int64.Parse(dataGridView7.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBoxIdRenta.Text = dataGridView7.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxIdEmpleadoE.Text = dataGridView7.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox14.Text = dataGridView7.Rows[e.RowIndex].Cells[3].Value.ToString().Split('/')[1];
            comboBox13.Text = dataGridView7.Rows[e.RowIndex].Cells[3].Value.ToString().Split('/')[0];
            comboBox12.Text = dataGridView7.Rows[e.RowIndex].Cells[3].Value.ToString().Split('/')[2];
            textBoxCargos.Text = dataGridView7.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBoxDescripcionM.Text = dataGridView7.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox8.Text = dataGridView7.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void dataGridView6_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            buttonModificarR.Enabled = true;
            buttonEliminarR.Enabled = true;
            renta.id = Int64.Parse(dataGridView6.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox3.Text = dataGridView6.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView6.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox1.Text = dataGridView6.Rows[e.RowIndex].Cells[3].Value.ToString();
            
            comboBox11.Text = dataGridView6.Rows[e.RowIndex].Cells[5].Value.ToString().Split('/')[1];
            comboBox10.Text = dataGridView6.Rows[e.RowIndex].Cells[5].Value.ToString().Split('/')[0];
            comboBox9.Text = dataGridView6.Rows[e.RowIndex].Cells[5].Value.ToString().Split('/')[2];
        }

        private void dataGridView5_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            buttonModificarVV.Enabled = true;
            buttonEliminarVV.Enabled = true;
            venta.id = Int64.Parse(dataGridView5.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBoxIdVehiculoV.Text = dataGridView5.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxIdClienteV.Text = dataGridView5.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBoxIdEmpleadoV.Text = dataGridView5.Rows[e.RowIndex].Cells[3].Value.ToString();
            
        }

        private void dataGridView4_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            buttonModificarC.Enabled = true;
            buttonEliminarC.Enabled = true;
            cliente.id = Int64.Parse(dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBoxPNombreC.Text = dataGridView4.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxSNombreC.Text = dataGridView4.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBoxAPaternoC.Text = dataGridView4.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBoxAMaternoC.Text = dataGridView4.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBoxDomicilioC.Text = dataGridView4.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBoxTelefonoC.Text = dataGridView4.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBoxNumTarjeta.Text = dataGridView4.Rows[e.RowIndex].Cells[8].Value.ToString();
            textBoxEmail.Text = dataGridView4.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void dataGridView3_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            buttonModificarT.Enabled = true;
            buttonEliminarT.Enabled = true;
            tipo.id = Int64.Parse(dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBoxTipo.Text = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBoxSueldo.Text = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void dataGridView2_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            buttonModificarE.Enabled = true;
            buttonEliminarE.Enabled = true;
            empleado.id = Int64.Parse(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBoxPNombreE.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBoxSNombreE.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBoxAPaternoE.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBoxAMaternoE.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBoxDomicilioE.Text = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox7.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxTelefonoE.Text = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            buttonModificarV.Enabled = true;
            buttonEliminarV.Enabled = true;
            vehiculo.id = Int64.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBoxPlacas.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxMarca.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBoxModelo.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBoxAno.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            cbTipo.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            //comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            textBoxVenta.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            textBoxRenta.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            textBoxNumSeguro.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBoxDesVeh.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void cbVehiculo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            String id2 = cbVehiculo2.SelectedItem.ToString();
            var id = id2.ToCharArray()[0];
            textBox3.Text = id.ToString();
        }

        private void cbVehiculo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String id2 = cbVehiculo1.SelectedItem.ToString();
            var id = id2.ToCharArray()[0];
            textBoxIdVehiculoV.Text = id.ToString();
        }

        private void cbCliente1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String id2 = cbCliente1.SelectedItem.ToString();
            var id = id2.ToCharArray()[0];
            textBoxIdClienteV.Text = id.ToString();
        }

        private void cbEmpleado1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String id2 = cbEmpleado1.SelectedItem.ToString();
            var id = id2.ToCharArray()[0];
            textBoxIdEmpleadoV.Text = id.ToString();
        }

        private void cbCliente2_SelectedIndexChanged(object sender, EventArgs e)
        {
            String id2 = cbCliente2.SelectedItem.ToString();
            var id = id2.ToCharArray()[0];
            textBox2.Text = id.ToString();
        }

        private void cbEmpleado2_SelectedIndexChanged(object sender, EventArgs e)
        {
            String id2 = cbEmpleado2.SelectedItem.ToString();
            var id = id2.ToCharArray()[0];
            textBox1.Text = id.ToString();
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            String id2 = cbTipo.SelectedItem.ToString();
            var id = id2.ToCharArray()[0];
            textBox7.Text = id.ToString();
        }

        private void cbEmpleado4_SelectedIndexChanged(object sender, EventArgs e)
        {
            String id2 = cbEmpleado4.SelectedItem.ToString();
            var id = id2.ToCharArray()[0];
            textBoxIdEmpleadoE.Text = id.ToString();
        }
    }
}
