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
    
    public partial class usuario
    {
        public usuario()
        {
            this.grupos = new HashSet<grupo>();
        }
    
        public string usu_codigo { get; set; }
        public string usu_nombre { get; set; }
        public string usu_clave { get; set; }
        public bool usu_estado { get; set; }
        public string usu_email { get; set; }
    
        public virtual ICollection<grupo> grupos { get; set; }
    }
}
