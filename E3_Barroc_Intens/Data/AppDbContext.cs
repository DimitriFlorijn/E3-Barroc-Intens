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
        public DbSet<CustomerOder> CustomerOrders { get; set; }
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

            modelBuilder.Entity<RoleUser>().HasKey(
                ru => new { ru.UserId, ru.RoleId }
            );

            modelBuilder.Entity<Storage>().HasKey(
                s => new { s.PartId, s.BeanId, s.ProductId }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "CEO"
                },
                new Role
                {
                    Id = 2,
                    Name = "Head Finance"
                },
                new Role
                {
                    Id = 3,
                    Name = "Financiële Administratie"
                },
                new Role
                {
                    Id = 4,
                    Name = "Head Sales"
                },
                new Role
                {
                    Id = 5,
                    Name = "Consultant"
                },
                new Role
                {
                    Id = 6,
                    Name = "Head Inkoop"
                },
                new Role
                {
                    Id = 7,
                    Name = "Inkoper"
                },
                new Role
                {
                    Id = 8,
                    Name = "Medewerker magazijn"
                },
                new Role
                {
                    Id = 9,
                    Name = "Head Maintenance"
                },
                new Role
                {
                    Id = 10,
                    Name = "Technische Dienst"
                },
                new Role
                {
                    Id = 11,
                    Name = "Planner"
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Joris Pullens",
                    Email = "Joris.Pullens@Barroc.Intens.com",
                    Password = "Joris Pullens"
                },
                new User
                {
                    Id = 2,
                    Name = "Maarten Pullens",
                    Email = "Maarten.Pullens@Barroc.Intens.com",
                    Password = "Maarten Pullens"
                },
                new User
                {
                    Id = 3,
                    Name = "Ingeborg van Lier",
                    Email = "Ingeborg.van.Liers@Barroc.Intens.com",
                    Password = "Ingeborg van Lier"
                },
                new User
                {
                    Id = 4,
                    Name = "Asley van de Sluis",
                    Email = "Asley.van.de.Sluis@Barroc.Intens.com",
                    Password = "Asley van de Sluis"
                },
                new User
                {
                    Id = 5,
                    Name = "Guillaume de Randamie",
                    Email = "Guillaume.de.Randamie@Barroc.Intens.com",
                    Password = "Guillaume de Randamie"
                },
                new User
                {
                    Id = 6,
                    Name = "Annemie Meijaard",
                    Email = "Annemie.Meijaard@Barroc.Intens.com",
                    Password = "Annemie Meijaard"
                },
                new User
                {
                    Id = 7,
                    Name = "John Vrees",
                    Email = "John.Vrees@Barroc.Intens.com",
                    Password = "John Vrees"
                },
                new User
                {
                    Id = 8,
                    Name = "Evelien Rosse",
                    Email = "Evelien.Rosse@Barroc.Intens.com",
                    Password = "Evelien Rosse"
                },
                new User
                {
                    Id = 9,
                    Name = "Max Roerdomp",
                    Email = "Max.Roerdomp@Barroc.Intens.com",
                    Password = "Max Roerdomp"
                },
                new User
                {
                    Id = 10,
                    Name = "Simon Nagelkerke",
                    Email = "Simon.Nagelkerke@Barroc.Intens.com",
                    Password = "Simon Nagelkerke"
                },
                new User
                {
                    Id = 11,
                    Name = "Muhammad Demir",
                    Email = "Muhammad.Demir@Barroc.Intens.com",
                    Password = "Muhammad Demir"
                },
                new User
                {
                    Id = 12,
                    Name = "Paul Machielsen",
                    Email = "Paul.Machielsen@Barroc.Intens.com",
                    Password = "Paul Machielsen"
                },
                new User
                {
                    Id = 13,
                    Name = "Cindy Passier",
                    Email = "Cindy.Passier@Barroc.Intens.com",
                    Password = "Simon.Nagelkerke"
                },
                new User
                {
                    Id = 14,
                    Name = "Piotr Loszarowski",
                    Email = "Piotr.Loszarowski@Barroc.Intens.com",
                    Password = "Piotr Loszarowski"
                },
                new User
                {
                    Id = 15,
                    Name = "Jimmy Choi",
                    Email = "Jimmy.Choi@Barroc.Intens.com",
                    Password = "Jimmy Choi"
                }
            );

            modelBuilder.Entity<RoleUser>().HasData(
                new RoleUser
                {
                    RoleId = 1,
                    UserId = 1,
                },
                new RoleUser
                {
                    RoleId = 1,
                    UserId = 2,
                },
                new RoleUser
                {
                    RoleId = 2,
                    UserId = 1,
                },
                new RoleUser
                {
                    RoleId = 3,
                    UserId = 3,
                },
                new RoleUser
                {
                    RoleId = 3,
                    UserId = 4,
                },
                new RoleUser
                {
                    RoleId = 4,
                    UserId = 2,
                },
                new RoleUser
                {
                    RoleId = 5,
                    UserId = 5,
                },
                new RoleUser
                {
                    RoleId = 5,
                    UserId = 6,
                },
                new RoleUser
                {
                    RoleId = 6,
                    UserId = 7,
                },
                new RoleUser
                {
                    RoleId = 7,
                    UserId = 8,
                },
                new RoleUser
                {
                    RoleId = 8,
                    UserId = 9,
                },
                new RoleUser
                {
                    RoleId = 9,
                    UserId = 10,
                },
                new RoleUser
                {
                    RoleId = 10,
                    UserId = 11,
                },
                new RoleUser
                {
                    RoleId = 10,
                    UserId = 12,
                },
                new RoleUser
                {
                    RoleId = 10,
                    UserId = 13,
                },
                new RoleUser
                {
                    RoleId = 10,
                    UserId = 14,
                },
                new RoleUser
                {
                    RoleId = 11,
                    UserId = 15,
                }
            );
        }
    }
}
