using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VISTA
{
    public partial class frmUsuarios : Form
    {
        private static frmUsuarios instancia;
        CONTROLADORA.cUsuarios cUSUARIOS;
        frmUsuario formUsuario;
        public static frmUsuarios obtener_instancia(MODELO.usuario oUSUARIO)
        {
            if (instancia == null)
                instancia = new frmUsuarios(oUSUARIO);
            if (instancia.IsDisposed)
                instancia = new frmUsuarios(oUSUARIO);

            return instancia;
        }

        private frmUsuarios(MODELO.usuario oUSUARIO)
        {
            InitializeComponent();
            cUSUARIOS = CONTROLADORA.cUsuarios.obtenerInstancia();
            botonera1.ARMA_PERFIL("frmUsuarios", oUSUARIO); 
        }

        private void frmGRUPOS_Load(object sender, EventArgs e)
        {
            ARMA_LISTA();
        }

        private void ARMA_LISTA()
        {
            dgvDATA.DataSource = null;
            dgvDATA.DataSource = cUSUARIOS.ObtenerUsuarios();
            dgvDATA.Columns[0].HeaderText = "USUARIO";
            dgvDATA.Columns[1].HeaderText = "NOMBRE";
            dgvDATA.Columns[2].Visible = false;
            dgvDATA.Columns[3].HeaderText = "ESTADO";
            dgvDATA.Columns[4].Visible = false;
        }

        private void botonera1_Click_Alta(object sender, EventArgs e)
        {
            formUsuario = new frmUsuario("A", new MODELO.usuario());
            DialogResult dr = formUsuario.ShowDialog();
            if (dr == DialogResult.OK)
                ARMA_LISTA();
        }

        private void botonera1_Click_Baja(object sender, EventArgs e)
        {
            if (dgvDATA.CurrentRow == null)
                return;

            try
            {
                MODELO.usuario  oUsu = (MODELO.usuario )dgvDATA.CurrentRow.DataBoundItem;
                oUsu.usu_estado  = false;
                cUSUARIOS.MODIFICACION (oUsu);
                ARMA_LISTA();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
            }
        }

        private void botonera1_Click_Cerrar(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botonera1_Click_Consulta(object sender, EventArgs e)
        {
            if (dgvDATA.CurrentRow == null)
                return;
            formUsuario = new frmUsuario("C", (MODELO.usuario )dgvDATA.CurrentRow.DataBoundItem);
            DialogResult dr = formUsuario.ShowDialog();
        }

        private void botonera1_Click_Modificacion(object sender, EventArgs e)
        {
            if (dgvDATA.CurrentRow == null)
                return;
            formUsuario = new frmUsuario("M", (MODELO.usuario)dgvDATA.CurrentRow.DataBoundItem);
            DialogResult dr = formUsuario.ShowDialog();
            if (dr == DialogResult.OK)
                ARMA_LISTA();
        }

        private void botonera1_Load(object sender, EventArgs e)
        {

        }
    }
}
