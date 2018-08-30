using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class Groups
    {
        public Groups()
        {
            ProductGroup = new HashSet<ProductGroup>();
            ProductPromotionGroupId1Navigation = new HashSet<ProductPromotion>();
            ProductPromotionGroupId2Navigation = new HashSet<ProductPromotion>();
        }

        public int Id { get; set; }

        public ICollection<ProductGroup> ProductGroup { get; set; }
        public ICollection<ProductPromotion> ProductPromotionGroupId1Navigation { get; set; }
        public ICollection<ProductPromotion> ProductPromotionGroupId2Navigation { get; set; }
    }
}
