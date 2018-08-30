using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class Journal
    {
        public Journal()
        {
            Statement = new HashSet<Statement>();
            StatementLine = new HashSet<StatementLine>();
        }

        public int Id { get; set; }
        public int? AccountId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string DisplayName { get; set; }
        public int? Sequence { get; set; }
        public string Code { get; set; }

        public ICollection<Statement> Statement { get; set; }
        public ICollection<StatementLine> StatementLine { get; set; }
    }
}
