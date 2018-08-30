using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class DeletedItem
    {
        public long Id { get; set; }
        public int? ProductId { get; set; }
        public string ProductBarcode { get; set; }
        public string ProductDescription { get; set; }
        public float? Quantity { get; set; }
        public float? Price { get; set; }
        public int? SessionId { get; set; }
        public string CashierName { get; set; }
        public DateTime? DeletedTime { get; set; }

        public Product Product { get; set; }
        public Session Session { get; set; }
    }
}
