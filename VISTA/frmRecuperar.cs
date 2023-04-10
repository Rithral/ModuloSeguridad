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
    public partial class frmRecuperar : Form
    {
        CONTROLADORA.cUsuarios cUsuario;
        MODELO.usuario oUsuario;

        public frmRecuperar()
        {
            InitializeComponent();
            cUsuario = CONTROLADORA.cUsuarios.obtenerInstancia();
        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMail.Text))
            {
                MessageBox.Show("Debe ingresar una direccion de mail");
                return;
            }

            try
            {
                oUsuario = cUsuario.ObtenerMail(txtMail.Text);

                oUsuario.usu_clave = cUsuario.ClaveAleatoria();

                cUsuario.EnviarEmail(oUsuario.usu_email, oUsuario.usu_nombre, oUsuario.usu_clave);

                oUsuario.usu_clave = cUsuario.EncriptarClave(oUsuario.usu_clave);


                cUsuario.MODIFICACION(oUsuario);

                MessageBox.Show("Se ha enviado un mail a " + oUsuario.usu_email, "Recuperar clave");

                this.DialogResult = DialogResult.OK;

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Recuperacion de clave", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }
        
        


    }
}
