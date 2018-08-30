using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class Statement
    {
        public Statement()
        {
            StatementLine = new HashSet<StatementLine>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int? SessionId { get; set; }
        public float? Amount { get; set; }
        public float? Variance { get; set; }
        public int? JournalId { get; set; }

        public Journal Journal { get; set; }
        public Session Session { get; set; }
        public Users User { get; set; }
        public ICollection<StatementLine> StatementLine { get; set; }
    }
}
