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
        public DbSet<IncendentReport> IncendentReports { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

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

            modelBuilder.Entity<Brand>().HasData(
                new Brand
                {
                    Id = 1,
                    Name = "Barroc Intens"
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Barroc Intens Italian Light",
                    Description = "S234FREKT",
                    Type = "Koffieautomaat",
                    Price = 499.00M,
                    InstallationCost = 289.00M,
                    BrandId = 1,
                },
                new Product
                {
                    Id = 2,
                    Name = "Barroc Intens Italian",
                    Description = "S234KNDPF",
                    Type = "Koffieautomaat",
                    Price = 599.00M,
                    InstallationCost = 289.00M,
                    BrandId = 1,
                },
                new Product
                {
                    Id = 3,
                    Name = "Barroc Intens Italian Deluxe",
                    Description = "S234NNBMV",
                    Type = "Koffieautomaat",
                    Price = 799.00M,
                    InstallationCost = 375.00M,
                    BrandId = 1,
                },
                new Product
                {
                    Id = 4,
                    Name = "Barroc Intens Italian Deluxe Special",
                    Description = "S234MMPLA",
                    Type = "Koffieautomaat",
                    Price = 999.00M,
                    InstallationCost = 375.00M,
                    BrandId = 1,
                }
            );

            modelBuilder.Entity<Bean>().HasData(
                new Bean
                {
                    Id = 1,
                    Name = "Espresso Beneficio",
                    Description = "Een toegankelijke en zachte koffie. Hij is afkomstig van de Finca El Limoncillo, een weelderige plantage aan de rand van het regenwoud in de Matagalpa regio in Nicaragua.",
                    Type = "S239KLIUP",
                    PricePerKg = 21.60m
                },
                new Bean
                {
                    Id = 2,
                    Name = "Yellow Bourbon Brasil",
                    Description = "Koffie van de oorspronkelijke koffiestruik (de Bourbon) met gele koffiebessen. Deze zeldzame koffie heeft de afgelopen 20 jaar steeds meer erkenning gekregen en vele prijzen gewonnen.",
                    Type = "S239MNKLL",
                    PricePerKg = 23.20m
                },
                new Bean
                {
                    Id = 3,
                    Name = "Espresso Roma",
                    Description = "Een Italiaanse espresso met een krachtig karakter en een aromatische afdronk.",
                    Type = "S239IPPSD",
                    PricePerKg = 20.80m
                },
                new Bean
                {
                    Id = 4,
                    Name = "Red Honey Honduras",
                    Description = "De koffie is geproduceerd volgens de honey-methode. Hierbij wordt de koffieboon in haar vruchtvlees gedroogd, waardoor de zoete fruitsmaak diep in de boon trekt. Dit levert een éxtra zoete koffie op.",
                    Type = "S239EVVFS",
                    PricePerKg = 27.80m
                }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Klant Actief 1", Email = "actief1@example.com", Location = "Locatie 1", Number = "0612345678", BkrRegistered = false },
                new Customer { Id = 2, Name = "Klant Actief 2", Email = "actief2@example.com", Location = "Locatie 2", Number = "0612345679", BkrRegistered = false },
                new Customer { Id = 3, Name = "Klant Actief 3", Email = "actief3@example.com", Location = "Locatie 3", Number = "0612345680", BkrRegistered = false },
                new Customer { Id = 4, Name = "Klant Actief 4", Email = "actief4@example.com", Location = "Locatie 4", Number = "0612345681", BkrRegistered = false },
                new Customer { Id = 5, Name = "Klant Actief 5", Email = "actief5@example.com", Location = "Locatie 5", Number = "0612345682", BkrRegistered = false },
                new Customer { Id = 151, Name = "Klant Inactief 1", Email = "inactief1@example.com", Location = "Locatie 151", Number = "0612345688", BkrRegistered = false },
                new Customer { Id = 152, Name = "Klant Inactief 2", Email = "inactief2@example.com", Location = "Locatie 152", Number = "0612345689", BkrRegistered = true },
                new Customer { Id = 153, Name = "Klant Inactief 3", Email = "inactief3@example.com", Location = "Locatie 153", Number = "0612345690", BkrRegistered = false },
                new Customer { Id = 154, Name = "Klant Inactief 4", Email = "inactief4@example.com", Location = "Locatie 154", Number = "0612345691", BkrRegistered = false },
                new Customer { Id = 155, Name = "Klant Inactief 5", Email = "inactief5@example.com", Location = "Locatie 155", Number = "0612345692", BkrRegistered = false }
            );
        }
    }
}
