using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmVentanaPrincipal : Form
    {
        public frmVentanaPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cargar();

        }
        private void Cargar()
        {
            ArticuloNegocio artNeg = new ArticuloNegocio();
            dgvArticulo.DataSource = artNeg.Listar();
        }

        private void dgvArticulo_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmABM abm = new frmABM();
            abm.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmABM abm = new frmABM();
            abm.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            seleccionado = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;
            frmABM abm = new frmABM(seleccionado);
            abm.ShowDialog();
        }
    }
}
