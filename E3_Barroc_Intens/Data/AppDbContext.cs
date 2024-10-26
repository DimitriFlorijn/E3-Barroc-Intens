using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_Barroc_Intens.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Bean> Bean { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerOder> CustomerOders { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<PartOrder> PartOrder { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RoleUser> RoleUsers { get; set; }
        public DbSet<Storage> Storages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                ConfigurationManager.ConnectionStrings["E3-Barroc-Intens-Database"].ConnectionString,
                ServerVersion.Parse("8.0.30")

            );

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contract>().HasKey(
                c => new { c.ProductId, c.BeanId, c.CustomerId }
            );

            modelBuilder.Entity<CustomerOder>().HasKey(
                co => new { co.CustomerId, co.DateTime }
            );

            modelBuilder.Entity<Maintenance>().HasKey(
                m => new { m.UserId, m.CostumerId }
            );

            modelBuilder.Entity<PartOrder>().HasKey(
                po => new { po.PartId }
            );

            modelBuilder.Entity<RoleUser>().HasKey(
                ru => new { ru.UserId, ru.RoleId }
            );

            modelBuilder.Entity<Storage>().HasKey(
                s => new { s.PartId, s.BeanId, s.ProductId }
            );
        }
    }
}
