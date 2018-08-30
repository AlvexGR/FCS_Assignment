using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class ProductGroup
    {
        public int ProductId { get; set; }
        public int GroupId { get; set; }
        public int? Quantity { get; set; }

        public Groups Group { get; set; }
        public Product Product { get; set; }
    }
}
