using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace VISTA
{
    public partial class frmPRINCIPAL : Form
    {
        MODELO.usuario oUSUARIO;
        CONTROLADORA.cPERFIL cPERFIL;
        private Form miFORM;
        public frmPRINCIPAL(MODELO.usuario mUsuario)
        {
            InitializeComponent();
            cPERFIL = CONTROLADORA.cPERFIL.obtenerInstancia();

            oUSUARIO = mUsuario;
            tslUSUARIO.Text = oUSUARIO.usu_nombre;
            ToolStripDropDownButton MENU_MODULO;



            foreach (MODELO.modulo oMODULO in cPERFIL.ObtenerModulos())
            {
                MENU_MODULO = new ToolStripDropDownButton();
                MENU_MODULO.Name = oMODULO.mod_codigo;
                MENU_MODULO.Text = oMODULO.mod_descripcion;
                msMENU.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { MENU_MODULO });

                ARMA_FUNCIONES("a", oMODULO, MENU_MODULO);
            }
        }

        private void frmPRINCIPAL_Load(object sender, EventArgs e)
        {
            /*/   frmLogin formLOGIN = new frmLogin();
               DialogResult drLOGIN = formLOGIN.ShowDialog();

               if (drLOGIN != DialogResult.OK)
               {
                   Application.Exit();
                   return;
               }
               oUSUARIO = formLOGIN.USUARIO;
               tslUSUARIO.Text = oUSUARIO.usu_nombre;           
               ToolStripDropDownButton MENU_MODULO;

           

               foreach (MODELO.modulo oMODULO in cPERFIL.ObtenerModulos())
               {              
                   MENU_MODULO = new ToolStripDropDownButton();             
                   MENU_MODULO.Name = oMODULO.mod_codigo;
                   MENU_MODULO.Text = oMODULO.mod_descripcion;              
                   msMENU.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { MENU_MODULO });
              
                   ARMA_FUNCIONES("a",oMODULO, MENU_MODULO);
               }/*/
        }
        private void ARMA_FUNCIONES(string flag, MODELO.modulo  MODULO, ToolStripDropDownButton MEN_FUNCION)
        {
            
            ToolStripMenuItem MENU_FUNCIONES;

        
              
           
           
            foreach (MODELO.formulario oFORM in cPERFIL.obtenerFormularios(oUSUARIO,MODULO))
            {
              
                MENU_FUNCIONES = new ToolStripMenuItem();
                MENU_FUNCIONES.Name = oFORM.frm_codigo.ToString();
                MENU_FUNCIONES.Text = oFORM.frm_descripcion;
                MENU_FUNCIONES.Tag = oFORM.frm_formulario;

              
                MEN_FUNCION.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { MENU_FUNCIONES });

              
                MENU_FUNCIONES.Click += new EventHandler(this.ITEM_CLICK);
            }
        }

        private void ITEM_CLICK(object sender, EventArgs e)
        {
          
            ToolStripMenuItem seleccion = (ToolStripMenuItem)sender;
           
            if ((string)seleccion.Tag != "0")
            {
                
                foreach (System.Type type in Assembly.GetExecutingAssembly().GetTypes())
                {
                  
                    if (type.IsSubclassOf(typeof(Form)))
                    {
                       
                        if (type.Name.ToString() == (string)seleccion.Tag)
                        {
                            try
                            {
                              
                                Type t = type as Type;
                              
                                miFORM = (Form)t.InvokeMember("obtener_instancia", BindingFlags.Default | BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.InvokeMethod, null, null, new object[] { this.oUSUARIO }) as System.Windows.Forms.Form;
                             
                                miFORM.Show();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                }
            }
        }

        private void btnRelogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin formLOGIN = new frmLogin();
            formLOGIN.ShowDialog();
                this.Close();

         

      
        }        
    }
}
