using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class PriceSchedule
    {
        public long Id { get; set; }
        public int ProductId { get; set; }
        public float Price { get; set; }
        public float PriceCold { get; set; }
        public DateTime? StartOn { get; set; }

        public Product Product { get; set; }
    }
}
