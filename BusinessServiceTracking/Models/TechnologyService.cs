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
    
    public partial class TechnologyService
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TechnologyService()
        {
            this.Junction_BS_TS = new HashSet<Junction_BS_TS>();
            this.Junction_EMP_TS = new HashSet<Junction_EMP_TS>();
            this.Junction_MaintAgreement_TS = new HashSet<Junction_MaintAgreement_TS>();
            this.Junction_Software_TS = new HashSet<Junction_Software_TS>();
            this.Junction_Vendor_TS = new HashSet<Junction_Vendor_TS>();
        }
    
        public int TechServiceID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceOwner { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Junction_BS_TS> Junction_BS_TS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Junction_EMP_TS> Junction_EMP_TS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Junction_MaintAgreement_TS> Junction_MaintAgreement_TS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Junction_Software_TS> Junction_Software_TS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Junction_Vendor_TS> Junction_Vendor_TS { get; set; }
    }
}
