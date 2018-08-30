using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class Inventory
    {
        public long Id { get; set; }
        public int? ProductId { get; set; }
        public int? SupplierId { get; set; }
        public float? Quantity { get; set; }
        public string Note { get; set; }
        public DateTime? Date { get; set; }
        public float? Cost { get; set; }
        public bool? TaxApplied { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? LastEdit { get; set; }
        public bool? ShouldHideFromExpiryReport { get; set; }
        public int? Type { get; set; }
        public Guid? Uuid { get; set; }

        public Product Product { get; set; }
        public Supplier Supplier { get; set; }
    }
}
