using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class Category
    {
        public Category()
        {
            CategoryRestriction = new HashSet<CategoryRestriction>();
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public bool? Enable { get; set; }
        public DateTime? LastEdit { get; set; }
        public bool? IsProhibitedFromDiscount { get; set; }
        public Guid? Uuid { get; set; }
        public bool? DoesRequireApproval { get; set; }

        public ICollection<CategoryRestriction> CategoryRestriction { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
