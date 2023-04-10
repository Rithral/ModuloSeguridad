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
    public partial class frmPassword : Form
    {
        private static frmPassword instancia;
        private MODELO.usuario oUSUARIO;
        private CONTROLADORA.cPassword cPASSWORD;

        public static frmPassword obtener_instancia(MODELO.usuario miUSUARIO)
        {            
            if (instancia == null)
                instancia = new frmPassword(miUSUARIO);
            if (instancia.IsDisposed)
                instancia = new frmPassword(miUSUARIO);
            return instancia;

            
        }
        private frmPassword(MODELO.usuario miUSUARIO)
        {
            InitializeComponent();
            oUSUARIO = miUSUARIO;
            cPASSWORD = CONTROLADORA.cPassword.obtenerInstancia();
        }


        private void frmPASSWORD_Load(object sender, EventArgs e)
        {

        }

        private void btnGUARDAR_Click(object sender, EventArgs e)
        {
            if (cPASSWORD.EncriptarClave(txtAnterior.Text) != oUSUARIO.usu_clave)
            {
                MessageBox.Show("La contraseñas actual no coincide con la ingresada", "ATENCION!!");
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
            else
            {
                MessageBox.Show("Debe ingresar una nueva contraseña", "ATENCION!!");
                return;
            }

            try
            {
                string clave;
                clave = cPASSWORD.EncriptarClave(txtPASSWORD.Text);
                oUSUARIO.usu_clave = clave;
                cPASSWORD.MODIFICACION(oUSUARIO);
                MessageBox.Show("Se ha actualizado la contraseña", "Cambiar contraseña");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message, "ATENCION !!");
            }
        }

        private void btnCANCELAR_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
