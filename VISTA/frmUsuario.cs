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
    public partial class frmUsuario : Form
    {
        string MODO;
        CONTROLADORA.cUsuarios cUSUARIOS;
        MODELO.usuario oUSUARIO;
        bool checkearA;
        public frmUsuario(string fMODO, MODELO.usuario miUSUARIO)
        {
            InitializeComponent();
            cUSUARIOS = CONTROLADORA.cUsuarios.obtenerInstancia();
            MODO = fMODO;
            oUSUARIO = miUSUARIO;
            chkEstado.Enabled = true;

            if (MODO != "A")
            {
                txtCODIGO.Text = oUSUARIO.usu_codigo;
                txtNOMBRE.Text = oUSUARIO.usu_nombre;
                txtEMAIL.Text = oUSUARIO.usu_email;
                chkEstado.Checked = oUSUARIO.usu_estado;
                txtCODIGO.Enabled = false;
                if (MODO == "C")
                {
                    btnGUARDAR.Enabled = false;
                    btnCANCELAR.Text = "Cerrar";
                    chkEstado.Enabled = false;
                    chkGRUPOS.Enabled = false;                        
                }
            }
            else
            {
                chkEstado.Checked = true;
            }


        }

        private void frmGRUPO_Load(object sender, EventArgs e)
        {
            chkGRUPOS.DataSource = null;
            chkGRUPOS.DataSource = cUSUARIOS.ObtenerGrupos();
            chkGRUPOS.DisplayMember = "gru_descripcion";

            checkearA = false;
            for (int i = 0; i < chkGRUPOS.Items.Count; i++)
            {
                MODELO.grupo oGrupo = (MODELO.grupo)chkGRUPOS.Items[i];
                foreach (MODELO.grupo miGrupo in oUSUARIO.grupos)
                {
                    if (miGrupo.gru_codigo == oGrupo.gru_codigo)
                    {
                        chkGRUPOS.SetItemChecked(i, true);
                    }
                }
            }
            checkearA = true;
        }
        
        private void btnCANCELAR_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnGUARDAR_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCODIGO.Text))
            {
                MessageBox.Show("Debe ingresar el código del usuario", "ATENCION!!");
                return;
            }

            if (string.IsNullOrEmpty(txtNOMBRE.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del usuario","ATENCION!!");
                return;
            }

            if (string.IsNullOrEmpty(txtEMAIL.Text))
            {
                MessageBox.Show("Debe ingresar el email del usuario", "ATENCION!!");
                return;
            }

            if (!string.IsNullOrEmpty(txtPASSWORD.Text))
            {
                if (!string.Equals(txtPASSWORD.Text, txtPASSWORD2.Text))
                {
                    MessageBox.Show("Las contraseñas no coinciden", "ATENCION!!");
                    return;
                }
            }

            try
            {
                oUSUARIO.usu_codigo    = txtCODIGO.Text;
                oUSUARIO.usu_nombre   = txtNOMBRE.Text;
                oUSUARIO.usu_email = txtEMAIL.Text;
                oUSUARIO.usu_estado  = chkEstado.Checked;
                if (MODO == "A")
                {
                    if (!string.IsNullOrEmpty(txtPASSWORD.Text))
                    {
                        string clave;
                        clave =  cUSUARIOS.EncriptarClave(txtPASSWORD.Text);
                        oUSUARIO.usu_clave = clave;
                    }
                    else
                    {
                        string clave;
                        clave = cUSUARIOS.EncriptarClave(txtCODIGO.Text);
                        oUSUARIO.usu_clave = clave;
                    }
                    
                    cUSUARIOS.ALTA(oUSUARIO);
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtPASSWORD.Text))
                    {
                        oUSUARIO.usu_clave = txtPASSWORD.Text;
                    }
                    cUSUARIOS.MODIFICACION(oUSUARIO);
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message.ToString());
            }
        }

        private void chkGRUPOS_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (checkearA  == false) return;

            MODELO.grupo oGrupo = (MODELO.grupo)chkGRUPOS.SelectedItem;
            if (e.NewValue == CheckState.Checked)
            {
                oUSUARIO.grupos.Add(oGrupo);
            }
            else
            {
                oUSUARIO.grupos.Remove(oGrupo);
            }
        }

        private void chkGRUPOS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}