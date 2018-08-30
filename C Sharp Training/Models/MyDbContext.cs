using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace C_Sharp_Training.Models
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Announcement> Announcement { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CategoryRestriction> CategoryRestriction { get; set; }
        public virtual DbSet<ChangeLog> ChangeLog { get; set; }
        public virtual DbSet<Config> Config { get; set; }
        public virtual DbSet<Counter> Counter { get; set; }
        public virtual DbSet<DeletedItem> DeletedItem { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Hash> Hash { get; set; }
        public virtual DbSet<HoldOrderHistory> HoldOrderHistory { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<Jobparameter> Jobparameter { get; set; }
        public virtual DbSet<Jobqueue> Jobqueue { get; set; }
        public virtual DbSet<Journal> Journal { get; set; }
        public virtual DbSet<List> List { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<LoginHistory> LoginHistory { get; set; }
        public virtual DbSet<Migrations> Migrations { get; set; }
        public virtual DbSet<Orderline> Orderline { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Payout> Payout { get; set; }
        public virtual DbSet<PosConfig> PosConfig { get; set; }
        public virtual DbSet<PriceSchedule> PriceSchedule { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductGroup> ProductGroup { get; set; }
        public virtual DbSet<ProductPromotion> ProductPromotion { get; set; }
        public virtual DbSet<ProductQuicklist> ProductQuicklist { get; set; }
        public virtual DbSet<ProductSupplier> ProductSupplier { get; set; }
        public virtual DbSet<Promotion> Promotion { get; set; }
        public virtual DbSet<Quicklist> Quicklist { get; set; }
        public virtual DbSet<Reportline> Reportline { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Schema> Schema { get; set; }
        public virtual DbSet<Server> Server { get; set; }
        public virtual DbSet<Session> Session { get; set; }
        public virtual DbSet<Set> Set { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Statement> Statement { get; set; }
        public virtual DbSet<StatementLine> StatementLine { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<SyncHistory> SyncHistory { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersPasswordHistory> UsersPasswordHistory { get; set; }
        public virtual DbSet<Version> Version { get; set; }

        // Unable to generate entity type for table 'hangfire.lock'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Server=localhost;Database=epos_retail_v1;Username=epos;Password=Epos1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Announcement>(entity =>
            {
                entity.ToTable("announcement");

                entity.HasIndex(e => e.ServerId)
                    .HasName("announcement_server_id_unique")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.EndDate).HasColumnName("end_date");

                entity.Property(e => e.Hour).HasColumnName("hour");

                entity.Property(e => e.LastEditDate).HasColumnName("last_edit_date");

                entity.Property(e => e.Message).HasColumnName("message");

                entity.Property(e => e.Minute).HasColumnName("minute");

                entity.Property(e => e.ServerId).HasColumnName("server_id");

                entity.Property(e => e.ShowAtStartShift)
                    .HasColumnName("show_at_start_shift")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.StartDate).HasColumnName("start_date");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.HasIndex(e => e.Name)
                    .HasName("category_name");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DoesRequireApproval)
                    .HasColumnName("does_require_approval")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Enable)
                    .HasColumnName("enable")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.IsProhibitedFromDiscount)
                    .HasColumnName("is_prohibited_from_discount")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.LastEdit).HasColumnName("last_edit");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.Uuid).HasColumnName("uuid");
            });

            modelBuilder.Entity<CategoryRestriction>(entity =>
            {
                entity.ToTable("category_restriction");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.EndHour).HasColumnName("end_hour");

                entity.Property(e => e.EndMinute).HasColumnName("end_minute");

                entity.Property(e => e.StartHour).HasColumnName("start_hour");

                entity.Property(e => e.StartMinute).HasColumnName("start_minute");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategoryRestriction)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("category_restriction_category_id_fkey");
            });

            modelBuilder.Entity<ChangeLog>(entity =>
            {
                entity.ToTable("change_log");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("data")
                    .HasColumnType("json");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasColumnName("model")
                    .HasMaxLength(36);

                entity.Property(e => e.Operation)
                    .IsRequired()
                    .HasColumnName("operation")
                    .HasMaxLength(36);

                entity.Property(e => e.UpdateAt).HasColumnName("update_at");

                entity.Property(e => e.Uuid).HasColumnName("uuid");
            });

            modelBuilder.Entity<Config>(entity =>
            {
                entity.HasKey(e => e.ConfigCode);

                entity.ToTable("config");

                entity.Property(e => e.ConfigCode)
                    .HasColumnName("config_code")
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.ConfigName)
                    .HasColumnName("config_name")
                    .HasMaxLength(100);

                entity.Property(e => e.ConfigValue).HasColumnName("config_value");

                entity.Property(e => e.DefaultValue).HasColumnName("default_value");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Counter>(entity =>
            {
                entity.ToTable("counter", "hangfire");

                entity.HasIndex(e => e.Expireat)
                    .HasName("ix_hangfire_counter_expireat");

                entity.HasIndex(e => e.Key)
                    .HasName("ix_hangfire_counter_key");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('hangfire.counter_id_seq'::regclass)");

                entity.Property(e => e.Expireat).HasColumnName("expireat");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasColumnName("key")
                    .HasMaxLength(100);

                entity.Property(e => e.Updatecount).HasColumnName("updatecount");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<DeletedItem>(entity =>
            {
                entity.ToTable("deleted_item");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CashierName)
                    .HasColumnName("cashier_name")
                    .HasMaxLength(255);

                entity.Property(e => e.DeletedTime)
                    .HasColumnName("deleted_time")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductBarcode)
                    .HasColumnName("product_barcode")
                    .HasMaxLength(128);

                entity.Property(e => e.ProductDescription)
                    .HasColumnName("product_description")
                    .HasMaxLength(255);

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.SessionId).HasColumnName("session_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.DeletedItem)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("deleted_item_product_id_fkey");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.DeletedItem)
                    .HasForeignKey(d => d.SessionId)
                    .HasConstraintName("deleted_item_session_id_fkey");
            });

            modelBuilder.Entity<Groups>(entity =>
            {
                entity.ToTable("groups");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<Hash>(entity =>
            {
                entity.ToTable("hash", "hangfire");

                entity.HasIndex(e => new { e.Key, e.Field })
                    .HasName("hash_key_field_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('hangfire.hash_id_seq'::regclass)");

                entity.Property(e => e.Expireat).HasColumnName("expireat");

                entity.Property(e => e.Field)
                    .IsRequired()
                    .HasColumnName("field")
                    .HasMaxLength(100);

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasColumnName("key")
                    .HasMaxLength(100);

                entity.Property(e => e.Updatecount).HasColumnName("updatecount");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<HoldOrderHistory>(entity =>
            {
                entity.ToTable("hold_order_history");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cancelled)
                    .HasColumnName("cancelled")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.CreateAt).HasColumnName("create_at");

                entity.Property(e => e.CustomerName)
                    .HasColumnName("customer_name")
                    .HasMaxLength(255);

                entity.Property(e => e.HolderId).HasColumnName("holder_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("total_amount")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TotalItems)
                    .HasColumnName("total_items")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Holder)
                    .WithMany(p => p.HoldOrderHistory)
                    .HasForeignKey(d => d.HolderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("hold_order_history_holder_id_fkey");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.HoldOrderHistory)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("hold_order_history_order_id_fkey");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("inventory");

                entity.HasIndex(e => e.ProductId)
                    .HasName("fki_inventory_product_id_fkey");

                entity.HasIndex(e => e.SupplierId)
                    .HasName("fki_inventory_supplier_id_fkey");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.ExpiryDate).HasColumnName("expiry_date");

                entity.Property(e => e.LastEdit).HasColumnName("last_edit");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.ShouldHideFromExpiryReport)
                    .HasColumnName("should_hide_from_expiry_report")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.Property(e => e.TaxApplied)
                    .HasColumnName("tax_applied")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Uuid).HasColumnName("uuid");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("inventory_product_id_fkey");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("inventory_supplier_id_fkey");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("job", "hangfire");

                entity.HasIndex(e => e.Statename)
                    .HasName("ix_hangfire_job_statename");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('hangfire.job_id_seq'::regclass)");

                entity.Property(e => e.Arguments)
                    .IsRequired()
                    .HasColumnName("arguments");

                entity.Property(e => e.Createdat).HasColumnName("createdat");

                entity.Property(e => e.Expireat).HasColumnName("expireat");

                entity.Property(e => e.Invocationdata)
                    .IsRequired()
                    .HasColumnName("invocationdata");

                entity.Property(e => e.Stateid).HasColumnName("stateid");

                entity.Property(e => e.Statename)
                    .HasColumnName("statename")
                    .HasMaxLength(20);

                entity.Property(e => e.Updatecount).HasColumnName("updatecount");
            });

            modelBuilder.Entity<Jobparameter>(entity =>
            {
                entity.ToTable("jobparameter", "hangfire");

                entity.HasIndex(e => new { e.Jobid, e.Name })
                    .HasName("ix_hangfire_jobparameter_jobidandname");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('hangfire.jobparameter_id_seq'::regclass)");

                entity.Property(e => e.Jobid).HasColumnName("jobid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(40);

                entity.Property(e => e.Updatecount).HasColumnName("updatecount");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Jobparameter)
                    .HasForeignKey(d => d.Jobid)
                    .HasConstraintName("jobparameter_jobid_fkey");
            });

            modelBuilder.Entity<Jobqueue>(entity =>
            {
                entity.ToTable("jobqueue", "hangfire");

                entity.HasIndex(e => new { e.Jobid, e.Queue })
                    .HasName("ix_hangfire_jobqueue_jobidandqueue");

                entity.HasIndex(e => new { e.Queue, e.Fetchedat })
                    .HasName("ix_hangfire_jobqueue_queueandfetchedat");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('hangfire.jobqueue_id_seq'::regclass)");

                entity.Property(e => e.Fetchedat).HasColumnName("fetchedat");

                entity.Property(e => e.Jobid).HasColumnName("jobid");

                entity.Property(e => e.Queue)
                    .IsRequired()
                    .HasColumnName("queue")
                    .HasMaxLength(20);

                entity.Property(e => e.Updatecount).HasColumnName("updatecount");
            });

            modelBuilder.Entity<Journal>(entity =>
            {
                entity.ToTable("journal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(10);

                entity.Property(e => e.DisplayName)
                    .HasColumnName("display_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Sequence).HasColumnName("sequence");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<List>(entity =>
            {
                entity.ToTable("list", "hangfire");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('hangfire.list_id_seq'::regclass)");

                entity.Property(e => e.Expireat).HasColumnName("expireat");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasColumnName("key")
                    .HasMaxLength(100);

                entity.Property(e => e.Updatecount).HasColumnName("updatecount");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("log");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AfterValue).HasColumnName("after_value");

                entity.Property(e => e.BeforeValue).HasColumnName("before_value");

                entity.Property(e => e.LogTime).HasColumnName("log_time");

                entity.Property(e => e.Operation).HasColumnName("operation");

                entity.Property(e => e.RecordId).HasColumnName("record_id");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<LoginHistory>(entity =>
            {
                entity.ToTable("login_history");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CashierName)
                    .IsRequired()
                    .HasColumnName("cashier_name")
                    .HasMaxLength(100);

                entity.Property(e => e.LoginTime).HasColumnName("login_time");

                entity.Property(e => e.LogoutTime).HasColumnName("logout_time");

                entity.Property(e => e.PosTerminalName)
                    .IsRequired()
                    .HasColumnName("pos_terminal_name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Migrations>(entity =>
            {
                entity.ToTable("migrations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.RunOn).HasColumnName("run_on");
            });

            modelBuilder.Entity<Orderline>(entity =>
            {
                entity.ToTable("orderline");

                entity.HasIndex(e => e.BillReference)
                    .HasName("orderline_bill_reference_idx");

                entity.HasIndex(e => e.Quantity)
                    .HasName("orderline_quantity");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BillReference)
                    .HasColumnName("bill_reference")
                    .HasMaxLength(255);

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.DiscountAmount).HasColumnName("discount_amount");

                entity.Property(e => e.DiscountType).HasColumnName("discount_type");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.PriceUnit).HasColumnName("price_unit");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.PromotionId).HasColumnName("promotion_id");

                entity.Property(e => e.PromotionName)
                    .HasColumnName("promotion_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderline)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orderline_order_id_fkey");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orderline)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("orderline_product_id_fkey");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.ToTable("orders");

                entity.HasIndex(e => e.CreateAt)
                    .HasName("fki_orders_create_at_key");

                entity.HasIndex(e => e.SessionId)
                    .HasName("fki_orders_session_id_fkey");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.CreateAt)
                    .HasColumnName("create_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.CreatorName)
                    .IsRequired()
                    .HasColumnName("creator_name")
                    .HasMaxLength(255);

                entity.Property(e => e.DiscountAmount).HasColumnName("discount_amount");

                entity.Property(e => e.DiscountType).HasColumnName("discount_type");

                entity.Property(e => e.Info1).HasColumnName("info_1");

                entity.Property(e => e.Info2).HasColumnName("info_2");

                entity.Property(e => e.IsSynced)
                    .HasColumnName("is_synced")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.IsVoid)
                    .HasColumnName("is_void")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.JournalName)
                    .IsRequired()
                    .HasColumnName("journal_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.RoundingAmount)
                    .HasColumnName("rounding_amount")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SessionId).HasColumnName("session_id");

                entity.Property(e => e.TaxApplied).HasColumnName("tax_applied");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.VoidedUserId).HasColumnName("voided_user_id");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.SessionId)
                    .HasConstraintName("orders_session_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("orders_user_id_fkey");
            });

            modelBuilder.Entity<Payout>(entity =>
            {
                entity.ToTable("payout");

                entity.HasIndex(e => e.SessionId)
                    .HasName("fki_payout_session_id_fkey");

                entity.HasIndex(e => e.SupplierId)
                    .HasName("fki_payout_supplier_id_fkey");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoice_no")
                    .HasColumnType("character varying");

                entity.Property(e => e.IsCashPayin)
                    .HasColumnName("is_cash_payin")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.IsCashPayout)
                    .HasColumnName("is_cash_payout")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.IsOwnerWithdraw)
                    .HasColumnName("is_owner_withdraw")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("character varying");

                entity.Property(e => e.SessionId).HasColumnName("session_id");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Payout)
                    .HasForeignKey(d => d.SessionId)
                    .HasConstraintName("payout_session_id_fkey");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Payout)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("payout_supplier_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Payout)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("payout_user_id_fkey");
            });

            modelBuilder.Entity<PosConfig>(entity =>
            {
                entity.ToTable("pos_config");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddTaxToMiscProductEnable)
                    .HasColumnName("add_tax_to_misc_product_enable")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.AllowPriceLowerThanCostPrice)
                    .HasColumnName("allow_price_lower_than_cost_price")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.CashdrawerPinEnable)
                    .HasColumnName("cashdrawer_pin_enable")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.CompanyInfo)
                    .HasColumnName("company_info")
                    .HasDefaultValueSql("'170 Upper Bukit Timah Road #05-44/48'::text");

                entity.Property(e => e.CompanyName)
                    .HasColumnName("company_name")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'Umart Minimart'::character varying");

                entity.Property(e => e.DailySessionEnable)
                    .HasColumnName("daily_session_enable")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.JournalIdsString)
                    .HasColumnName("journal_ids_string")
                    .HasMaxLength(255);

                entity.Property(e => e.LastSyncTimeAnnouncement)
                    .HasColumnName("last_sync_time_announcement")
                    .HasMaxLength(255);

                entity.Property(e => e.LastSyncTimeProduct)
                    .HasColumnName("last_sync_time_product")
                    .HasMaxLength(255);

                entity.Property(e => e.LastSyncTimePromotion)
                    .HasColumnName("last_sync_time_promotion")
                    .HasMaxLength(255);

                entity.Property(e => e.LastSyncTimeSupplier)
                    .HasColumnName("last_sync_time_supplier")
                    .HasMaxLength(255);

                entity.Property(e => e.ManagerVoidOnlyEnable)
                    .HasColumnName("manager_void_only_enable")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.PosId).HasColumnName("pos_id");

                entity.Property(e => e.PosLocalProductId).HasColumnName("pos_local_product_id");

                entity.Property(e => e.PosName)
                    .HasColumnName("pos_name")
                    .HasMaxLength(255);

                entity.Property(e => e.PosPaymentsActiveString)
                    .HasColumnName("pos_payments_active_string")
                    .HasMaxLength(255);

                entity.Property(e => e.PosPromotionId).HasColumnName("pos_promotion_id");

                entity.Property(e => e.ProductChineseNameEnable)
                    .HasColumnName("product_chinese_name_enable")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.ReceiptFooter)
                    .HasColumnName("receipt_footer")
                    .HasDefaultValueSql("'Thank you! Have a nice day!'::character varying");

                entity.Property(e => e.ReceiptLogoEnable)
                    .HasColumnName("receipt_logo_enable")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.RolePowerLevelToChangePayment)
                    .HasColumnName("role_power_level_to_change_payment")
                    .HasDefaultValueSql("10");

                entity.Property(e => e.RolePowerLevelToDiscount)
                    .HasColumnName("role_power_level_to_discount")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.RolePowerLevelToRefund)
                    .HasColumnName("role_power_level_to_refund")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.RolePowerLevelToViewReport)
                    .HasColumnName("role_power_level_to_view_report")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.RoundingCashPaymentEnable)
                    .HasColumnName("rounding_cash_payment_enable")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.RoundingToNearestValue)
                    .HasColumnName("rounding_to_nearest_value")
                    .HasDefaultValueSql("0.1");

                entity.Property(e => e.SecureLoginAlphanumericEnable)
                    .HasColumnName("secure_login_alphanumeric_enable")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.SecureLoginEnable)
                    .HasColumnName("secure_login_enable")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.SecureLoginMaxInvalidLoginAttempt)
                    .HasColumnName("secure_login_max_invalid_login_attempt")
                    .HasDefaultValueSql("6");

                entity.Property(e => e.SecureLoginMaxPasswordAge)
                    .HasColumnName("secure_login_max_password_age")
                    .HasDefaultValueSql("90");

                entity.Property(e => e.SecureLoginMinPasswordAge)
                    .HasColumnName("secure_login_min_password_age")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.SecureLoginMinPasswordLength)
                    .HasColumnName("secure_login_min_password_length")
                    .HasDefaultValueSql("8");

                entity.Property(e => e.SecureLoginNoDifferentFromPreviousPassword)
                    .HasColumnName("secure_login_no_different_from_previous_password")
                    .HasDefaultValueSql("4");

                entity.Property(e => e.ShouldRoundUp)
                    .HasColumnName("should_round_up")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.StandAlone)
                    .HasColumnName("stand_alone")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.TaxEnable)
                    .HasColumnName("tax_enable")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.TaxValue)
                    .HasColumnName("tax_value")
                    .HasDefaultValueSql("7");
            });

            modelBuilder.Entity<PriceSchedule>(entity =>
            {
                entity.ToTable("price_schedule");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.PriceCold).HasColumnName("price_cold");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.StartOn).HasColumnName("start_on");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PriceSchedule)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("price_schedule_product_id_fkey");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("fki_product_category_id_fkey");

                entity.HasIndex(e => e.Name)
                    .HasName("product_name");

                entity.HasIndex(e => new { e.Barcode, e.BarcodeExtra1, e.BarcodeExtra2, e.BarcodeExtra3 })
                    .HasName("idx_product_barcode");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Barcode)
                    .HasColumnName("barcode")
                    .HasMaxLength(128);

                entity.Property(e => e.BarcodeExtra1)
                    .HasColumnName("barcode_extra1")
                    .HasMaxLength(128);

                entity.Property(e => e.BarcodeExtra2)
                    .HasColumnName("barcode_extra2")
                    .HasMaxLength(128);

                entity.Property(e => e.BarcodeExtra3)
                    .HasColumnName("barcode_extra3")
                    .HasMaxLength(128);

                entity.Property(e => e.CartonProductId).HasColumnName("carton_product_id");

                entity.Property(e => e.CartonQuantity).HasColumnName("carton_quantity");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.DoesSaleByWeight)
                    .HasColumnName("does_sale_by_weight")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Enable)
                    .HasColumnName("enable")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.IsCarton)
                    .HasColumnName("is_carton")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.IsNonTaxable)
                    .HasColumnName("is_non_taxable")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.IsOpenPrice)
                    .HasColumnName("is_open_price")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.ItemOnHand)
                    .HasColumnName("item_on_hand")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LastEdit)
                    .HasColumnName("last_edit")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.NameChinese)
                    .HasColumnName("name_chinese")
                    .HasMaxLength(255);

                entity.Property(e => e.PacketGroupId).HasColumnName("packet_group_id");

                entity.Property(e => e.PriceCold)
                    .HasColumnName("price_cold")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PriceUnit).HasColumnName("price_unit");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Uuid).HasColumnName("uuid");

                entity.Property(e => e.WeightScaleId)
                    .HasColumnName("weight_scale_id")
                    .HasMaxLength(5);

                entity.HasOne(d => d.CartonProduct)
                    .WithMany(p => p.InverseCartonProduct)
                    .HasForeignKey(d => d.CartonProductId)
                    .HasConstraintName("product_carton_product_id_fkey");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("product_category_id_fkey");
            });

            modelBuilder.Entity<ProductGroup>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.GroupId });

                entity.ToTable("product_group");

                entity.HasIndex(e => e.GroupId)
                    .HasName("fki_product_group_group_id");

                entity.HasIndex(e => e.ProductId)
                    .HasName("fki_product_group_product_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("1");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.ProductGroup)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_group_group_id_fkey");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductGroup)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_group_product_id_fkey");
            });

            modelBuilder.Entity<ProductPromotion>(entity =>
            {
                entity.ToTable("product_promotion");

                entity.HasIndex(e => e.GroupId1)
                    .HasName("fki_product_promotion_group_id_1_fkey");

                entity.HasIndex(e => e.GroupId2)
                    .HasName("fki_product_promotion_group_id_2_fkey");

                entity.HasIndex(e => e.ProductId1)
                    .HasName("fki_product_promotion_product_id_1_fkey");

                entity.HasIndex(e => e.ProductId2)
                    .HasName("fki_product_promotion_product_id_2_fkey");

                entity.HasIndex(e => e.PromotionId)
                    .HasName("fki_product_promotion_id_fkey");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Enable).HasColumnName("enable");

                entity.Property(e => e.EndDate).HasColumnName("end_date");

                entity.Property(e => e.GroupId1).HasColumnName("group_id_1");

                entity.Property(e => e.GroupId2).HasColumnName("group_id_2");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductId1).HasColumnName("product_id_1");

                entity.Property(e => e.ProductId2).HasColumnName("product_id_2");

                entity.Property(e => e.PromotionId).HasColumnName("promotion_id");

                entity.Property(e => e.Quantity1).HasColumnName("quantity_1");

                entity.Property(e => e.Quantity2).HasColumnName("quantity_2");

                entity.Property(e => e.StartDate).HasColumnName("start_date");

                entity.HasOne(d => d.GroupId1Navigation)
                    .WithMany(p => p.ProductPromotionGroupId1Navigation)
                    .HasForeignKey(d => d.GroupId1)
                    .HasConstraintName("product_promotion_group_id_1_fkey");

                entity.HasOne(d => d.GroupId2Navigation)
                    .WithMany(p => p.ProductPromotionGroupId2Navigation)
                    .HasForeignKey(d => d.GroupId2)
                    .HasConstraintName("product_promotion_group_id_2_fkey");

                entity.HasOne(d => d.ProductId1Navigation)
                    .WithMany(p => p.ProductPromotionProductId1Navigation)
                    .HasForeignKey(d => d.ProductId1)
                    .HasConstraintName("product_promotion_product_id_1_fkey");

                entity.HasOne(d => d.ProductId2Navigation)
                    .WithMany(p => p.ProductPromotionProductId2Navigation)
                    .HasForeignKey(d => d.ProductId2)
                    .HasConstraintName("product_promotion_product_id_2_fkey");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.ProductPromotion)
                    .HasForeignKey(d => d.PromotionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_promotion_promotion_id_fkey");
            });

            modelBuilder.Entity<ProductQuicklist>(entity =>
            {
                entity.ToTable("product_quicklist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Barcode)
                    .HasColumnName("barcode")
                    .HasMaxLength(128);

                entity.Property(e => e.DisplayName)
                    .HasColumnName("display_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Position).HasColumnName("position");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.QuicklistId).HasColumnName("quicklist_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductQuicklist)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_quicklist_product_id_fkey");

                entity.HasOne(d => d.Quicklist)
                    .WithMany(p => p.ProductQuicklist)
                    .HasForeignKey(d => d.QuicklistId)
                    .HasConstraintName("product_quicklist_quicklist_id_fkey");
            });

            modelBuilder.Entity<ProductSupplier>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.SupplierId });

                entity.ToTable("product_supplier");

                entity.HasIndex(e => e.ProductId)
                    .HasName("fki_product_supplier_product_id");

                entity.HasIndex(e => e.SupplierId)
                    .HasName("fki_product_supplier_supplier_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Enable)
                    .HasColumnName("enable")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Info).HasColumnName("info");

                entity.Property(e => e.LastEdit)
                    .HasColumnName("last_edit")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.SupplierCode)
                    .HasColumnName("supplier_code")
                    .HasMaxLength(128);

                entity.Property(e => e.TaxApplied)
                    .HasColumnName("tax_applied")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Uuid).HasColumnName("uuid");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductSupplier)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_supplier_product_id");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.ProductSupplier)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_supplier_supplier_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProductSupplier)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("product_supplier_user_id_fkey");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.ToTable("promotion");

                entity.HasIndex(e => e.ServerId)
                    .HasName("promotion_server_id_unique")
                    .IsUnique();

                entity.HasIndex(e => e.UserId)
                    .HasName("fki_promotion_user_id_fkey");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Enable).HasColumnName("enable");

                entity.Property(e => e.EndDate).HasColumnName("end_date");

                entity.Property(e => e.LastEdit)
                    .HasColumnName("last_edit")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.ServerId).HasColumnName("server_id");

                entity.Property(e => e.StartDate).HasColumnName("start_date");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(255);

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Promotion)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("promotion_user_id_fkey");
            });

            modelBuilder.Entity<Quicklist>(entity =>
            {
                entity.ToTable("quicklist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsWeightSale)
                    .HasColumnName("is_weight_sale")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Position).HasColumnName("position");
            });

            modelBuilder.Entity<Reportline>(entity =>
            {
                entity.ToTable("reportline");

                entity.HasIndex(e => e.Barcode)
                    .HasName("reportline_barcode");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("reportline_category_id");

                entity.HasIndex(e => e.DateCreated)
                    .HasName("reportline_date_created");

                entity.HasIndex(e => e.Name)
                    .HasName("reportline_name");

                entity.HasIndex(e => e.ProductId)
                    .HasName("reportline_product_id");

                entity.HasIndex(e => e.SupplierId)
                    .HasName("reportline_supplier_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Barcode)
                    .HasColumnName("barcode")
                    .HasMaxLength(128);

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.ColdApplied).HasColumnName("cold_applied");

                entity.Property(e => e.CostPrice).HasColumnName("cost_price");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.GstApplied).HasColumnName("gst_applied");

                entity.Property(e => e.GstValue).HasColumnName("gst_value");

                entity.Property(e => e.IsVoid)
                    .HasColumnName("is_void")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.OrderlineId).HasColumnName("orderline_id");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.PromotionApplied).HasColumnName("promotion_applied");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.SupplierId)
                    .HasColumnName("supplier_id")
                    .HasDefaultValueSql("'-1'::integer");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Reportline)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("reportline_order_id_fkey");

                entity.HasOne(d => d.Orderline)
                    .WithMany(p => p.Reportline)
                    .HasForeignKey(d => d.OrderlineId)
                    .HasConstraintName("reportline_orderline_id_fkey");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Reportline)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("reportline_product_id_fkey");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.HasIndex(e => e.Type)
                    .HasName("role_type_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.PowerLevel)
                    .HasColumnName("power_level")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Schema>(entity =>
            {
                entity.HasKey(e => e.Version);

                entity.ToTable("schema", "hangfire");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Server>(entity =>
            {
                entity.ToTable("server", "hangfire");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Lastheartbeat).HasColumnName("lastheartbeat");

                entity.Property(e => e.Updatecount).HasColumnName("updatecount");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("session");

                entity.HasIndex(e => e.EndUserId)
                    .HasName("fki_session_user_stop_fkey");

                entity.HasIndex(e => e.StartAt)
                    .HasName("session_start_at");

                entity.HasIndex(e => e.StartUserId)
                    .HasName("fki_session_user_fkey");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddFloatValue)
                    .HasColumnName("add_float_value")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CancelHolds)
                    .HasColumnName("cancel_holds")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CancelHoldsAmount).HasColumnName("cancel_holds_amount");

                entity.Property(e => e.CountOpenCashdrawer)
                    .HasColumnName("count_open_cashdrawer")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EndAt).HasColumnName("end_at");

                entity.Property(e => e.EndCash).HasColumnName("end_cash");

                entity.Property(e => e.EndCashboxValue).HasColumnName("end_cashbox_value");

                entity.Property(e => e.EndShiftCashBreakdownDictString).HasColumnName("end_shift_cash_breakdown_dict_string");

                entity.Property(e => e.EndUserId).HasColumnName("end_user_id");

                entity.Property(e => e.GstApplied).HasColumnName("gst_applied");

                entity.Property(e => e.GstValue).HasColumnName("gst_value");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.OkHolds)
                    .HasColumnName("ok_holds")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ReferenceNumber).HasColumnName("reference_number");

                entity.Property(e => e.RetainCashboxFloat)
                    .HasColumnName("retain_cashbox_float")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ServerId).HasColumnName("server_id");

                entity.Property(e => e.StartAt)
                    .HasColumnName("start_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.StartCash).HasColumnName("start_cash");

                entity.Property(e => e.StartCashboxFloat)
                    .HasColumnName("start_cashbox_float")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StartCashboxValue)
                    .HasColumnName("start_cashbox_value")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.StartShiftCashBreakdownDictString).HasColumnName("start_shift_cash_breakdown_dict_string");

                entity.Property(e => e.StartUserId).HasColumnName("start_user_id");

                entity.Property(e => e.TerminalUid)
                    .IsRequired()
                    .HasColumnName("terminal_uid")
                    .HasMaxLength(255);

                entity.Property(e => e.TotalHolds)
                    .HasColumnName("total_holds")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.EndUser)
                    .WithMany(p => p.SessionEndUser)
                    .HasForeignKey(d => d.EndUserId)
                    .HasConstraintName("session_user_stop_fkey");

                entity.HasOne(d => d.StartUser)
                    .WithMany(p => p.SessionStartUser)
                    .HasForeignKey(d => d.StartUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("session_user_start_fkey");
            });

            modelBuilder.Entity<Set>(entity =>
            {
                entity.ToTable("set", "hangfire");

                entity.HasIndex(e => new { e.Key, e.Value })
                    .HasName("set_key_value_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('hangfire.set_id_seq'::regclass)");

                entity.Property(e => e.Expireat).HasColumnName("expireat");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasColumnName("key")
                    .HasMaxLength(100);

                entity.Property(e => e.Score).HasColumnName("score");

                entity.Property(e => e.Updatecount).HasColumnName("updatecount");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("state", "hangfire");

                entity.HasIndex(e => e.Jobid)
                    .HasName("ix_hangfire_state_jobid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('hangfire.state_id_seq'::regclass)");

                entity.Property(e => e.Createdat).HasColumnName("createdat");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Jobid).HasColumnName("jobid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20);

                entity.Property(e => e.Reason)
                    .HasColumnName("reason")
                    .HasMaxLength(100);

                entity.Property(e => e.Updatecount).HasColumnName("updatecount");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.State)
                    .HasForeignKey(d => d.Jobid)
                    .HasConstraintName("state_jobid_fkey");
            });

            modelBuilder.Entity<Statement>(entity =>
            {
                entity.ToTable("statement");

                entity.HasIndex(e => e.JournalId)
                    .HasName("fki_statement_journal_id_fkey");

                entity.HasIndex(e => e.SessionId)
                    .HasName("fki_statement_session_id_fkey");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.JournalId).HasColumnName("journal_id");

                entity.Property(e => e.SessionId).HasColumnName("session_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Variance).HasColumnName("variance");

                entity.HasOne(d => d.Journal)
                    .WithMany(p => p.Statement)
                    .HasForeignKey(d => d.JournalId)
                    .HasConstraintName("statement_journal_id_fkey");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Statement)
                    .HasForeignKey(d => d.SessionId)
                    .HasConstraintName("statement_session_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Statement)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("statement_user_id_fkey");
            });

            modelBuilder.Entity<StatementLine>(entity =>
            {
                entity.ToTable("statement_line");

                entity.HasIndex(e => e.OrderId)
                    .HasName("fki_statement_line_order_id-fkey");

                entity.HasIndex(e => e.UserId)
                    .HasName("fki_statement_line_user_id_fkey");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.CreateAt)
                    .HasColumnName("create_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.IsVoid)
                    .HasColumnName("is_void")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.JournalId).HasColumnName("journal_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.PaidAmount).HasColumnName("paid_amount");

                entity.Property(e => e.StatementId).HasColumnName("statement_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Journal)
                    .WithMany(p => p.StatementLine)
                    .HasForeignKey(d => d.JournalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("statement_line_journal_id_fkey");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.StatementLine)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("statement_line_order_id-fkey");

                entity.HasOne(d => d.Statement)
                    .WithMany(p => p.StatementLine)
                    .HasForeignKey(d => d.StatementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("statement_line_statement_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.StatementLine)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("statement_line_user_id_fkey");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("supplier");

                entity.HasIndex(e => e.Name)
                    .HasName("supplier_name_fkey");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Enable)
                    .HasColumnName("enable")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.LastEdit).HasColumnName("last_edit");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Uuid).HasColumnName("uuid");
            });

            modelBuilder.Entity<SyncHistory>(entity =>
            {
                entity.ToTable("sync_history");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.ServerTime).HasColumnName("server_time");

                entity.Property(e => e.StartTime).HasColumnName("start_time");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.SyncToken)
                    .HasColumnName("sync_token")
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Pin)
                    .HasName("users_pin_key")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("users_username_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DoesRequirePasswordChange)
                    .HasColumnName("does_require_password_change")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Enable)
                    .HasColumnName("enable")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.InvalidLoginAttempts)
                    .HasColumnName("invalid_login_attempts")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LastLogin).HasColumnName("last_login");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Pin)
                    .IsRequired()
                    .HasColumnName("pin");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_role_id_fkey");
            });

            modelBuilder.Entity<UsersPasswordHistory>(entity =>
            {
                entity.ToTable("users_password_history");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateAt).HasColumnName("create_at");

                entity.Property(e => e.CreatorId).HasColumnName("creator_id");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.UsersPasswordHistoryCreator)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_password_history_creator_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersPasswordHistoryUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_password_history_user_id_fkey");
            });

            modelBuilder.Entity<Version>(entity =>
            {
                entity.ToTable("version");

                entity.HasIndex(e => e.MacAddress)
                    .HasName("version_mac_address_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AppVersion)
                    .HasColumnName("app_version")
                    .HasMaxLength(255);

                entity.Property(e => e.DatabaseVersion)
                    .HasColumnName("database_version")
                    .HasMaxLength(60);

                entity.Property(e => e.IpAddress)
                    .HasColumnName("ip_address")
                    .HasMaxLength(255);

                entity.Property(e => e.IsSingleMallReport)
                    .HasColumnName("is_single_mall_report")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.MacAddress)
                    .HasColumnName("mac_address")
                    .HasMaxLength(255);

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasMaxLength(255);

                entity.Property(e => e.TerminalName)
                    .HasColumnName("terminal_name")
                    .HasMaxLength(255);
            });

            modelBuilder.HasSequence("counter_id_seq");

            modelBuilder.HasSequence("hash_id_seq");

            modelBuilder.HasSequence("job_id_seq");

            modelBuilder.HasSequence("jobparameter_id_seq");

            modelBuilder.HasSequence("jobqueue_id_seq");

            modelBuilder.HasSequence("list_id_seq");

            modelBuilder.HasSequence("set_id_seq");

            modelBuilder.HasSequence("state_id_seq");

            modelBuilder.HasSequence("category_id_seq");
        }
    }
}
