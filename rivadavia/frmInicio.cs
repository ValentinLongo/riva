using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using rivadavia.PL;

namespace rivadavia
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmJugadores formJugadores = new frmJugadores();
            formJugadores.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmMovimientos formMovimientos = new frmMovimientos();
            formMovimientos.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmCaja formCaja = new frmCaja();
            formCaja.Show();
        }
    }
}
