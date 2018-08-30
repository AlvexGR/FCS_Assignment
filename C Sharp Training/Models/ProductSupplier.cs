using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class ProductSupplier
    {
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public float? Cost { get; set; }
        public string SupplierCode { get; set; }
        public bool? TaxApplied { get; set; }
        public bool? Active { get; set; }
        public DateTime? LastEdit { get; set; }
        public string Info { get; set; }
        public int? UserId { get; set; }
        public bool? Enable { get; set; }
        public Guid? Uuid { get; set; }

        public Product Product { get; set; }
        public Supplier Supplier { get; set; }
        public Users User { get; set; }
    }
}
