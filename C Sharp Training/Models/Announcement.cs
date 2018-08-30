using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class Announcement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastEditDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Hour { get; set; }
        public int? Minute { get; set; }
        public bool? ShowAtStartShift { get; set; }
        public int? ServerId { get; set; }
    }
}
