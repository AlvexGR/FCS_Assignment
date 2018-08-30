using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class Quicklist
    {
        public Quicklist()
        {
            ProductQuicklist = new HashSet<ProductQuicklist>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public bool? IsWeightSale { get; set; }

        public ICollection<ProductQuicklist> ProductQuicklist { get; set; }
    }
}
