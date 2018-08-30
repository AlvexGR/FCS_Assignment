using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class ChangeLog
    {
        public int Id { get; set; }
        public string Operation { get; set; }
        public string Model { get; set; }
        public Guid? Uuid { get; set; }
        public string Data { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
