﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CONTEXTO : DbContext
    {
        public CONTEXTO()
            : base("name=CONTEXTO")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<perfil> perfiles { get; set; }
        public virtual DbSet<grupo> grupos { get; set; }
        public virtual DbSet<modulo> modulos { get; set; }
        public virtual DbSet<usuario> usuarios { get; set; }
        public virtual DbSet<formulario> formularios { get; set; }
        public virtual DbSet<permiso> permisos { get; set; }
    }
}