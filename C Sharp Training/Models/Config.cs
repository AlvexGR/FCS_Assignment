using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class Config
    {
        public int Id { get; set; }
        public string ConfigCode { get; set; }
        public string ConfigName { get; set; }
        public string ConfigValue { get; set; }
        public string DefaultValue { get; set; }
    }
}
