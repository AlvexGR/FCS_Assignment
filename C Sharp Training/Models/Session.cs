using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class Session
    {
        public Session()
        {
            DeletedItem = new HashSet<DeletedItem>();
            Orders = new HashSet<Orders>();
            Payout = new HashSet<Payout>();
            Statement = new HashSet<Statement>();
        }

        public int Id { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime? EndAt { get; set; }
        public string Name { get; set; }
        public string TerminalUid { get; set; }
        public int StartUserId { get; set; }
        public int? EndUserId { get; set; }
        public float? StartCash { get; set; }
        public float? EndCash { get; set; }
        public string EndShiftCashBreakdownDictString { get; set; }
        public int? ServerId { get; set; }
        public string Note { get; set; }
        public int? CountOpenCashdrawer { get; set; }
        public int? OkHolds { get; set; }
        public int? CancelHolds { get; set; }
        public float? CancelHoldsAmount { get; set; }
        public int? TotalHolds { get; set; }
        public bool? GstApplied { get; set; }
        public float? GstValue { get; set; }
        public float? StartCashboxValue { get; set; }
        public float? EndCashboxValue { get; set; }
        public float? StartCashboxFloat { get; set; }
        public float? AddFloatValue { get; set; }
        public string StartShiftCashBreakdownDictString { get; set; }
        public string ReferenceNumber { get; set; }
        public float? RetainCashboxFloat { get; set; }

        public Users EndUser { get; set; }
        public Users StartUser { get; set; }
        public ICollection<DeletedItem> DeletedItem { get; set; }
        public ICollection<Orders> Orders { get; set; }
        public ICollection<Payout> Payout { get; set; }
        public ICollection<Statement> Statement { get; set; }
    }
}
