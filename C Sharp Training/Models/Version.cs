using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class Version
    {
        public int Id { get; set; }
        public string AppVersion { get; set; }
        public string MacAddress { get; set; }
        public string IpAddress { get; set; }
        public string Role { get; set; }
        public string TerminalName { get; set; }
        public string DatabaseVersion { get; set; }
        public bool? IsSingleMallReport { get; set; }
    }
}
