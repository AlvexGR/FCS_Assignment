using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class HoldOrderHistory
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int HolderId { get; set; }
        public DateTime CreateAt { get; set; }
        public bool? Cancelled { get; set; }
        public string CustomerName { get; set; }
        public float? TotalAmount { get; set; }
        public float? TotalItems { get; set; }

        public Users Holder { get; set; }
        public Orders Order { get; set; }
    }
}
