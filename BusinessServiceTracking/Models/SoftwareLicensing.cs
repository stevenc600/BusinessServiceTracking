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
    
    public partial class SoftwareLicensing
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SoftwareLicensing()
        {
            this.Junction_Software_TS = new HashSet<Junction_Software_TS>();
        }
    
        public int SoftwareID { get; set; }
        public string SoftwareName { get; set; }
        public string Owner { get; set; }
        public decimal CostPerCapacityUnit { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Junction_Software_TS> Junction_Software_TS { get; set; }
    }
}
