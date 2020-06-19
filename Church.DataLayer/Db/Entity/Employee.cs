//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public Nullable<int> GenderId { get; set; }
        public Nullable<decimal> Salary { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual Gender Gender { get; set; }
    }
}