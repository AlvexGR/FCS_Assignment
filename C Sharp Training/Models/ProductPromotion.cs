using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class ProductPromotion
    {
        public long Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PromotionId { get; set; }
        public int? ProductId1 { get; set; }
        public int? GroupId1 { get; set; }
        public float? Quantity1 { get; set; }
        public int? ProductId2 { get; set; }
        public int? GroupId2 { get; set; }
        public float? Quantity2 { get; set; }
        public float Price { get; set; }
        public bool? Enable { get; set; }

        public Groups GroupId1Navigation { get; set; }
        public Groups GroupId2Navigation { get; set; }
        public Product ProductId1Navigation { get; set; }
        public Product ProductId2Navigation { get; set; }
        public Promotion Promotion { get; set; }
    }
}
