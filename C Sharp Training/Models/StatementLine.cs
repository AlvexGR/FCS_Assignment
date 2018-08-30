using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class StatementLine
    {
        public long Id { get; set; }
        public decimal Amount { get; set; }
        public int JournalId { get; set; }
        public int StatementId { get; set; }
        public int? OrderId { get; set; }
        public DateTime? CreateAt { get; set; }
        public int? UserId { get; set; }
        public decimal? PaidAmount { get; set; }
        public bool? IsVoid { get; set; }

        public Journal Journal { get; set; }
        public Orders Order { get; set; }
        public Statement Statement { get; set; }
        public Users User { get; set; }
    }
}
