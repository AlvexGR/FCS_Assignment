using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Inventory = new HashSet<Inventory>();
            Payout = new HashSet<Payout>();
            ProductSupplier = new HashSet<ProductSupplier>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Enable { get; set; }
        public DateTime? LastEdit { get; set; }
        public Guid? Uuid { get; set; }

        public ICollection<Inventory> Inventory { get; set; }
        public ICollection<Payout> Payout { get; set; }
        public ICollection<ProductSupplier> ProductSupplier { get; set; }
    }
}
