using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class Users
    {
        public Users()
        {
            HoldOrderHistory = new HashSet<HoldOrderHistory>();
            Orders = new HashSet<Orders>();
            Payout = new HashSet<Payout>();
            ProductSupplier = new HashSet<ProductSupplier>();
            Promotion = new HashSet<Promotion>();
            SessionEndUser = new HashSet<Session>();
            SessionStartUser = new HashSet<Session>();
            Statement = new HashSet<Statement>();
            StatementLine = new HashSet<StatementLine>();
            UsersPasswordHistoryCreator = new HashSet<UsersPasswordHistory>();
            UsersPasswordHistoryUser = new HashSet<UsersPasswordHistory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Pin { get; set; }
        public int RoleId { get; set; }
        public bool? Enable { get; set; }
        public string Username { get; set; }
        public DateTime? LastLogin { get; set; }
        public int? InvalidLoginAttempts { get; set; }
        public bool? DoesRequirePasswordChange { get; set; }

        public Role Role { get; set; }
        public ICollection<HoldOrderHistory> HoldOrderHistory { get; set; }
        public ICollection<Orders> Orders { get; set; }
        public ICollection<Payout> Payout { get; set; }
        public ICollection<ProductSupplier> ProductSupplier { get; set; }
        public ICollection<Promotion> Promotion { get; set; }
        public ICollection<Session> SessionEndUser { get; set; }
        public ICollection<Session> SessionStartUser { get; set; }
        public ICollection<Statement> Statement { get; set; }
        public ICollection<StatementLine> StatementLine { get; set; }
        public ICollection<UsersPasswordHistory> UsersPasswordHistoryCreator { get; set; }
        public ICollection<UsersPasswordHistory> UsersPasswordHistoryUser { get; set; }
    }
}
