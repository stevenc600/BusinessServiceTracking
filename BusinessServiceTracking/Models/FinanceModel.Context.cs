﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessServiceTracking.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class FinanceModellingEntities2 : DbContext
    {
        public FinanceModellingEntities2()
            : base("name=FinanceModellingEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BusinessService> BusinessServices { get; set; }
        public virtual DbSet<BusinessUnit> BusinessUnits { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Junction_BS_TS> Junction_BS_TS { get; set; }
        public virtual DbSet<Junction_EMP_TS> Junction_EMP_TS { get; set; }
        public virtual DbSet<Junction_MaintAgreement_TS> Junction_MaintAgreement_TS { get; set; }
        public virtual DbSet<Junction_Software_TS> Junction_Software_TS { get; set; }
        public virtual DbSet<Junction_Vendor_TS> Junction_Vendor_TS { get; set; }
        public virtual DbSet<MaintenanceAgreement> MaintenanceAgreements { get; set; }
        public virtual DbSet<SoftwareLicensing> SoftwareLicensings { get; set; }
        public virtual DbSet<TechnologyService> TechnologyServices { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
    
        public virtual ObjectResult<FindEmployees_Result> FindEmployees()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FindEmployees_Result>("FindEmployees");
        }
    }
}
