﻿using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class Counter
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public short Value { get; set; }
        public DateTime? Expireat { get; set; }
        public int Updatecount { get; set; }
    }
}
