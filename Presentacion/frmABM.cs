using Dominio;
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
    public partial class frmABM : Form
    {
        Articulo articulo;
        public frmABM()
        {
            InitializeComponent();
        }
        public frmABM(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            
        }

        private void ABM_Load(object sender, EventArgs e)
        {
            if (articulo != null)
            {
                lblTituloABM.Text = "Modificar un artículo:";
            }
            else
                lblTituloABM.Text = "Agregar un artículo:";
            
        }
    }
}
