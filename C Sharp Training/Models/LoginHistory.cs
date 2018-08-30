using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class LoginHistory
    {
        public int Id { get; set; }
        public string CashierName { get; set; }
        public string PosTerminalName { get; set; }
        public DateTime? LoginTime { get; set; }
        public DateTime? LogoutTime { get; set; }
    }
}
