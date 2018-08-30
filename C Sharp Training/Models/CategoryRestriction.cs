using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class CategoryRestriction
    {
        public long Id { get; set; }
        public int? CategoryId { get; set; }
        public int? StartHour { get; set; }
        public int? StartMinute { get; set; }
        public int? EndHour { get; set; }
        public int? EndMinute { get; set; }

        public Category Category { get; set; }
    }
}
