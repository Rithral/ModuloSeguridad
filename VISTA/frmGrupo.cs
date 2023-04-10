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
    public partial class frmGrupo : Form
    {
        string MODO;
        CONTROLADORA.cGrupos cGRUPOS;

        MODELO.grupo  oGRUPO;
        MODELO.formulario oFormulario;
        MODELO.perfil oPerfil;
        bool checkear;
        bool checkearA;
        public frmGrupo(string fMODO, MODELO.grupo miGRUPO)
        {
            InitializeComponent();
            cGRUPOS = CONTROLADORA.cGrupos.obtenerInstancia();
            
            MODO = fMODO;
            oGRUPO = miGRUPO;
            chkPermisos.Enabled = true;

            if (MODO != "A")
            {
                txtCODIGO.Text = oGRUPO.gru_codigo ;
                txtDESCRIPCION.Text = oGRUPO.gru_descripcion;
                chkEstado.Checked = oGRUPO.gru_estado;
               txtCODIGO.Enabled = false;
               if (MODO == "C")
               {
                   btnGUARDAR.Enabled = false;
                   btnCANCELAR.Text = "Cerrar";
                   chkPermisos.Enabled = false;
               }
            }

        }

        private void frmGrupo_Load(object sender, EventArgs e)
        {
            cmbFORMULARIO.DataSource = cGRUPOS.obtenerFormulario();
            cmbFORMULARIO.DisplayMember = "frm_descripcion";

            oFormulario = (MODELO.formulario)cmbFORMULARIO.SelectedItem;

            chkUSUARIOS.DataSource = null;
            chkUSUARIOS.DataSource = cGRUPOS.obtenerUsuarios();
            chkUSUARIOS.DisplayMember = "usu_nombre";

          

            checkearA = false;
            for (int i = 0; i < chkUSUARIOS.Items.Count; i++)
            {
                MODELO.usuario oUsuario = (MODELO.usuario) chkUSUARIOS.Items[i];
                foreach (MODELO.usuario miUsuario in oGRUPO.usuario.ToList())
                {
                    if (miUsuario.usu_codigo == oUsuario.usu_codigo)
                    {
                        chkUSUARIOS.SetItemChecked(i, true);
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
                MessageBox.Show("Debe ingresar el código del grupo", "ATENCION!!");
                return;
            }

            if (string.IsNullOrEmpty(txtDESCRIPCION.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del grupo","ATENCION!!");
                return;
            }

            try
            {
                
                oGRUPO.gru_descripcion  = txtDESCRIPCION.Text;
                oGRUPO.gru_estado = chkEstado.Checked;
                if (MODO == "A")
                {

                    
                    oGRUPO.gru_codigo = txtCODIGO.Text;
                    cGRUPOS.Alta(oGRUPO);
                }
                else
                {
                    cGRUPOS.Modificacion(oGRUPO);
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message.ToString());
            }
        }

        private void chkPermisos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
            
            if (checkear == false) return;
            oFormulario = (MODELO.formulario)cmbFORMULARIO.SelectedItem;
            MODELO.permiso oPermiso = (MODELO.permiso)chkPermisos.SelectedItem;
            MODELO.perfil oPerfil = oGRUPO.perfil.FirstOrDefault(P => P.formulario == oFormulario);
           
            if (oPerfil == null)
            {
                oPerfil = new MODELO.perfil();
                oPerfil.grupo = oGRUPO;
                oPerfil.formulario = oFormulario;
                
            }

            if (e.NewValue == CheckState.Checked)
            {
                

                oPerfil.permiso.Add(oPermiso);
                checkear = true;
            }
            else
            {
                oPerfil.permiso.Remove(oPermiso);
                checkear = true;
            }
        }

        private void chkUSUARIOS_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (checkear == false) return;

            MODELO.usuario oUSUARIO = (MODELO.usuario) chkUSUARIOS.SelectedItem;
            if (e.NewValue == CheckState.Checked)
            {
                oGRUPO.usuario.Add (oUSUARIO);
            }
            else
            {
                oGRUPO.usuario.Remove(oUSUARIO);
            }
        }

        private void cmbFORMULARIO_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            oFormulario = (MODELO.formulario)cmbFORMULARIO.SelectedItem;
            chkPermisos.DataSource = null;
            chkPermisos.DataSource = oFormulario.permiso.ToList();
            chkPermisos.DisplayMember = "per_descripcion";

            checkear = false;

            for (int i = 0; i < chkPermisos.Items.Count; i++)
            {
                MODELO.permiso oPermiso = (MODELO.permiso)chkPermisos.Items[i];

                MODELO.perfil oPerfil = oGRUPO.perfil.FirstOrDefault(P => P.formulario == oFormulario);

                if (oPerfil != null)
                {

                    foreach (MODELO.permiso miPermiso in oPerfil.permiso.ToList())
                    {
                        if (miPermiso == oPermiso)
                        {
                            chkPermisos.SetItemChecked(i, true);
                        }
                    }
                }
            }
            checkear = true;

        }
        
        private void chkPermisos_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {

        }

    }
}
