using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using rivadavia.BLL;
using rivadavia.DAL;
using System.IO;

namespace rivadavia.PL
{
    public partial class frmJugadores : Form
    {

        byte[] imagenByte;

        JugadoresDAL oJugadoresDAL;

        public frmJugadores()
        {
            oJugadoresDAL = new JugadoresDAL();
            InitializeComponent();
            LlenarGrid();
            LimpiarEntradas();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            oJugadoresDAL.Agregar(RecuperarInformacion());
            LlenarGrid();
        }

        private JugadoresBLL RecuperarInformacion()
        {
            JugadoresBLL oJugadoresBLL = new JugadoresBLL();
 
            int ID = 0; int.TryParse(txtID.Text, out ID);
            oJugadoresBLL.ID = ID;
            oJugadoresBLL.NombreJugador = txtNombre.Text;
            oJugadoresBLL.PrimerApellido = txtPrimerApellido.Text;
            oJugadoresBLL.SegundoApellido = txtSegundoApellido.Text;
            int DNI = 0; int.TryParse(txtDNI.Text, out DNI);
            oJugadoresBLL.DNI = DNI;
            int Tel1 = 0; int.TryParse(txtTel1.Text, out Tel1);
            oJugadoresBLL.Telefono1 = Tel1;
            int Tel2 = 0; int.TryParse(txtTel2.Text, out Tel2);
            oJugadoresBLL.Telefono2 = Tel2;
            oJugadoresBLL.Correo = txtCorreo.Text;
            int FInicio = 0; int.TryParse(txtInicio.Text, out FInicio);
            oJugadoresBLL.FechaInicio = FInicio;
            int FSalida = 0; int.TryParse(txtSalida.Text, out FSalida);
            oJugadoresBLL.FechaSalida = FSalida;

            return oJugadoresBLL;
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;

            dgvJugadores.ClearSelection();

            if (indice>=0)
            {
            txtID.Text = dgvJugadores.Rows[indice].Cells[0].Value.ToString();
            txtNombre.Text = dgvJugadores.Rows[indice].Cells[1].Value.ToString();
            txtPrimerApellido.Text = dgvJugadores.Rows[indice].Cells[2].Value.ToString();
            txtSegundoApellido.Text = dgvJugadores.Rows[indice].Cells[3].Value.ToString();
            txtDNI.Text = dgvJugadores.Rows[indice].Cells[6].Value.ToString();
            txtTel1.Text = dgvJugadores.Rows[indice].Cells[7].Value.ToString();
            txtTel2.Text = dgvJugadores.Rows[indice].Cells[8].Value.ToString();
            txtCorreo.Text = dgvJugadores.Rows[indice].Cells[4].Value.ToString();
            txtInicio.Text = dgvJugadores.Rows[indice].Cells[9].Value.ToString();
            txtSalida.Text = dgvJugadores.Rows[indice].Cells[10].Value.ToString();
            

            btnAgregar.Enabled = false;
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
            btnCuota.Enabled = true;
            btnCancelar.Enabled = true;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oJugadoresDAL.Eliminar(RecuperarInformacion());
            LlenarGrid();
            LimpiarEntradas();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            oJugadoresDAL.Modificar(RecuperarInformacion());
            LlenarGrid();
            LimpiarEntradas();
        }

        public void LlenarGrid()
        {
            dgvJugadores.DataSource = oJugadoresDAL.MostrarJugadores().Tables[0];
          

            dgvJugadores.Columns[0].HeaderText = "ID";
            dgvJugadores.Columns[1].HeaderText = "Nombre Jugador";
            dgvJugadores.Columns[2].HeaderText = "Apellido Jugador";

            dgvJugadores.Columns[5].Visible = false;
        }

        public void LimpiarEntradas()
        {
            txtID.Text = "";
            txtNombre.Text = "";
            txtPrimerApellido.Text = "";

            btnAgregar.Enabled = true;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnCuota.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarEntradas();
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog selecImagen = new OpenFileDialog();
            selecImagen.Title = "Seleccionar imagen";

            if(selecImagen.ShowDialog() == DialogResult.OK)
            {
                picFoto.Image = Image.FromStream(selecImagen.OpenFile());
                MemoryStream memoria = new MemoryStream();
                picFoto.Image.Save(memoria, System.Drawing.Imaging.ImageFormat.Png);

                imagenByte = memoria.ToArray();
            }

        }
    }
}
