using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace SistemaDeVentasFerreteria
{
    public partial class Form1 : Form
    {
        double precio = 0;
        int envio = 0;
        double totalAPagar = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Lo que hace este label es colocar la Fecha actual 
            lblFecha2.Text = DateTime.Today.Date.ToString("d");
            
            // Carga de Items del Combo Box productos
            cboProductos.Items.Add("Bisagras");
            cboProductos.Items.Add("Cable pasa corriente truper 3m");
            cboProductos.Items.Add("Convertidor de Oxido");
            cboProductos.Items.Add("Cerradura");
            cboProductos.Items.Add("Caja de clavos punta paris");
            cboProductos.Items.Add("Discos de corte");
            cboProductos.Items.Add("Foco voltech 15w triple");
            cboProductos.Items.Add("Foco voltech 28w cuadruple");
            cboProductos.Items.Add("Foco voltech 28w espiral");
            cboProductos.Items.Add("Electrodos x 1kg");
            cboProductos.Items.Add("Escuadra");
            cboProductos.Items.Add("Linternas");
            cboProductos.Items.Add("Martillo");
            cboProductos.Items.Add("Pincel");
            cboProductos.Items.Add("Pasador porta candado");
            cboProductos.Items.Add("Plomada");
            cboProductos.Items.Add("Rodillos");
            cboProductos.Items.Add("Tinner");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            envio = 200;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            envio = 0;
        }

        private void cboProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string producto = cboProductos.Text;

            if (producto.Equals("Bisagras")) precio = 160;
            if (producto.Equals("Cable pasa corriente truper 3m")) precio = 479.99;
            if (producto.Equals("Convertidor de Oxido")) precio = 700;
            if (producto.Equals("Cerradura")) precio = 2500;
            if (producto.Equals("Caja de clavos punta paris")) precio = 363.33;
            if (producto.Equals("Discos de corte")) precio = 150;
            if (producto.Equals("Foco voltech 15w triple")) precio = 38;
            if (producto.Equals("Foco voltech 28w cuadruple")) precio = 50;
            if (producto.Equals("Foco voltech 28w espiral")) precio = 69.99;
            if (producto.Equals("Electrodos x 1kg")) precio = 8.50;
            if (producto.Equals("Escuadra")) precio = 600;
            if (producto.Equals("Linternas")) precio = 80;
            if (producto.Equals("Martillo")) precio = 1200;
            if (producto.Equals("Pincel")) precio = 120;
            if (producto.Equals("Pasador porta candado")) precio = 2000;
            if (producto.Equals("Plomada")) precio = 2500;
            if (producto.Equals("Rodillos")) precio = 140;
            if (producto.Equals("Tinner")) precio = 255.55;

            lblPrecio2.Text = "$" + precio;
        }
        
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Validando
	        if (txtNombre.Text == "")
                MessageBox.Show("Falta completar los datos del cliente.");
            else if (txtApellido.Text == "")
                MessageBox.Show("Falta completar los datos del cliente.");
            else if (txtDomicilio.Text == "")
                MessageBox.Show("Falta completar los datos del cliente.");
            else if (txtTelefono.Text == "")
                MessageBox.Show("Falta completar los datos del cliente.");
            else if (cboProductos.SelectedIndex == -1)
                MessageBox.Show("Debe seleccionar un producto.");
            else if (cboTipoDePago.SelectedIndex == -1)
                MessageBox.Show("Debe seleccionar un Tipo de pago.");
            else if (txtCantidad.Text == "")
                MessageBox.Show("Debe seleccionar una cantidad.");
            else
            {
                // Captura de datos
                string producto = cboProductos.Text;
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                string tipoDePago = cboTipoDePago.Text;

                // Calculos
                double subtotal = cantidad * precio;
                double descuento = 0, recargo = 0, precioFinal = 0;

                if (tipoDePago.Equals("Contado"))
                    descuento = 0.3 * subtotal;
                else
                    recargo = 0.1 * subtotal;

                precioFinal = (subtotal - descuento + recargo) + envio;

                totalAPagar = totalAPagar + precioFinal;
                Convert.ToString(totalAPagar);

                // Imprimir resultados
                ListViewItem fila = new ListViewItem(producto);
                fila.SubItems.Add(cantidad.ToString());
                fila.SubItems.Add(precio.ToString("0.00"));
                fila.SubItems.Add(tipoDePago);
                fila.SubItems.Add(descuento.ToString("0.00"));
                fila.SubItems.Add(recargo.ToString("0.00"));
                if (envio == 0)
                {
                    fila.SubItems.Add(envio.ToString("-"));
                }
                else
                {
                    fila.SubItems.Add(envio.ToString("0.00"));

                }

                fila.SubItems.Add(precioFinal.ToString("0.00"));

                listViewRegistros.Items.Add(fila);

                lblTotal.Text = "Total a pagar: $" + totalAPagar.ToString("0.00");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cboProductos.Text = "Seleccione producto";
            cboTipoDePago.Text = "Seleccione tipo";
            txtCantidad.Text = "0";
            lblPrecio2.Text = "0";
            cboProductos.Focus();
        }
        
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void btnCreditos_Click(object sender, EventArgs e)
        {
        

            Form creditos = new Form2();
            creditos.Show();

        }
    }
}
