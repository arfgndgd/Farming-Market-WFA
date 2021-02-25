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
    
    public partial class StorageOrderDetail
    {
        public int OrderID { get; set; }
        public int StorageID { get; set; }
        public decimal TotalPrice { get; set; }
        public double Weight { get; set; }
        public Nullable<System.DateTime> Veri_Yaratma_Tarihi { get; set; }
        public Nullable<System.DateTime> Veri_Güncelleme_Tarihi { get; set; }
        public Nullable<System.DateTime> Veri_Silme_Tarihi { get; set; }
        public int Veri_Durumu { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Storage Storage { get; set; }
    }
}