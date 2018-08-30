using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class Log
    {
        public int Id { get; set; }
        public DateTime LogTime { get; set; }
        public int? UserId { get; set; }
        public int Type { get; set; }
        public int? RecordId { get; set; }
        public string BeforeValue { get; set; }
        public string AfterValue { get; set; }
        public int Operation { get; set; }
    }
}
