using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using zilicoPOSAPI.Models;

namespace zilicoPOSAPI.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<RoleGroup> RoleGroups { get; set; }
        public DbSet<SysFunctionality> SysFunctionalities { get; set; }
        public DbSet<SysModule> SysModules { get; set; }
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // User and UserProfile mapping (one-to-one relationship)
            builder.Entity<User>()
                .HasOne(u => u.UserProfile)
                .WithOne(up => up.User)
                .HasForeignKey<UserProfile>(up => up.UserId);

            // Login and User mapping (one-to-many relationship)
            builder.Entity<Login>()
                .HasOne(l => l.User)
                .WithMany(u => u.Logins)
                .HasForeignKey(l => l.UserId);

            // Login and UserGroup mapping (many-to-one relationship)
            builder.Entity<Login>()
                .HasOne(l => l.UserGroup)
                .WithMany(ug => ug.Logins)
                .HasForeignKey(l => l.UserGroupId);

            // UserGroup and RoleGroup mapping (many-to-many relationship)
            builder.Entity<UserGroup>()
                .HasMany(ug => ug.RoleGroups)
                .WithMany(rg => rg.UserGroups)
                .UsingEntity<Dictionary<string, object>>(
                    "UserGroupRoleGroup",
                    j => j.HasOne<RoleGroup>().WithMany().HasForeignKey("RoleGroupId"),
                    j => j.HasOne<UserGroup>().WithMany().HasForeignKey("UserGroupId")
                );

            // RoleGroup to SysFunctionality mapping (one-to-many relationship)
            builder.Entity<RoleGroup>()
                .HasMany(rg => rg.SysFunctionalities)
                .WithOne(sf => sf.RoleGroup)
                .HasForeignKey(sf => sf.RoleGroupId);

            // RoleGroup to SysModule mapping (one-to-many relationship)
            builder.Entity<RoleGroup>()
            .HasMany(rg => rg.SysModules)
            .WithOne(sm => sm.RoleGroup)
            .HasForeignKey(sm => sm.RoleGroupId);
        }
    }

}