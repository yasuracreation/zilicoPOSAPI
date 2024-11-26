using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace zilicoPOSAPI.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        // User Management
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<RoleGroup> RoleGroups { get; set; }
        public DbSet<SysFunctionality> SysFunctionalities { get; set; }
        public DbSet<SysModule> SysModules { get; set; }

        // Approval
        public DbSet<Approval> Approvals { get; set; }

        // Product Management
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }

        // Inventory Management
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<InventoryTransaction> InventoryTransactions { get; set; }
        public DbSet<ItemLocation> ItemLocations { get; set; }

        // Transactions
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<GRN> GRNs { get; set; }
        public DbSet<GRNDetails> GRNDetails { get; set; }
        public DbSet<GTN> GTNs { get; set; }
        public DbSet<GTNDetails> GTNDetails { get; set; }

        // Audit
        public DbSet<Audit> Audits { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // User and UserProfile (One-to-One)
            builder.Entity<User>()
                .HasOne(u => u.UserProfile)
                .WithOne(up => up.User)
                .HasForeignKey<UserProfile>(up => up.UserId);

            // User and Login (One-to-Many)
            builder.Entity<Login>()
                .HasOne(l => l.User)
                .WithMany(u => u.Logins)
                .HasForeignKey(l => l.UserId);

            // UserGroup and RoleGroup (Many-to-Many)
            builder.Entity<UserGroup>()
                .HasMany(ug => ug.RoleGroups)
                .WithMany(rg => rg.UserGroups)
                .UsingEntity<Dictionary<string, object>>(
                    "UserGroupRoleGroup",
                    j => j.HasOne<RoleGroup>().WithMany().HasForeignKey("RoleGroupId"),
                    j => j.HasOne<UserGroup>().WithMany().HasForeignKey("UserGroupId")
                );

            // RoleGroup and SysFunctionality (One-to-Many)
            builder.Entity<RoleGroup>()
                .HasMany(rg => rg.SysFunctionalities)
                .WithOne(sf => sf.RoleGroup)
                .HasForeignKey(sf => sf.RoleGroupId);

            // RoleGroup and SysModule (One-to-Many)
            builder.Entity<RoleGroup>()
                .HasMany(rg => rg.SysModules)
                .WithOne(sm => sm.RoleGroup)
                .HasForeignKey(sm => sm.RoleGroupId);

            // Product and Category (One-to-Many)
            // builder.Entity<Category>()
            //     .HasMany(c => c.Products)
            //     .WithOne(p => p.Category)
            //     .HasForeignKey(p => p.CategoryId);
            //
            // // Sale and SaleDetails (One-to-Many)
            // builder.Entity<Sale>()
            //     .HasMany(s => s.SaleDetails)
            //     .WithOne(sd => sd.Sale)
            //     .HasForeignKey(sd => sd.SaleId);
            //
            // // PurchaseOrder and PurchaseOrderDetail (One-to-Many)
            // builder.Entity<PurchaseOrder>()
            //     .HasMany(po => po.PurchaseOrderDetails)
            //     .WithOne(pod => pod.PurchaseOrder)
            //     .HasForeignKey(pod => pod.PurchaseOrderId);
            //
            // // Supplier and PurchaseOrder (One-to-Many)
            // builder.Entity<Supplier>()
            //     .HasMany(s => s.PurchaseOrders)
            //     .WithOne(po => po.Supplier)
            //     .HasForeignKey(po => po.SupplierId);
            //
            // // Inventory and InventoryItems (One-to-Many)
            // builder.Entity<Inventory>()
            //     .HasMany(i => i.InventoryItems);
            //
            // // Batch and InventoryItem (One-to-Many)
            // builder.Entity<Batch>()
            //     .HasMany(b => b.InventoryItems)
            //     .WithOne(ii => ii.Batch)
            //     .HasForeignKey(ii => ii.BatchId);
            //
            // // GRN and GRNDetails (One-to-Many)
            // builder.Entity<GRN>()
            //     .HasMany(grn => grn.GRNDetails)
            //     .WithOne(grnd => grnd.GRN)
            //     .HasForeignKey(grnd => grnd.GRNId);
            //
            // // GTN and GTNDetails (One-to-Many)
            // builder.Entity<GTN>()
            //     .HasMany(gtn => gtn.GTNDetails)
            //     .WithOne(gtnd => gtnd.GTN)
            //     .HasForeignKey(gtnd => gtnd.GTNId);
            //
            //   builder.Entity<User>()
            //     .HasMany(u => u.Shifts)
            //     .WithOne(s => s.User)
            //     .HasForeignKey(s => s.UserId);
            //
            // // Shifts and Orders (One-to-Many)
            // builder.Entity<Shift>()
            //     .HasMany(s => s.Orders)
            //     .WithOne(o => o.Shift)
            //     .HasForeignKey(o => o.ShiftId);
            //
            // // Orders and OrderDetails (One-to-Many)
            // builder.Entity<Order>()
            //     .HasMany(o => o.OrderDetails)
            //     .WithOne(od => od.Order)
            //     .HasForeignKey(od => od.OrderId);
            //
            // // Products and Categories (One-to-Many)
            // builder.Entity<Category>()
            //     .HasMany(c => c.Products)
            //     .WithOne(p => p.Category)
            //     .HasForeignKey(p => p.CategoryId);
                
            builder.Entity<Audit>()
            .Property(a => a.EntityName)
            .IsRequired();    
        }
    }
}
