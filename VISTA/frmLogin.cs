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
    public partial class frmLogin : Form
    {
        CONTROLADORA.cLogin oLOGIN;
        CONTROLADORA.cPERFIL cPERFIL;
        MODELO.usuario oUSUARIO;
        public MODELO.usuario USUARIO
        {
            get { return oUSUARIO; }
        }

/*/        private static frmLogin instancia;

        public static frmLogin obtener_instancia()
        {
            if (instancia == null)
                instancia = new frmLogin();
            if (instancia.IsDisposed)
                instancia = new frmLogin();

            return instancia;
        }
        /*/
        public frmLogin()
        {
            InitializeComponent();
            oLOGIN = CONTROLADORA.cLogin.obtenerInstancia();
           cPERFIL = CONTROLADORA.cPERFIL.obtenerInstancia();
        }

        private void btnCANCELAR_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnINGRESAR_Click(object sender, EventArgs e)
        {
            if (txtUSUARIO.Text == "")
            {
                lblUserNameError.Text = "* Debe ingresar el nombre de usuario";
                return;
            }
            else
            {
                lblUserNameError.Text = "";
            }
            if (txtPASSWORD.Text == "")
            {
                lblPasswordError.Text = "* Debe ingresar la contraseña";
                return;
            }
            else
            {
                lblPasswordError.Text = "";
            }
            try
            {
                string pass;

                pass = oLOGIN.EncriptarClave(txtPASSWORD.Text);
                
                oUSUARIO = oLOGIN.LOGIN(txtUSUARIO.Text, pass);
             //  this.DialogResult = DialogResult.OK;

                this.Hide();

                frmPRINCIPAL formPrincipal = new frmPRINCIPAL(oUSUARIO);
                formPrincipal.ShowDialog();

                this.Close();
               
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message,"Ingreso al sistema",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }
        }

        private void btnRecup_Click(object sender, EventArgs e)
        {
            frmRecuperar formRecuperar = new frmRecuperar();
            DialogResult drRecuperar = formRecuperar.ShowDialog();
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
