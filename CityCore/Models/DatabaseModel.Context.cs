﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CityCore.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CityCoreDBEntities : DbContext
    {
        public CityCoreDBEntities()
            : base("name=CityCoreDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<COMPANY> COMPANies { get; set; }
        public virtual DbSet<EMPLOYEE> EMPLOYEEs { get; set; }
        public virtual DbSet<PROJECT> PROJECTs { get; set; }
        public virtual DbSet<PROJECT_TASK> PROJECT_TASK { get; set; }
        public virtual DbSet<PROJECT_TASK_DOC> PROJECT_TASK_DOC { get; set; }
        public virtual DbSet<TASK> TASKs { get; set; }
        public virtual DbSet<TASK_RELATED_DOC> TASK_RELATED_DOC { get; set; }
    }
}
