﻿using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class Set
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public double Score { get; set; }
        public string Value { get; set; }
        public DateTime? Expireat { get; set; }
        public int Updatecount { get; set; }
    }
}
