//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pok
{
    using System;
    using System.Collections.Generic;
    
    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            //this.Carries = new HashSet<Carries>();
        }
    
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Effect { get; set; }
        public string Type_of_item { get; set; }
        public Nullable<int> RegionId { get; set; }
    
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Carries> Carries { get; set; }
        public virtual Region Region { get; set; }
    }
}
