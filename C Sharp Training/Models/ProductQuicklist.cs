using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class ProductQuicklist
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int QuicklistId { get; set; }
        public int Position { get; set; }
        public string DisplayName { get; set; }
        public string Barcode { get; set; }

        public Product Product { get; set; }
        public Quicklist Quicklist { get; set; }
    }
}
