//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectFarmBA_WFA.ModelContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
    
        public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public Nullable<short> UnitInStock { get; set; }
        public string ImagePath { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public Nullable<System.DateTime> Veri_Yaratma_Tarihi { get; set; }
        public Nullable<System.DateTime> Veri_Güncelleme_Tarihi { get; set; }
        public Nullable<System.DateTime> Veri_Silme_Tarihi { get; set; }
        public int Veri_Durumu { get; set; }
        public string Features { get; set; }
    
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
