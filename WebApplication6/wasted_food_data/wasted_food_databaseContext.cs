using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApplication6.Models;

namespace WastedFoodSystemAdmin.wasted_food_data
{
    public partial class wasted_food_databaseContext : DbContext
    {
        public wasted_food_databaseContext()
        {
        }

        public wasted_food_databaseContext(DbContextOptions<wasted_food_databaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Buyer> Buyer { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<ListFollow> ListFollow { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Report> Report { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Seller> Seller { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=127.0.0.1;port=3306;user=root;password=1234;database=wasted_food_database; convert zero datetime=True");
                //optionsBuilder.UseMySQL("server=p1us8ottbqwio8hv.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;port=3306;user=opz3hmxpxk0vfl21;password=swc44g1p3ciko317;database=eaur5hgdarhpvk2e; convert zero datetime=True;persistsecurityinfo=True;allowuservariables=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account");

                entity.HasIndex(e => e.Phone)
                    .HasName("phone")
                    .IsUnique();

                entity.HasIndex(e => e.ThirdPartyId)
                    .HasName("third_party_id")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("username")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FirebaseUid)
                    .IsRequired()
                    .HasColumnName("firebase_UID")
                    .HasMaxLength(510)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ThirdPartyId)
                    .HasColumnName("third_party_id")
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PRIMARY");

                entity.ToTable("admin");

                entity.Property(e => e.AccountId)
                    .HasColumnName("account_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnName("image")
                    .HasMaxLength(510)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.SecurityLevel)
                    .HasColumnName("security_level")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PRIMARY");

                entity.ToTable("buyer");

                entity.Property(e => e.AccountId)
                    .HasColumnName("account_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("date_of_birth")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(510)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("feedback");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AccountId)
                    .HasColumnName("account_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.FeedbackText)
                    .IsRequired()
                    .HasColumnName("feedback_text")
                    .HasMaxLength(1020)
                    .IsUnicode(false);

                entity.Property(e => e.IsRead)
                    .HasColumnName("is_read")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ListFollow>(entity =>
            {
                entity.HasKey(e => new { e.BuyerId, e.SellerId })
                    .HasName("PRIMARY");

                entity.ToTable("list_follow");

                entity.Property(e => e.BuyerId)
                    .HasColumnName("buyer_id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.SellerId)
                    .HasColumnName("seller_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsFollow)
                    .HasColumnName("is_follow")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("'current_timestamp()'");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("notification");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasMaxLength(1050)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ReceiverId)
                    .HasColumnName("receiver_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Seen)
                    .HasColumnName("seen")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.SenderId)
                    .HasColumnName("sender_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BuyerComment)
                    .HasColumnName("buyer_comment")
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.BuyerId)
                    .HasColumnName("buyer_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BuyerRating)
                    .HasColumnName("buyer_rating")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalCost).HasColumnName("total_cost");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EndTime).HasColumnName("end_time");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(510)
                    .IsUnicode(false);

                entity.Property(e => e.OriginalPrice).HasColumnName("original_price");

                entity.Property(e => e.OriginalQuantity)
                    .HasColumnName("original_quantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RemainQuantity)
                    .HasColumnName("remain_quantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SellDate).HasColumnName("sell_date");

                entity.Property(e => e.SellPrice).HasColumnName("sell_price");

                entity.Property(e => e.SellerId)
                    .HasColumnName("seller_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Shippable)
                    .HasColumnName("shippable")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.StartTime).HasColumnName("start_time");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("report");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AccusedId)
                    .HasColumnName("accused_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.ReportImage)
                    .HasColumnName("report_image")
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ReportText)
                    .IsRequired()
                    .HasColumnName("report_text")
                    .HasMaxLength(1020)
                    .IsUnicode(false);

                entity.Property(e => e.ReporterId)
                    .HasColumnName("reporter_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasColumnName("role_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PRIMARY");

                entity.ToTable("seller");

                entity.Property(e => e.AccountId)
                    .HasColumnName("account_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(510)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasMaxLength(510)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(510)
                    .IsUnicode(false);

                entity.Property(e => e.Rating).HasColumnName("rating").HasDefaultValueSql("'NULL'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<WebApplication6.Models.AccountSellerViewModel> AccountSellerViewModel { get; set; }

        public DbSet<WebApplication6.Models.LoginViewModel> LoginViewModel { get; set; }

        public DbSet<WebApplication6.Models.AccountBuyerViewModel> AccountBuyerViewModel { get; set; }
    }
}
