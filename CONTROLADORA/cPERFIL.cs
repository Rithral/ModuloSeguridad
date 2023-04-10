using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace CONTROLADORA
{
    public class cPERFIL
    {
        private static cPERFIL instancia;
        private MODELO.CONTEXTO oModelo;
        public static cPERFIL obtenerInstancia()
        { 
            if (instancia == null)
                instancia = new cPERFIL();

            return instancia;
        }
        private cPERFIL()
        {
            oModelo = MODELO.CONTEXTO.obtenerInstancia();

            if (oModelo.modulos.ToList().Count == 0)
            {
                MODELO.modulo oMODULO = new MODELO.modulo();
                oMODULO.mod_codigo = "SEG";
                oMODULO.mod_descripcion = "Seguridad";
                oModelo.modulos.Add(oMODULO);

                MODELO.permiso permisoA = new MODELO.permiso();
                permisoA.per_codigo = "A";
                permisoA.per_descripcion = "Alta";
                oModelo.permisos.Add(permisoA);

                MODELO.permiso permisoB = new MODELO.permiso();
                permisoB.per_codigo = "B";
                permisoB.per_descripcion = "Baja";
                oModelo.permisos.Add(permisoB);

                MODELO.permiso permisoM = new MODELO.permiso();
                permisoM.per_codigo = "M";
                permisoM.per_descripcion = "Modificacion";
                oModelo.permisos.Add(permisoM);

                MODELO.permiso permisoC = new MODELO.permiso();
                permisoC.per_codigo = "C";
                permisoC.per_descripcion = "Consulta";
                oModelo.permisos.Add(permisoC);

                MODELO.formulario oFORMULARIO_G = new MODELO.formulario();
                oFORMULARIO_G.frm_descripcion = "Gestion de Grupos";
                oFORMULARIO_G.frm_estado = true;
                oFORMULARIO_G.frm_formulario = "frmGrupos";
                oFORMULARIO_G.modulo = oMODULO;
                oFORMULARIO_G.permiso.Add(permisoA);
                oFORMULARIO_G.permiso.Add(permisoB);
                oFORMULARIO_G.permiso.Add(permisoM);
                oFORMULARIO_G.permiso.Add(permisoC);
                oModelo.formularios.Add(oFORMULARIO_G);

                MODELO.formulario oFORMULARIO_U = new MODELO.formulario();
                oFORMULARIO_U.frm_descripcion = "Gestion de Usuarios";
                oFORMULARIO_U.frm_estado = true;
                oFORMULARIO_U.frm_formulario = "frmUsuarios";
                oFORMULARIO_U.modulo = oMODULO;
                oFORMULARIO_U.permiso.Add(permisoA);
                oFORMULARIO_U.permiso.Add(permisoB);
                oFORMULARIO_U.permiso.Add(permisoM);
                oFORMULARIO_U.permiso.Add(permisoC);
                oModelo.formularios.Add(oFORMULARIO_U);

                MODELO.formulario oFORMULARIO_C = new MODELO.formulario();
                oFORMULARIO_C.frm_descripcion = "Cambiar Contraseña";
                oFORMULARIO_C.frm_estado = true;
                oFORMULARIO_C.frm_formulario = "frmPassword";
                oFORMULARIO_C.modulo = oMODULO;
                oFORMULARIO_C.permiso.Add(permisoM);
                oModelo.formularios.Add(oFORMULARIO_C);

                MODELO.grupo oGRUPO = new MODELO.grupo();
                oGRUPO.gru_codigo = "ADM";
                oGRUPO.gru_descripcion = "Administrador";
                oGRUPO.gru_estado = true;
                oModelo.grupos.Add(oGRUPO);

                MODELO.usuario oUSUARIO = new MODELO.usuario();
                oUSUARIO.usu_codigo = "admin";
                oUSUARIO.usu_nombre = "Administrador";   
                oUSUARIO.usu_clave = EncriptarClave("admin");
                oUSUARIO.usu_email = "admin@empresa.com";
                oUSUARIO.usu_estado = true;
                oUSUARIO.grupos.Add(oGRUPO);
                oModelo.usuarios.Add(oUSUARIO);

                MODELO.perfil oPERFIL;
                
                oPERFIL = new MODELO.perfil();
                oPERFIL.grupo = oGRUPO;
                oPERFIL.formulario = oFORMULARIO_G;
                oPERFIL.permiso.Add(permisoA);
                oPERFIL.permiso.Add(permisoB);
                oPERFIL.permiso.Add(permisoM);
                oPERFIL.permiso.Add(permisoC);
                oModelo.perfiles.Add(oPERFIL);
                oPERFIL = null;

                oPERFIL = new MODELO.perfil();
                oPERFIL.grupo = oGRUPO;
                oPERFIL.formulario = oFORMULARIO_U;
                oPERFIL.permiso.Add(permisoA);
                oPERFIL.permiso.Add(permisoB);
                oPERFIL.permiso.Add(permisoM);
                oPERFIL.permiso.Add(permisoC);
                oModelo.perfiles.Add(oPERFIL);
                oPERFIL = null;

                oPERFIL = new MODELO.perfil();
                oPERFIL.grupo = oGRUPO;
                oPERFIL.formulario = oFORMULARIO_C;
                oPERFIL.permiso.Add(permisoM);
                oModelo.perfiles.Add(oPERFIL);
                oPERFIL = null;

                oModelo.SaveChanges();
            }
        }

        public List<MODELO.modulo> ObtenerModulos()
        {
            return oModelo.modulos.ToList();
        }

        public List<MODELO.formulario> obtenerFormularios(MODELO.usuario Usuario, MODELO.modulo MODULO)
        {
            var contactQuery = from oFRM in oModelo.perfiles.ToList()
                               where oFRM.formulario.modulo == MODULO && oFRM.formulario.frm_estado == true && Usuario.grupos.Contains(oFRM.grupo)
                               select oFRM.formulario;

            return (List<MODELO.formulario>)contactQuery.Distinct().ToList();
        }

        public List<MODELO.permiso> obtenerPermisos(MODELO.usuario Usuario, string FORMULARIO)
        {
            var contactQuery = from oFRM in oModelo.perfiles.ToList()
                               where oFRM.formulario.frm_formulario == FORMULARIO && oFRM.formulario.frm_estado == true && Usuario.grupos.Contains(oFRM.grupo)
                               select oFRM;

            List<MODELO.permiso> Permisos = new List<MODELO.permiso>(); 
            foreach (MODELO.perfil oP in (List<MODELO.perfil>)contactQuery.ToList())
            {
                foreach (MODELO.permiso Per in oP.permiso.ToList())
                {
                    Permisos.Add(Per);
                }
            }

            return Permisos.Distinct().ToList();
        }

        public string EncriptarClave(string clave)
        {
            byte[] passBytes = Encoding.Unicode.GetBytes(clave);
            SHA1 sha = SHA1.Create();
            byte[] hash = sha.ComputeHash(passBytes);
            string hashString = Encoding.Unicode.GetString(hash);
            return hashString;
        }

     

    }
}
