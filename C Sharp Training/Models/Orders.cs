using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class Orders
    {
        public Orders()
        {
            HoldOrderHistory = new HashSet<HoldOrderHistory>();
            Orderline = new HashSet<Orderline>();
            Reportline = new HashSet<Reportline>();
            StatementLine = new HashSet<StatementLine>();
        }

        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public int? UserId { get; set; }
        public string CreatorName { get; set; }
        public int? SessionId { get; set; }
        public string Name { get; set; }
        public string JournalName { get; set; }
        public float Amount { get; set; }
        public bool? IsVoid { get; set; }
        public bool? IsSynced { get; set; }
        public float? TaxApplied { get; set; }
        public int? DiscountType { get; set; }
        public float? DiscountAmount { get; set; }
        public float? RoundingAmount { get; set; }
        public string Note { get; set; }
        public int? VoidedUserId { get; set; }
        public string Info1 { get; set; }
        public string Info2 { get; set; }

        public Session Session { get; set; }
        public Users User { get; set; }
        public ICollection<HoldOrderHistory> HoldOrderHistory { get; set; }
        public ICollection<Orderline> Orderline { get; set; }
        public ICollection<Reportline> Reportline { get; set; }
        public ICollection<StatementLine> StatementLine { get; set; }
    }
}
