//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MODELO
{
    using System;
    using System.Collections.Generic;
    
    public partial class formulario
    {
        public formulario()
        {
            this.perfil = new HashSet<perfil>();
            this.permiso = new HashSet<permiso>();
        }
    
        public int frm_codigo { get; set; }
        public string frm_descripcion { get; set; }
        public string frm_formulario { get; set; }
        public bool frm_estado { get; set; }
    
        public virtual ICollection<perfil> perfil { get; set; }
        public virtual modulo modulo { get; set; }
        public virtual ICollection<permiso> permiso { get; set; }
    }
}
