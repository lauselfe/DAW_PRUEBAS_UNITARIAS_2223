using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GestionBancariaAppNS
{
    public partial class GestionBancariaApp : Form
    {
        //LSF1DAWY
        private double saldo;  
        public  const string ERR_CANTIDAD_NO_VALIDA = "Cantidad no válida.";
        public  const string  ERR_SALDO_INSUFICIENTE = "Saldo insuficiente.";
        //LSF1DAWY
        public GestionBancariaApp(double saldo = 0)
        {
            //LSF1DAWY
            InitializeComponent();
            if (saldo > 0)
                this.saldo = saldo;
            else
                this.saldo = 0;
            txtSaldo.Text = obtenerSaldo().ToString();
            txtCantidad.Text = "0";
        }
        //LSF1DAWY
        public double obtenerSaldo() { return saldo; }
        //LSF1DAWY
        public void  realizarReintegro(double cantidad) 
        {
            //LSF1DAWY
            if (cantidad <= 0)
            {
                throw new ArgumentOutOfRangeException(ERR_CANTIDAD_NO_VALIDA);
            }
               
            if (saldo < cantidad)
            {
                throw new ArgumentOutOfRangeException(ERR_SALDO_INSUFICIENTE);

            }

            saldo -= cantidad;
            //return 0;
        }

        public void realizarIngreso(double cantidad) {
            //LSF1DAWY
            if (cantidad <= 0)
            {
                throw new ArgumentOutOfRangeException(ERR_CANTIDAD_NO_VALIDA);
            }
            saldo += cantidad;
            //return 0;
        }

        private void btOperar_Click(object sender, EventArgs e)
        {
            //LSF1DAWY
            double cantidad = Convert.ToDouble(txtCantidad.Text);
            if (rbReintegro.Checked)
            {
                try
                {
                    realizarReintegro(cantidad);
                    MessageBox.Show("Transacción realizada.");
                }
                catch (Exception exception)
                {
                    if (exception.Message.Equals(ERR_SALDO_INSUFICIENTE))
                        MessageBox.Show("No se ha podido realizar la operación (¿Saldo insuficiente ?)");
                    else
                    if (exception.Message.Equals(ERR_CANTIDAD_NO_VALIDA))
                        MessageBox.Show("Cantidad no válida, sólo se admiten cantidades positivas.");
}
            }
            else
            {
                try
                {
                    realizarIngreso(cantidad);
                    MessageBox.Show("Transacción realizada.");
                }
                catch (Exception exception)
                {
                    if (exception.Message.Equals(ERR_CANTIDAD_NO_VALIDA))
                        MessageBox.Show("Cantidad no válida, sólo se admiten cantidades positivas.");
                 }
                txtSaldo.Text = obtenerSaldo().ToString();
            }
         }
    }
}
