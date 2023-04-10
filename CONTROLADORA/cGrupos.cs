using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CONTROLADORA
{
    public class cGrupos
    {
        private static cGrupos instancia;
        private MODELO.CONTEXTO oModelo;
        public static cGrupos obtenerInstancia()
        { 
            if (instancia == null)
                instancia = new cGrupos();

            return instancia;
        }
        private cGrupos()
        {
            oModelo = MODELO.CONTEXTO.obtenerInstancia();
        }
        public List<MODELO.grupo> ObtenerGrupos()
        {
            
            
            return oModelo.grupos.ToList();
        }
        public void Alta(MODELO.grupo oGrupo)
        {
            oModelo.grupos.Add(oGrupo);
            oModelo.SaveChanges();
        }
        public void Baja(MODELO.grupo oGrupo)
        {
            oModelo.grupos.Remove(oGrupo);
            oModelo.SaveChanges();
        }
        public void Modificacion(MODELO.grupo oGrupo)
        {
            oModelo.grupos.Attach(oGrupo);
            oModelo.Entry(oGrupo).State = System.Data.Entity.EntityState.Modified;
            oModelo.SaveChanges();
        }

        public List<MODELO.permiso > obtenerPermisos()
        {
            return oModelo.permisos.ToList();
        }

        public List<MODELO.formulario> obtenerFormulario()
        {
            return oModelo.formularios.ToList();
        }

        public List<MODELO.usuario> obtenerUsuarios()
        {
            return oModelo.usuarios.ToList();
        }

        public List<MODELO.permiso> obtenerPermisos(string FORMULARIO)
        {
            var contactQuery = from oFRM in oModelo.perfiles.ToList()
                               where oFRM.formulario.frm_formulario == FORMULARIO && oFRM.formulario.frm_estado == true
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

    }
}
