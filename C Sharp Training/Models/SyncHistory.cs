using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class SyncHistory
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? ServerTime { get; set; }
        public int Status { get; set; }
        public string SyncToken { get; set; }
    }
}
