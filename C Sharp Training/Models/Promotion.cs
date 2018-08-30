using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class Promotion
    {
        public Promotion()
        {
            ProductPromotion = new HashSet<ProductPromotion>();
        }

        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public bool? Enable { get; set; }
        public int? UserId { get; set; }
        public int? ServerId { get; set; }
        public DateTime? LastEdit { get; set; }

        public Users User { get; set; }
        public ICollection<ProductPromotion> ProductPromotion { get; set; }
    }
}
