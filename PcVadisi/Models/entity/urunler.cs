//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PcVadisi.Models.entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class urunler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public urunler()
        {
            this.satıslar = new HashSet<satıslar>();
        }
    
        public int urunid { get; set; }
        public string urunad { get; set; }
        public Nullable<int> urunkateogori { get; set; }
        public Nullable<decimal> fiyat { get; set; }
        public Nullable<byte> stok { get; set; }
        public string marka { get; set; }
    
        public virtual kotegori kotegori { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<satıslar> satıslar { get; set; }
    }
}
