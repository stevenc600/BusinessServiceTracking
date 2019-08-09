﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessServiceTracking
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class FinanceEntities : DbContext
    {
        public FinanceEntities()
            : base("name=FinanceEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BusinessService> BusinessServices { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Junction_BS_TS> Junction_BS_TS { get; set; }
        public virtual DbSet<Junction_EMP_TS> Junction_EMP_TS { get; set; }
        public virtual DbSet<Junction_Vendor_Product> Junction_Vendor_Product { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<SoftwareLicensing> SoftwareLicensings { get; set; }
        public virtual DbSet<TechnologyService> TechnologyServices { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<BusinessUnit> BusinessUnits { get; set; }
        public virtual DbSet<EmployeeDetailsWithBusinessUnit> EmployeeDetailsWithBusinessUnits { get; set; }
        public virtual DbSet<Junction_Employees_BusinessUnit> Junction_Employees_BusinessUnit { get; set; }
    
        public virtual ObjectResult<FindEmployees_Result> FindEmployees()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FindEmployees_Result>("FindEmployees");
        }
    }
}
