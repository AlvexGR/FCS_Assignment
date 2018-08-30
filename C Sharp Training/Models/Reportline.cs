using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class Reportline
    {
        public long Id { get; set; }
        public int? ProductId { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public long? OrderlineId { get; set; }
        public int? OrderId { get; set; }
        public int? CategoryId { get; set; }
        public float? Qty { get; set; }
        public float? Price { get; set; }
        public bool? PromotionApplied { get; set; }
        public bool? IsVoid { get; set; }
        public bool? ColdApplied { get; set; }
        public float? CostPrice { get; set; }
        public DateTime DateCreated { get; set; }
        public bool? GstApplied { get; set; }
        public float? GstValue { get; set; }
        public int? SupplierId { get; set; }

        public Orders Order { get; set; }
        public Orderline Orderline { get; set; }
        public Product Product { get; set; }
    }
}
