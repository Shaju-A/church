﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Church.DataLayer.Db.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ManagementEntities : DbContext
    {
        public ManagementEntities()
            : base("name=ManagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserPrivilege> UserPrivileges { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<Pastor> Pastors { get; set; }
    }
}
