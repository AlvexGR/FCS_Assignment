using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int? PowerLevel { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}
