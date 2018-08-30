using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class Orderline
    {
        public Orderline()
        {
            Reportline = new HashSet<Reportline>();
        }

        public long Id { get; set; }
        public int? ProductId { get; set; }
        public float Quantity { get; set; }
        public float PriceUnit { get; set; }
        public float Cost { get; set; }
        public int OrderId { get; set; }
        public string PromotionName { get; set; }
        public int? PromotionId { get; set; }
        public int? DiscountType { get; set; }
        public float? DiscountAmount { get; set; }
        public string BillReference { get; set; }
        public int? Type { get; set; }

        public Orders Order { get; set; }
        public Product Product { get; set; }
        public ICollection<Reportline> Reportline { get; set; }
    }
}
