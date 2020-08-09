using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using QL_Vat_Lieu_Xay_Dung_Data.Entities;
using QL_Vat_Lieu_Xay_Dung_Data.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Data_EF.Configurations;
using QL_Vat_Lieu_Xay_Dung_Data_EF.Extensions;
using System;
using System.IO;
using System.Linq;

namespace QL_Vat_Lieu_Xay_Dung_Data_EF
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<AppRole> AppRoles { get; set; }

        public DbSet<Announcement> Announcements { set; get; }

        public DbSet<AnnouncementUser> AnnouncementUsers { set; get; }

        public DbSet<Bill> Bills { set; get; }

        public DbSet<BillDetail> BillDetails { set; get; }

        public DbSet<Contact> Contacts { set; get; }

        public DbSet<Feedback> Feedbacks { set; get; }

        public DbSet<Function> Functions { set; get; }

        public DbSet<Permission> Permissions { set; get; }

        public DbSet<Product> Products { set; get; }

        public DbSet<ProductCategory> ProductCategories { set; get; }

        public DbSet<ProductTag> ProductTags { set; get; }

        public DbSet<ProductImage> ProductImages { set; get; }

        public DbSet<ProductReceiptDetail> ProductReceiptDetails { set; get; }

        public DbSet<ProductReceipt> ProductReceipts { set; get; }

        public DbSet<Supplier> Suppliers { set; get; }

        public DbSet<Brand> Brands { set; get; }

        public DbSet<Size> Sizes { set; get; }

        public DbSet<Slide> Slides { set; get; }

        public DbSet<Tag> Tags { set; get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims").HasKey(x => x.Id);
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims").HasKey(x => x.Id);
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(c => c.UserId);
            builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(c => new { c.RoleId, c.UserId });
            builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);

            builder.AddConfiguration(new TagConfiguration());
            builder.AddConfiguration(new ContactConfiguration());
            builder.AddConfiguration(new FunctionConfiguration());
            builder.AddConfiguration(new ProductTagConfiguration());
            // base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            var modified = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);
            foreach (var itemEntityEntry in modified)
            {
                var changedOrAddedItem = itemEntityEntry.Entity as IDateTracking;
                if (changedOrAddedItem != null)
                {
                    if (itemEntityEntry.State == EntityState.Added)
                        changedOrAddedItem.DateCreated = DateTime.Now;
                    else
                        changedOrAddedItem.DateModified = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new AppDbContext(builder.Options);
        }
    }
}