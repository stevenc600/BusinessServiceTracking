//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class MaintenanceAgreement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MaintenanceAgreement()
        {
            this.Junction_MaintAgreement_TS = new HashSet<Junction_MaintAgreement_TS>();
        }
    
        public int MAID { get; set; }
        public string AgreementName { get; set; }
        public string Vendor { get; set; }
        public decimal TotalCost { get; set; }
        public string Owner { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Junction_MaintAgreement_TS> Junction_MaintAgreement_TS { get; set; }
    }
}