using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class UsersPasswordHistory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Password { get; set; }
        public DateTime CreateAt { get; set; }
        public int CreatorId { get; set; }

        public Users Creator { get; set; }
        public Users User { get; set; }
    }
}
