using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class Payout
    {
        public int Id { get; set; }
        public int? SupplierId { get; set; }
        public string InvoiceNo { get; set; }
        public string Note { get; set; }
        public float? Amount { get; set; }
        public int? SessionId { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsCashPayout { get; set; }
        public bool? IsOwnerWithdraw { get; set; }
        public bool? IsCashPayin { get; set; }

        public Session Session { get; set; }
        public Supplier Supplier { get; set; }
        public Users User { get; set; }
    }
}
