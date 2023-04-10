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
    public partial class frmGrupos : Form
    {
        private static frmGrupos instancia;
        CONTROLADORA.cGrupos cGRUPOS;
        frmGrupo formGrupo;
        public static frmGrupos obtener_instancia(MODELO.usuario oUSUARIO)
        {
            if (instancia == null)
                instancia = new frmGrupos(oUSUARIO);
            if (instancia.IsDisposed)
                instancia = new frmGrupos(oUSUARIO);

            return instancia;
        }

        private frmGrupos(MODELO.usuario oUSUARIO)
        {
            InitializeComponent();
            cGRUPOS = CONTROLADORA.cGrupos.obtenerInstancia();
            botonera1.ARMA_PERFIL("frmGrupos", oUSUARIO);
            
        }

        private void frmGRUPOS_Load(object sender, EventArgs e)
        {
            ARMA_LISTA();
        }

        private void ARMA_LISTA()
        {
            dgvDATA.DataSource = null;
            dgvDATA.DataSource = cGRUPOS.ObtenerGrupos();
            dgvDATA.Columns[0].HeaderText = "Codigo";
            dgvDATA.Columns[1].HeaderText = "Descripcion";
            dgvDATA.Columns[2].HeaderText = "Estado";
            dgvDATA.Columns[3].Visible = false;
            dgvDATA.Columns[4].Visible = false;
            

        }

        private void botonera1_Click_Alta(object sender, EventArgs e)
        {
            formGrupo = new frmGrupo ("A", new MODELO.grupo());
            DialogResult dr = formGrupo.ShowDialog();
            if (dr == DialogResult.OK)
                ARMA_LISTA();
        }

        private void botonera1_Click_Baja(object sender, EventArgs e)
        {
            if (dgvDATA.CurrentRow == null)
                return;

            try
            {
                MODELO.grupo oGrupo = (MODELO.grupo)dgvDATA.CurrentRow.DataBoundItem;
                oGrupo.gru_estado = false;
                cGRUPOS.Modificacion(oGrupo);
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
            formGrupo = new frmGrupo("C", (MODELO.grupo)dgvDATA.CurrentRow.DataBoundItem);
            DialogResult dr = formGrupo.ShowDialog();
        }

        private void botonera1_Click_Modificacion(object sender, EventArgs e)
        {
            if (dgvDATA.CurrentRow == null)
                return;
            formGrupo = new frmGrupo("M", (MODELO.grupo)dgvDATA.CurrentRow.DataBoundItem);
            DialogResult dr = formGrupo.ShowDialog();
            if (dr == DialogResult.OK)
                ARMA_LISTA();
        }

        private void botonera1_Load(object sender, EventArgs e)
        {

        }
    }
}
