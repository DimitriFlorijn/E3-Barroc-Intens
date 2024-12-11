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
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<PartOrder> PartOrder { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RoleUser> RoleUsers { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<IncendentReport> IncendentReports { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                ConfigurationManager.ConnectionStrings["E3-Barroc-Intens-Database"].ConnectionString,
                ServerVersion.Parse("8.0.30")

            );

        }
        // zie  data / app db config example 
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySql(
        //            "server=localhost;" +
        //            "port=3306;" +
        //            "user=root;" +
        //            "password=;" +
        //            "database=E3-Barroc-Intens-Database",
        //        new MySqlServerVersion(new Version(8, 0, 30)));
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RoleUser>().HasKey(
                ru => new { ru.UserId, ru.RoleId }
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
                    Name = "Finance"
                },
                new Role
                {
                    Id =3,
                    Name = "Sales"
                },
                new Role
                {
                    Id = 4,
                    Name = "Inkoop"
                },
                new Role
                {
                    Id = 5,
                    Name = "Maintenance"
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
                    Password = "Cindy Passier"
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
                    RoleId = 2,
                    UserId = 3,
                },
                new RoleUser
                {
                    RoleId = 2,
                    UserId = 4,
                },
                new RoleUser
                {
                    RoleId = 3,
                    UserId = 2,
                },
                new RoleUser
                {
                    RoleId = 3,
                    UserId = 5,
                },
                new RoleUser
                {
                    RoleId = 3,
                    UserId = 6,
                },
                new RoleUser
                {
                    RoleId = 4,
                    UserId = 7,
                },
                new RoleUser
                {
                    RoleId = 4,
                    UserId = 8,
                },
                new RoleUser
                {
                    RoleId = 4,
                    UserId = 9,
                },
                new RoleUser
                {
                    RoleId = 5,
                    UserId = 10,
                },
                new RoleUser
                {
                    RoleId = 5,
                    UserId = 11,
                },
                new RoleUser
                {
                    RoleId = 5,
                    UserId = 12,
                },
                new RoleUser
                {
                    RoleId = 5,
                    UserId = 13,
                },
                new RoleUser
                {
                    RoleId = 5,
                    UserId = 14,
                },
                new RoleUser
                {
                    RoleId = 5,
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
                new Customer
                {
                    Id = 1,
                    Name = "Klant Actief 1",
                    Email = "actief1@example.com",
                    Location = "Locatie 1",
                    Number = "0612345678",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 2,
                    Name = "Klant Actief 2",
                    Email = "actief2@example.com",
                    Location = "Locatie 2",
                    Number = "0612345679",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 3,
                    Name = "Klant Actief 3",
                    Email = "actief3@example.com",
                    Location = "Locatie 3",
                    Number = "0612345680",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 4,
                    Name = "Klant Actief 4",
                    Email = "actief4@example.com",
                    Location = "Locatie 4",
                    Number = "0612345681",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 5,
                    Name = "Klant Actief 5",
                    Email = "actief5@example.com",
                    Location = "Locatie 5",
                    Number = "0612345682",
                    BkrRegistered = false
                },
                /*new Customer
                {
                    Id = 6,
                    Name = "Klant Actief 6",
                    Email = "actief6@example.com",
                    Location = "Locatie 6",
                    Number = "0612345683",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 7,
                    Name = "Klant Actief 7",
                    Email = "actief7@example.com",
                    Location = "Locatie 7",
                    Number = "0612345684",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 8,
                    Name = "Klant Actief 8",
                    Email = "actief8@example.com",
                    Location = "Locatie 8",
                    Number = "0612345685",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 9,
                    Name = "Klant Actief 9",
                    Email = "actief9@example.com",
                    Location = "Locatie 9",
                    Number = "0612345686",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 10,
                    Name = "Klant Actief 10",
                    Email = "actief10@example.com",
                    Location = "Locatie 10",
                    Number = "0612345687",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 11,
                    Name = "Klant Actief 11",
                    Email = "actief11@example.com",
                    Location = "Locatie 11",
                    Number = "0612345688",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 12,
                    Name = "Klant Actief 12",
                    Email = "actief12@example.com",
                    Location = "Locatie 12",
                    Number = "0612345689",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 13,
                    Name = "Klant Actief 13",
                    Email = "actief13@example.com",
                    Location = "Locatie 13",
                    Number = "0612345690",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 14,
                    Name = "Klant Actief 14",
                    Email = "actief14@example.com",
                    Location = "Locatie 14",
                    Number = "0612345691",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 15,
                    Name = "Klant Actief 15",
                    Email = "actief15@example.com",
                    Location = "Locatie 15",
                    Number = "0612345692",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 16,
                    Name = "Klant Actief 16",
                    Email = "actief16@example.com",
                    Location = "Locatie 16",
                    Number = "0612345693",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 17,
                    Name = "Klant Actief 17",
                    Email = "actief17@example.com",
                    Location = "Locatie 17",
                    Number = "0612345694",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 18,
                    Name = "Klant Actief 18",
                    Email = "actief18@example.com",
                    Location = "Locatie 18",
                    Number = "0612345695",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 19,
                    Name = "Klant Actief 19",
                    Email = "actief19@example.com",
                    Location = "Locatie 19",
                    Number = "0612345696",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 20,
                    Name = "Klant Actief 20",
                    Email = "actief20@example.com",
                    Location = "Locatie 20",
                    Number = "0612345697",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 21,
                    Name = "Klant Actief 21",
                    Email = "actief21@example.com",
                    Location = "Locatie 21",
                    Number = "0612345698",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 22,
                    Name = "Klant Actief 22",
                    Email = "actief22@example.com",
                    Location = "Locatie 22",
                    Number = "0612345699",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 23,
                    Name = "Klant Actief 23",
                    Email = "actief23@example.com",
                    Location = "Locatie 23",
                    Number = "0612345700",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 24,
                    Name = "Klant Actief 24",
                    Email = "actief24@example.com",
                    Location = "Locatie 24",
                    Number = "0612345701",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 25,
                    Name = "Klant Actief 25",
                    Email = "actief25@example.com",
                    Location = "Locatie 25",
                    Number = "0612345702",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 26,
                    Name = "Klant Actief 26",
                    Email = "actief26@example.com",
                    Location = "Locatie 26",
                    Number = "0612345703",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 27,
                    Name = "Klant Actief 27",
                    Email = "actief27@example.com",
                    Location = "Locatie 27",
                    Number = "0612345704",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 28,
                    Name = "Klant Actief 28",
                    Email = "actief28@example.com",
                    Location = "Locatie 28",
                    Number = "0612345705",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 29,
                    Name = "Klant Actief 29",
                    Email = "actief29@example.com",
                    Location = "Locatie 29",
                    Number = "0612345706",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 30,
                    Name = "Klant Actief 30",
                    Email = "actief30@example.com",
                    Location = "Locatie 30",
                    Number = "0612345707",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 31,
                    Name = "Klant Actief 31",
                    Email = "actief31@example.com",
                    Location = "Locatie 31",
                    Number = "0612345708",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 32,
                    Name = "Klant Actief 32",
                    Email = "actief32@example.com",
                    Location = "Locatie 32",
                    Number = "0612345709",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 33,
                    Name = "Klant Actief 33",
                    Email = "actief33@example.com",
                    Location = "Locatie 33",
                    Number = "0612345710",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 34,
                    Name = "Klant Actief 34",
                    Email = "actief34@example.com",
                    Location = "Locatie 34",
                    Number = "0612345711",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 35,
                    Name = "Klant Actief 35",
                    Email = "actief35@example.com",
                    Location = "Locatie 35",
                    Number = "0612345712",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 36,
                    Name = "Klant Actief 36",
                    Email = "actief36@example.com",
                    Location = "Locatie 36",
                    Number = "0612345713",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 37,
                    Name = "Klant Actief 37",
                    Email = "actief37@example.com",
                    Location = "Locatie 37",
                    Number = "0612345714",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 38,
                    Name = "Klant Actief 38",
                    Email = "actief38@example.com",
                    Location = "Locatie 38",
                    Number = "0612345715",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 39,
                    Name = "Klant Actief 39",
                    Email = "actief39@example.com",
                    Location = "Locatie 39",
                    Number = "0612345716",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 40,
                    Name = "Klant Actief 40",
                    Email = "actief40@example.com",
                    Location = "Locatie 40",
                    Number = "0612345717",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 41,
                    Name = "Klant Actief 41",
                    Email = "actief41@example.com",
                    Location = "Locatie 41",
                    Number = "0612345718",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 42,
                    Name = "Klant Actief 42",
                    Email = "actief42@example.com",
                    Location = "Locatie 42",
                    Number = "0612345719",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 43,
                    Name = "Klant Actief 43",
                    Email = "actief43@example.com",
                    Location = "Locatie 43",
                    Number = "0612345720",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 44,
                    Name = "Klant Actief 44",
                    Email = "actief44@example.com",
                    Location = "Locatie 44",
                    Number = "0612345721",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 45,
                    Name = "Klant Actief 45",
                    Email = "actief45@example.com",
                    Location = "Locatie 45",
                    Number = "0612345722",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 46,
                    Name = "Klant Actief 46",
                    Email = "actief46@example.com",
                    Location = "Locatie 46",
                    Number = "0612345723",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 47,
                    Name = "Klant Actief 47",
                    Email = "actief47@example.com",
                    Location = "Locatie 47",
                    Number = "0612345724",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 48,
                    Name = "Klant Actief 48",
                    Email = "actief48@example.com",
                    Location = "Locatie 48",
                    Number = "0612345725",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 49,
                    Name = "Klant Actief 49",
                    Email = "actief49@example.com",
                    Location = "Locatie 49",
                    Number = "0612345726",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 50,
                    Name = "Klant Actief 50",
                    Email = "actief50@example.com",
                    Location = "Locatie 50",
                    Number = "0612345727",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 51,
                    Name = "Klant Actief 51",
                    Email = "actief51@example.com",
                    Location = "Locatie 51",
                    Number = "0612345728",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 52,
                    Name = "Klant Actief 52",
                    Email = "actief52@example.com",
                    Location = "Locatie 52",
                    Number = "0612345729",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 53,
                    Name = "Klant Actief 53",
                    Email = "actief53@example.com",
                    Location = "Locatie 53",
                    Number = "0612345730",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 54,
                    Name = "Klant Actief 54",
                    Email = "actief54@example.com",
                    Location = "Locatie 54",
                    Number = "0612345731",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 55,
                    Name = "Klant Actief 55",
                    Email = "actief55@example.com",
                    Location = "Locatie 55",
                    Number = "0612345732",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 56,
                    Name = "Klant Actief 56",
                    Email = "actief56@example.com",
                    Location = "Locatie 56",
                    Number = "0612345733",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 57,
                    Name = "Klant Actief 57",
                    Email = "actief57@example.com",
                    Location = "Locatie 57",
                    Number = "0612345734",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 58,
                    Name = "Klant Actief 58",
                    Email = "actief58@example.com",
                    Location = "Locatie 58",
                    Number = "0612345735",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 59,
                    Name = "Klant Actief 59",
                    Email = "actief59@example.com",
                    Location = "Locatie 59",
                    Number = "0612345736",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 60,
                    Name = "Klant Actief 60",
                    Email = "actief60@example.com",
                    Location = "Locatie 60",
                    Number = "0612345737",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 61,
                    Name = "Klant Actief 61",
                    Email = "actief61@example.com",
                    Location = "Locatie 61",
                    Number = "0612345738",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 62,
                    Name = "Klant Actief 62",
                    Email = "actief62@example.com",
                    Location = "Locatie 62",
                    Number = "0612345739",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 63,
                    Name = "Klant Actief 63",
                    Email = "actief63@example.com",
                    Location = "Locatie 63",
                    Number = "0612345740",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 64,
                    Name = "Klant Actief 64",
                    Email = "actief64@example.com",
                    Location = "Locatie 64",
                    Number = "0612345741",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 65,
                    Name = "Klant Actief 65",
                    Email = "actief65@example.com",
                    Location = "Locatie 65",
                    Number = "0612345742",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 66,
                    Name = "Klant Actief 66",
                    Email = "actief66@example.com",
                    Location = "Locatie 66",
                    Number = "0612345743",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 67,
                    Name = "Klant Actief 67",
                    Email = "actief67@example.com",
                    Location = "Locatie 67",
                    Number = "0612345744",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 68,
                    Name = "Klant Actief 68",
                    Email = "actief68@example.com",
                    Location = "Locatie 68",
                    Number = "0612345745",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 69,
                    Name = "Klant Actief 69",
                    Email = "actief69@example.com",
                    Location = "Locatie 69",
                    Number = "0612345746",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 70,
                    Name = "Klant Actief 70",
                    Email = "actief70@example.com",
                    Location = "Locatie 70",
                    Number = "0612345747",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 71,
                    Name = "Klant Actief 71",
                    Email = "actief71@example.com",
                    Location = "Locatie 71",
                    Number = "0612345748",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 72,
                    Name = "Klant Actief 72",
                    Email = "actief72@example.com",
                    Location = "Locatie 72",
                    Number = "0612345749",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 73,
                    Name = "Klant Actief 73",
                    Email = "actief73@example.com",
                    Location = "Locatie 73",
                    Number = "0612345750",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 74,
                    Name = "Klant Actief 74",
                    Email = "actief74@example.com",
                    Location = "Locatie 74",
                    Number = "0612345751",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 75,
                    Name = "Klant Actief 75",
                    Email = "actief75@example.com",
                    Location = "Locatie 75",
                    Number = "0612345752",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 76,
                    Name = "Klant Actief 76",
                    Email = "actief76@example.com",
                    Location = "Locatie 76",
                    Number = "0612345753",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 77,
                    Name = "Klant Actief 77",
                    Email = "actief77@example.com",
                    Location = "Locatie 77",
                    Number = "0612345754",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 78,
                    Name = "Klant Actief 78",
                    Email = "actief78@example.com",
                    Location = "Locatie 78",
                    Number = "0612345755",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 79,
                    Name = "Klant Actief 79",
                    Email = "actief79@example.com",
                    Location = "Locatie 79",
                    Number = "0612345756",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 80,
                    Name = "Klant Actief 80",
                    Email = "actief80@example.com",
                    Location = "Locatie 80",
                    Number = "0612345757",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 81,
                    Name = "Klant Actief 81",
                    Email = "actief81@example.com",
                    Location = "Locatie 81",
                    Number = "0612345758",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 82,
                    Name = "Klant Actief 82",
                    Email = "actief82@example.com",
                    Location = "Locatie 82",
                    Number = "0612345759",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 83,
                    Name = "Klant Actief 83",
                    Email = "actief83@example.com",
                    Location = "Locatie 83",
                    Number = "0612345760",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 84,
                    Name = "Klant Actief 84",
                    Email = "actief84@example.com",
                    Location = "Locatie 84",
                    Number = "0612345761",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 85,
                    Name = "Klant Actief 85",
                    Email = "actief85@example.com",
                    Location = "Locatie 85",
                    Number = "0612345762",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 86,
                    Name = "Klant Actief 86",
                    Email = "actief86@example.com",
                    Location = "Locatie 86",
                    Number = "0612345763",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 87,
                    Name = "Klant Actief 87",
                    Email = "actief87@example.com",
                    Location = "Locatie 87",
                    Number = "0612345764",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 88,
                    Name = "Klant Actief 88",
                    Email = "actief88@example.com",
                    Location = "Locatie 88",
                    Number = "0612345765",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 89,
                    Name = "Klant Actief 89",
                    Email = "actief89@example.com",
                    Location = "Locatie 89",
                    Number = "0612345766",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 90,
                    Name = "Klant Actief 90",
                    Email = "actief90@example.com",
                    Location = "Locatie 90",
                    Number = "0612345767",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 91,
                    Name = "Klant Actief 91",
                    Email = "actief91@example.com",
                    Location = "Locatie 91",
                    Number = "0612345768",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 92,
                    Name = "Klant Actief 92",
                    Email = "actief92@example.com",
                    Location = "Locatie 92",
                    Number = "0612345769",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 93,
                    Name = "Klant Actief 93",
                    Email = "actief93@example.com",
                    Location = "Locatie 93",
                    Number = "0612345770",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 94,
                    Name = "Klant Actief 94",
                    Email = "actief94@example.com",
                    Location = "Locatie 94",
                    Number = "0612345771",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 95,
                    Name = "Klant Actief 95",
                    Email = "actief95@example.com",
                    Location = "Locatie 95",
                    Number = "0612345772",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 96,
                    Name = "Klant Actief 96",
                    Email = "actief96@example.com",
                    Location = "Locatie 96",
                    Number = "0612345773",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 97,
                    Name = "Klant Actief 97",
                    Email = "actief97@example.com",
                    Location = "Locatie 97",
                    Number = "0612345774",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 98,
                    Name = "Klant Actief 98",
                    Email = "actief98@example.com",
                    Location = "Locatie 98",
                    Number = "0612345775",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 99,
                    Name = "Klant Actief 99",
                    Email = "actief99@example.com",
                    Location = "Locatie 99",
                    Number = "0612345776",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 100,
                    Name = "Klant Actief 100",
                    Email = "actief100@example.com",
                    Location = "Locatie 100",
                    Number = "0612345777",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 101,
                    Name = "Klant Actief 101",
                    Email = "actief101@example.com",
                    Location = "Locatie 101",
                    Number = "0612345778",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 102,
                    Name = "Klant Actief 102",
                    Email = "actief102@example.com",
                    Location = "Locatie 102",
                    Number = "0612345779",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 103,
                    Name = "Klant Actief 103",
                    Email = "actief103@example.com",
                    Location = "Locatie 103",
                    Number = "0612345780",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 104,
                    Name = "Klant Actief 104",
                    Email = "actief104@example.com",
                    Location = "Locatie 104",
                    Number = "0612345781",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 105,
                    Name = "Klant Actief 105",
                    Email = "actief105@example.com",
                    Location = "Locatie 105",
                    Number = "0612345782",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 106,
                    Name = "Klant Actief 106",
                    Email = "actief106@example.com",
                    Location = "Locatie 106",
                    Number = "0612345783",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 107,
                    Name = "Klant Actief 107",
                    Email = "actief107@example.com",
                    Location = "Locatie 107",
                    Number = "0612345784",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 108,
                    Name = "Klant Actief 108",
                    Email = "actief108@example.com",
                    Location = "Locatie 108",
                    Number = "0612345785",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 109,
                    Name = "Klant Actief 109",
                    Email = "actief109@example.com",
                    Location = "Locatie 109",
                    Number = "0612345786",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 110,
                    Name = "Klant Actief 110",
                    Email = "actief110@example.com",
                    Location = "Locatie 110",
                    Number = "0612345787",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 111,
                    Name = "Klant Actief 111",
                    Email = "actief111@example.com",
                    Location = "Locatie 111",
                    Number = "0612345788",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 112,
                    Name = "Klant Actief 112",
                    Email = "actief112@example.com",
                    Location = "Locatie 112",
                    Number = "0612345789",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 113,
                    Name = "Klant Actief 113",
                    Email = "actief113@example.com",
                    Location = "Locatie 113",
                    Number = "0612345790",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 114,
                    Name = "Klant Actief 114",
                    Email = "actief114@example.com",
                    Location = "Locatie 114",
                    Number = "0612345791",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 115,
                    Name = "Klant Actief 115",
                    Email = "actief115@example.com",
                    Location = "Locatie 115",
                    Number = "0612345792",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 116,
                    Name = "Klant Actief 116",
                    Email = "actief116@example.com",
                    Location = "Locatie 116",
                    Number = "0612345793",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 117,
                    Name = "Klant Actief 117",
                    Email = "actief117@example.com",
                    Location = "Locatie 117",
                    Number = "0612345794",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 118,
                    Name = "Klant Actief 118",
                    Email = "actief118@example.com",
                    Location = "Locatie 118",
                    Number = "0612345795",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 119,
                    Name = "Klant Actief 119",
                    Email = "actief119@example.com",
                    Location = "Locatie 119",
                    Number = "0612345796",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 120,
                    Name = "Klant Actief 120",
                    Email = "actief120@example.com",
                    Location = "Locatie 120",
                    Number = "0612345797",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 121,
                    Name = "Klant Actief 121",
                    Email = "actief121@example.com",
                    Location = "Locatie 121",
                    Number = "0612345798",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 122,
                    Name = "Klant Actief 122",
                    Email = "actief122@example.com",
                    Location = "Locatie 122",
                    Number = "0612345799",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 123,
                    Name = "Klant Actief 123",
                    Email = "actief123@example.com",
                    Location = "Locatie 123",
                    Number = "0612345800",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 124,
                    Name = "Klant Actief 124",
                    Email = "actief124@example.com",
                    Location = "Locatie 124",
                    Number = "0612345801",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 125,
                    Name = "Klant Actief 125",
                    Email = "actief125@example.com",
                    Location = "Locatie 125",
                    Number = "0612345802",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 126,
                    Name = "Klant Actief 126",
                    Email = "actief126@example.com",
                    Location = "Locatie 126",
                    Number = "0612345803",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 127,
                    Name = "Klant Actief 127",
                    Email = "actief127@example.com",
                    Location = "Locatie 127",
                    Number = "0612345804",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 128,
                    Name = "Klant Actief 128",
                    Email = "actief128@example.com",
                    Location = "Locatie 128",
                    Number = "0612345805",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 129,
                    Name = "Klant Actief 129",
                    Email = "actief129@example.com",
                    Location = "Locatie 129",
                    Number = "0612345806",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 130,
                    Name = "Klant Actief 130",
                    Email = "actief130@example.com",
                    Location = "Locatie 130",
                    Number = "0612345807",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 131,
                    Name = "Klant Actief 131",
                    Email = "actief131@example.com",
                    Location = "Locatie 131",
                    Number = "0612345808",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 132,
                    Name = "Klant Actief 132",
                    Email = "actief132@example.com",
                    Location = "Locatie 132",
                    Number = "0612345809",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 133,
                    Name = "Klant Actief 133",
                    Email = "actief133@example.com",
                    Location = "Locatie 133",
                    Number = "0612345810",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 134,
                    Name = "Klant Actief 134",
                    Email = "actief134@example.com",
                    Location = "Locatie 134",
                    Number = "0612345811",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 135,
                    Name = "Klant Actief 135",
                    Email = "actief135@example.com",
                    Location = "Locatie 135",
                    Number = "0612345812",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 136,
                    Name = "Klant Actief 136",
                    Email = "actief136@example.com",
                    Location = "Locatie 136",
                    Number = "0612345813",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 137,
                    Name = "Klant Actief 137",
                    Email = "actief137@example.com",
                    Location = "Locatie 137",
                    Number = "0612345814",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 138,
                    Name = "Klant Actief 138",
                    Email = "actief138@example.com",
                    Location = "Locatie 138",
                    Number = "0612345815",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 139,
                    Name = "Klant Actief 139",
                    Email = "actief139@example.com",
                    Location = "Locatie 139",
                    Number = "0612345816",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 140,
                    Name = "Klant Actief 140",
                    Email = "actief140@example.com",
                    Location = "Locatie 140",
                    Number = "0612345817",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 141,
                    Name = "Klant Actief 141",
                    Email = "actief141@example.com",
                    Location = "Locatie 141",
                    Number = "0612345818",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 142,
                    Name = "Klant Actief 142",
                    Email = "actief142@example.com",
                    Location = "Locatie 142",
                    Number = "0612345819",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 143,
                    Name = "Klant Actief 143",
                    Email = "actief143@example.com",
                    Location = "Locatie 143",
                    Number = "0612345820",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 144,
                    Name = "Klant Actief 144",
                    Email = "actief144@example.com",
                    Location = "Locatie 144",
                    Number = "0612345821",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 145,
                    Name = "Klant Actief 145",
                    Email = "actief145@example.com",
                    Location = "Locatie 145",
                    Number = "0612345822",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 146,
                    Name = "Klant Actief 146",
                    Email = "actief146@example.com",
                    Location = "Locatie 146",
                    Number = "0612345823",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 147,
                    Name = "Klant Actief 147",
                    Email = "actief147@example.com",
                    Location = "Locatie 147",
                    Number = "0612345824",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 148,
                    Name = "Klant Actief 148",
                    Email = "actief148@example.com",
                    Location = "Locatie 148",
                    Number = "0612345825",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 149,
                    Name = "Klant Actief 149",
                    Email = "actief149@example.com",
                    Location = "Locatie 149",
                    Number = "0612345826",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 150,
                    Name = "Klant Actief 150",
                    Email = "actief150@example.com",
                    Location = "Locatie 150",
                    Number = "0612345827",
                    BkrRegistered = false
                }, */
                new Customer
                {
                    Id = 151,
                    Name = "Klant Inactief 1",
                    Email = "inactief1@example.com",
                    Location = "Locatie 151",
                    Number = "0612345688",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 152,
                    Name = "Klant Inactief 2",
                    Email = "inactief2@example.com",
                    Location = "Locatie 152",
                    Number = "0612345689",
                    BkrRegistered = true
                },
                new Customer
                {
                    Id = 153,
                    Name = "Klant Inactief 3",
                    Email = "inactief3@example.com",
                    Location = "Locatie 153",
                    Number = "0612345690",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 154,
                    Name = "Klant Inactief 4",
                    Email = "inactief4@example.com",
                    Location = "Locatie 154",
                    Number = "0612345691",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 155,
                    Name = "Klant Inactief 5",
                    Email = "inactief5@example.com",
                    Location = "Locatie 155",
                    Number = "0612345692",
                    BkrRegistered = false
                }
                /*new Customer
                {
                    Id = 156,
                    Name = "Klant Inactief 6",
                    Email = "inactief6@example.com",
                    Location = "Locatie 156",
                    Number = "0612345833",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 157,
                    Name = "Klant Inactief 7",
                    Email = "inactief7@example.com",
                    Location = "Locatie 157",
                    Number = "0612345834",
                    BkrRegistered = true
                },
                new Customer
                {
                    Id = 158,
                    Name = "Klant Inactief 8",
                    Email = "inactief8@example.com",
                    Location = "Locatie 158",
                    Number = "0612345835",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 159,
                    Name = "Klant Inactief 9",
                    Email = "inactief9@example.com",
                    Location = "Locatie 159",
                    Number = "0612345836",
                    BkrRegistered = true
                },
                new Customer
                {
                    Id = 160,
                    Name = "Klant Inactief 10",
                    Email = "inactief10@example.com",
                    Location = "Locatie 160",
                    Number = "0612345837",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 161,
                    Name = "Klant Inactief 11",
                    Email = "inactief11@example.com",
                    Location = "Locatie 161",
                    Number = "0612345838",
                    BkrRegistered = true
                },
                new Customer
                {
                    Id = 162,
                    Name = "Klant Inactief 12",
                    Email = "inactief12@example.com",
                    Location = "Locatie 162",
                    Number = "0612345839",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 163,
                    Name = "Klant Inactief 13",
                    Email = "inactief13@example.com",
                    Location = "Locatie 163",
                    Number = "0612345840",
                    BkrRegistered = true
                },
                new Customer
                {
                    Id = 164,
                    Name = "Klant Inactief 14",
                    Email = "inactief14@example.com",
                    Location = "Locatie 164",
                    Number = "0612345841",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 165,
                    Name = "Klant Inactief 15",
                    Email = "inactief15@example.com",
                    Location = "Locatie 165",
                    Number = "0612345842",
                    BkrRegistered = true
                },
                new Customer
                {
                    Id = 166,
                    Name = "Klant Inactief 16",
                    Email = "inactief16@example.com",
                    Location = "Locatie 166",
                    Number = "0612345843",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 167,
                    Name = "Klant Inactief 17",
                    Email = "inactief17@example.com",
                    Location = "Locatie 167",
                    Number = "0612345844",
                    BkrRegistered = true
                },
                new Customer
                {
                    Id = 168,
                    Name = "Klant Inactief 18",
                    Email = "inactief18@example.com",
                    Location = "Locatie 168",
                    Number = "0612345845",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 169,
                    Name = "Klant Inactief 19",
                    Email = "inactief19@example.com",
                    Location = "Locatie 169",
                    Number = "0612345846",
                    BkrRegistered = true
                },
                new Customer
                {
                    Id = 170,
                    Name = "Klant Inactief 20",
                    Email = "inactief20@example.com",
                    Location = "Locatie 170",
                    Number = "0612345847",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 171,
                    Name = "Klant Inactief 21",
                    Email = "inactief21@example.com",
                    Location = "Locatie 171",
                    Number = "0612345848",
                    BkrRegistered = true
                },
                new Customer
                {
                    Id = 172,
                    Name = "Klant Inactief 22",
                    Email = "inactief22@example.com",
                    Location = "Locatie 172",
                    Number = "0612345849",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 173,
                    Name = "Klant Inactief 23",
                    Email = "inactief23@example.com",
                    Location = "Locatie 173",
                    Number = "0612345850",
                    BkrRegistered = true
                },
                new Customer
                {
                    Id = 174,
                    Name = "Klant Inactief 24",
                    Email = "inactief24@example.com",
                    Location = "Locatie 174",
                    Number = "0612345851",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 175,
                    Name = "Klant Inactief 25",
                    Email = "inactief25@example.com",
                    Location = "Locatie 175",
                    Number = "0612345852",
                    BkrRegistered = true
                },
                new Customer
                {
                    Id = 176,
                    Name = "Klant Inactief 26",
                    Email = "inactief26@example.com",
                    Location = "Locatie 176",
                    Number = "0612345853",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 177,
                    Name = "Klant Inactief 27",
                    Email = "inactief27@example.com",
                    Location = "Locatie 177",
                    Number = "0612345854",
                    BkrRegistered = true
                },
                new Customer
                {
                    Id = 178,
                    Name = "Klant Inactief 28",
                    Email = "inactief28@example.com",
                    Location = "Locatie 178",
                    Number = "0612345855",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 179,
                    Name = "Klant Inactief 29",
                    Email = "inactief29@example.com",
                    Location = "Locatie 179",
                    Number = "0612345856",
                    BkrRegistered = true
                },
                new Customer
                {
                    Id = 180,
                    Name = "Klant Inactief 30",
                    Email = "inactief30@example.com",
                    Location = "Locatie 180",
                    Number = "0612345857",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 181,
                    Name = "Klant Inactief 31",
                    Email = "inactief31@example.com",
                    Location = "Locatie 181",
                    Number = "0612345858",
                    BkrRegistered = true
                },
                new Customer
                {
                    Id = 182,
                    Name = "Klant Inactief 32",
                    Email = "inactief32@example.com",
                    Location = "Locatie 182",
                    Number = "0612345859",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 183,
                    Name = "Klant Inactief 33",
                    Email = "inactief33@example.com",
                    Location = "Locatie 183",
                    Number = "0612345860",
                    BkrRegistered = true
                },
                new Customer
                {
                    Id = 184,
                    Name = "Klant Inactief 34",
                    Email = "inactief34@example.com",
                    Location = "Locatie 184",
                    Number = "0612345861",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 185,
                    Name = "Klant Inactief 35",
                    Email = "inactief35@example.com",
                    Location = "Locatie 185",
                    Number = "0612345862",
                    BkrRegistered = true
                },
                new Customer
                {
                    Id = 186,
                    Name = "Klant Inactief 36",
                    Email = "inactief36@example.com",
                    Location = "Locatie 186",
                    Number = "0612345863",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 187,
                    Name = "Klant Inactief 37",
                    Email = "inactief37@example.com",
                    Location = "Locatie 187",
                    Number = "0612345864",
                    BkrRegistered = true
                },
                new Customer
                {
                    Id = 188,
                    Name = "Klant Inactief 38",
                    Email = "inactief38@example.com",
                    Location = "Locatie 188",
                    Number = "0612345865",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 189,
                    Name = "Klant Inactief 39",
                    Email = "inactief39@example.com",
                    Location = "Locatie 189",
                    Number = "0612345866",
                    BkrRegistered = true
                },
                new Customer
                {
                    Id = 190,
                    Name = "Klant Inactief 40",
                    Email = "inactief40@example.com",
                    Location = "Locatie 190",
                    Number = "0612345867",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 191,
                    Name = "Klant Inactief 41",
                    Email = "inactief41@example.com",
                    Location = "Locatie 191",
                    Number = "0612345868",
                    BkrRegistered = true
                },
                new Customer
                {
                    Id = 192,
                    Name = "Klant Inactief 42",
                    Email = "inactief42@example.com",
                    Location = "Locatie 192",
                    Number = "0612345869",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 193,
                    Name = "Klant Inactief 43",
                    Email = "inactief43@example.com",
                    Location = "Locatie 193",
                    Number = "0612345870",
                    BkrRegistered = true
                },
                new Customer
                {
                    Id = 194,
                    Name = "Klant Inactief 44",
                    Email = "inactief44@example.com",
                    Location = "Locatie 194",
                    Number = "0612345871",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 195,
                    Name = "Klant Inactief 45",
                    Email = "inactief45@example.com",
                    Location = "Locatie 195",
                    Number = "0612345872",
                    BkrRegistered = true
                },
                new Customer
                {
                    Id = 196,
                    Name = "Klant Inactief 46",
                    Email = "inactief46@example.com",
                    Location = "Locatie 196",
                    Number = "0612345873",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 197,
                    Name = "Klant Inactief 47",
                    Email = "inactief47@example.com",
                    Location = "Locatie 197",
                    Number = "0612345874",
                    BkrRegistered = true
                },
                new Customer
                {
                    Id = 198,
                    Name = "Klant Inactief 48",
                    Email = "inactief48@example.com",
                    Location = "Locatie 198",
                    Number = "0612345875",
                    BkrRegistered = false
                },
                new Customer
                {
                    Id = 199,
                    Name = "Klant Inactief 49",
                    Email = "inactief49@example.com",
                    Location = "Locatie 199",
                    Number = "0612345876",
                    BkrRegistered = true
                },
                new Customer
                {
                    Id = 200,
                    Name = "Klant Inactief 50",
                    Email = "inactief50@example.com",
                    Location = "Locatie 200",
                    Number = "0612345877",
                    BkrRegistered = false
                } */
            );

            modelBuilder.Entity<Part>().HasData(
                new Part
                {
                    Id = 1,
                    Name = "Rubber 10 mm",
                    Description = "",
                    Price = 0.39m,
                    BrandId = 1
                },
                new Part
                {
                    Id = 2,
                    Name = "Rubber 14 mm",
                    Description = "",
                    Price = 0.45m,
                    BrandId = 1
                },
                new Part
                {
                    Id = 3,
                    Name = "Slang",
                    Description = "",
                    Price = 4.45m,
                    BrandId = 1
                },
                new Part
                {
                    Id = 4,
                    Name = "Voeding (elektra)",
                    Description = "",
                    Price = 68.69m,
                    BrandId = 1
                },
                new Part
                {
                    Id = 5,
                    Name = "Ontkalker",
                    Description = "",
                    Price = 4.00m,
                    BrandId = 1
                },
                new Part
                {
                    Id = 6,
                    Name = "Waterfilter",
                    Description = "",
                    Price = 299.45m,
                    BrandId = 1
                },
                new Part
                {
                    Id = 7,
                    Name = "Reservoir sensor",
                    Description = "",
                    Price = 89.99m,
                    BrandId = 1
                },
                new Part
                {
                    Id = 8,
                    Name = "Druppelstop",
                    Description = "",
                    Price = 122.43m,
                    BrandId = 1
                },
                new Part
                {
                    Id = 9,
                    Name = "Electrische pomp",
                    Description = "",
                    Price = 478.59m,
                    BrandId = 1
                },
                new Part
                {
                    Id = 10,
                    Name = "Tandwiel 110mm",
                    Description = "",
                    Price = 5.45m,
                    BrandId = 1
                },
                new Part
                {
                    Id = 11,
                    Name = "Tandwiel 70mm",
                    Description = "",
                    Price = 5.25m,
                    BrandId = 1
                },
                new Part
                {
                    Id = 12,
                    Name = "Maalmotor",
                    Description = "",
                    Price = 119.20m,
                    BrandId = 1
                },
                new Part
                {
                    Id = 13,
                    Name = "Zeef",
                    Description = "",
                    Price = 28.80m,
                    BrandId = 1
                },
                new Part
                {
                    Id = 14,
                    Name = "Reinigingstabletten",
                    Description = "",
                    Price = 3.45m,
                    BrandId = 1
                },
                new Part
                {
                    Id = 15,
                    Name = "Reinigingsborsteltjes",
                    Description = "",
                    Price = 8.45m,
                    BrandId = 1
                },
                new Part
                {
                    Id = 16,
                    Name = "Ontkalkingspijp",
                    Description = "",
                    Price = 21.70m,
                    BrandId = 1
                }
            );

            modelBuilder.Entity<Storage>().HasData(
                new Storage
                {
                    Id = 1,
                    ProductId = 1,
                    BeanId = null,
                    PartId = null,
                    Amount = 10
                },
                new Storage
                {
                    Id = 2,
                    ProductId = 2,
                    BeanId = null,
                    PartId = null,
                    Amount = 5
                },
                new Storage
                {
                    Id = 3,
                    ProductId = 3,
                    BeanId = null,
                    PartId = null,
                    Amount = 20
                },
                new Storage
                {
                    Id = 4,
                    ProductId = 4,
                    BeanId = null,
                    PartId = null,
                    Amount = 15
                },
                new Storage
                {
                    Id = 5,
                    ProductId = null,
                    BeanId = 1,
                    PartId = null,
                    Amount = 10
                },
                new Storage
                {
                    Id = 6,
                    ProductId = null,
                    BeanId = 2,
                    PartId = null,
                    Amount = 15
                },
                new Storage
                {
                    Id = 7,
                    ProductId = null,
                    BeanId = 3,
                    PartId = null,
                    Amount = 20
                },
                new Storage
                {
                    Id = 8,
                    ProductId = null,
                    BeanId = 4,
                    PartId = null,
                    Amount = 25
                },
                new Storage
                {
                    Id = 9,
                    ProductId = null,
                    BeanId = null,
                    PartId = 1,
                    Amount = 10
                },
                new Storage
                {
                    Id = 10,
                    ProductId = null,
                    BeanId = null,
                    PartId = 2,
                    Amount = 15
                },
                new Storage
                {
                    Id = 11,
                    ProductId = null,
                    BeanId = null,
                    PartId = 3,
                    Amount = 20
                },
                new Storage
                {
                    Id = 12,
                    ProductId = null,
                    BeanId = null,
                    PartId = 4,
                    Amount = 25
                },
                new Storage
                {
                    Id = 13,
                    ProductId = null,
                    BeanId = null,
                    PartId = 5,
                    Amount = 30
                },
                new Storage
                {
                    Id = 14,
                    ProductId = null,
                    BeanId = null,
                    PartId = 6,
                    Amount = 5
                },
                new Storage
                {
                    Id = 15,
                    ProductId = null,
                    BeanId = null,
                    PartId = 7,
                    Amount = 12
                },
                new Storage
                {
                    Id = 16,
                    ProductId = null,
                    BeanId = null,
                    PartId = 8,
                    Amount = 8
                },
                new Storage
                {
                    Id = 17,
                    ProductId = null,
                    BeanId = null,
                    PartId = 9,
                    Amount = 18
                },
                new Storage
                {
                    Id = 18,
                    ProductId = null,
                    BeanId = null,
                    PartId = 10,
                    Amount = 22
                },
                new Storage
                {
                    Id = 19,
                    ProductId = null,
                    BeanId = null,
                    PartId = 11,
                    Amount = 10
                },
                new Storage
                {
                    Id = 20,
                    ProductId = null,
                    BeanId = null,
                    PartId = 12,
                    Amount = 15
                },
                new Storage
                {
                    Id = 21,
                    ProductId = null,
                    BeanId = null,
                    PartId = 13,
                    Amount = 20
                },
                new Storage
                {
                    Id = 22,
                    ProductId = null,
                    BeanId = null,
                    PartId = 14,
                    Amount = 25
                },
                new Storage
                {
                    Id = 23,
                    ProductId = null,
                    BeanId = null,
                    PartId = 15,
                    Amount = 30
                },
                new Storage
                {
                    Id = 24,
                    ProductId = null,
                    BeanId = null,
                    PartId = 16,
                    Amount = 35
                }
            );

            modelBuilder.Entity<Contract>().HasData(
                new Contract
                {
                    Id = 1,
                    CustomerId = 1,
                    ProductId = 1,
                    BeanId = 1,
                    StartDate = new DateOnly(2024, 1, 1),
                    EndDate = new DateOnly(2025, 1, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 10, 1)
                },
                new Contract
                {
                    Id = 2,
                    CustomerId = 2,
                    ProductId = 2,
                    BeanId = 2,
                    StartDate = new DateOnly(2024, 2, 1),
                    EndDate = new DateOnly(2025, 2, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 10, 2)
                },
                new Contract
                {
                    Id = 3,
                    CustomerId = 3,
                    ProductId = 3,
                    BeanId = null,
                    StartDate = new DateOnly(2024, 3, 1),
                    EndDate = new DateOnly(2025, 3, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 10, 3)
                },
                new Contract
                {
                    Id = 4,
                    CustomerId = 4,
                    ProductId = 4,
                    BeanId = 3,
                    StartDate = new DateOnly(2024, 4, 1),
                    EndDate = new DateOnly(2025, 4, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 10, 4)
                }
                /*new Contract
                {
                    Id = 5,
                    CustomerId = 5,
                    ProductId = 1,
                    BeanId = 1,
                    StartDate = new DateOnly(2024, 5, 1),
                    EndDate = new DateOnly(2025, 5, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 10, 5)
                },
                new Contract
                {
                    Id = 6,
                    CustomerId = 6,
                    ProductId = 2,
                    BeanId = 2,
                    StartDate = new DateOnly(2024, 6, 1),
                    EndDate = new DateOnly(2025, 6, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 10, 6)
                },
                new Contract
                {
                    Id = 7,
                    CustomerId = 7,
                    ProductId = 3,
                    BeanId = 3,
                    StartDate = new DateOnly(2024, 7, 1),
                    EndDate = new DateOnly(2025, 7, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 10, 7)
                },
                new Contract
                {
                    Id = 8,
                    CustomerId = 8,
                    ProductId = 4,
                    BeanId = 1,
                    StartDate = new DateOnly(2024, 8, 1),
                    EndDate = new DateOnly(2025, 8, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 10, 8)
                },
                new Contract
                {
                    Id = 9,
                    CustomerId = 9,
                    ProductId = 1,
                    BeanId = 2,
                    StartDate = new DateOnly(2024, 9, 1),
                    EndDate = new DateOnly(2025, 9, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 10, 9)
                },
                new Contract
                {
                    Id = 10,
                    CustomerId = 10,
                    ProductId = 2,
                    BeanId = 3,
                    StartDate = new DateOnly(2024, 10, 1),
                    EndDate = new DateOnly(2025, 10, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 10, 10)
                },
                new Contract
                {
                    Id = 11,
                    CustomerId = 11,
                    ProductId = 1,
                    BeanId = 1,
                    StartDate = new DateOnly(2024, 11, 1),
                    EndDate = new DateOnly(2025, 11, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 10, 11)
                },
                new Contract
                {
                    Id = 12,
                    CustomerId = 12,
                    ProductId = 2,
                    BeanId = 2,
                    StartDate = new DateOnly(2024, 12, 1),
                    EndDate = new DateOnly(2025, 12, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 10, 12)
                },
                new Contract
                {
                    Id = 13,
                    CustomerId = 13,
                    ProductId = 3,
                    BeanId = 3,
                    StartDate = new DateOnly(2025, 1, 1),
                    EndDate = new DateOnly(2026, 1, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 10, 13)
                },
                new Contract
                {
                    Id = 14,
                    CustomerId = 14,
                    ProductId = 4,
                    BeanId = 1,
                    StartDate = new DateOnly(2025, 2, 1),
                    EndDate = new DateOnly(2026, 2, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 10, 14)
                },
                new Contract
                {
                    Id = 15,
                    CustomerId = 15,
                    ProductId = 1,
                    BeanId = 2,
                    StartDate = new DateOnly(2025, 3, 1),
                    EndDate = new DateOnly(2026, 3, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 10, 15)
                },
                new Contract
                {
                    Id = 16,
                    CustomerId = 16,
                    ProductId = 2,
                    BeanId = 3,
                    StartDate = new DateOnly(2025, 4, 1),
                    EndDate = new DateOnly(2026, 4, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 10, 16)
                },
                new Contract
                {
                    Id = 17,
                    CustomerId = 17,
                    ProductId = 3,
                    BeanId = 4,
                    StartDate = new DateOnly(2025, 5, 1),
                    EndDate = new DateOnly(2026, 5, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 10, 17)
                },
                new Contract
                {
                    Id = 18,
                    CustomerId = 18,
                    ProductId = 4,
                    BeanId = 1,
                    StartDate = new DateOnly(2025, 6, 1),
                    EndDate = new DateOnly(2026, 6, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 10, 18)
                },
                new Contract
                {
                    Id = 19,
                    CustomerId = 19,
                    ProductId = 1,
                    BeanId = 2,
                    StartDate = new DateOnly(2025, 7, 1),
                    EndDate = new DateOnly(2026, 7, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 10, 19)
                },
                new Contract
                {
                    Id = 20,
                    CustomerId = 20,
                    ProductId = 2,
                    BeanId = 3,
                    StartDate = new DateOnly(2025, 8, 1),
                    EndDate = new DateOnly(2026, 8, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 10, 20)
                },
                new Contract
                {
                    Id = 21,
                    CustomerId = 21,
                    ProductId = 1,
                    BeanId = 1,
                    StartDate = new DateOnly(2025, 9, 1),
                    EndDate = new DateOnly(2026, 9, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 10, 21)
                },
                new Contract
                {
                    Id = 22,
                    CustomerId = 22,
                    ProductId = 2,
                    BeanId = 2,
                    StartDate = new DateOnly(2025, 10, 1),
                    EndDate = new DateOnly(2026, 10, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 10, 22)
                },
                new Contract
                {
                    Id = 23,
                    CustomerId = 23,
                    ProductId = 3,
                    BeanId = 3,
                    StartDate = new DateOnly(2025, 11, 1),
                    EndDate = new DateOnly(2026, 11, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 10, 23)
                },
                new Contract
                {
                    Id = 24,
                    CustomerId = 24,
                    ProductId = 4,
                    BeanId = 1,
                    StartDate = new DateOnly(2025, 12, 1),
                    EndDate = new DateOnly(2026, 12, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 10, 24)
                },
                new Contract
                {
                    Id = 25,
                    CustomerId = 25,
                    ProductId = 1,
                    BeanId = 2,
                    StartDate = new DateOnly(2026, 1, 1),
                    EndDate = new DateOnly(2027, 1, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 10, 25)
                },
                new Contract
                {
                    Id = 26,
                    CustomerId = 26,
                    ProductId = 2,
                    BeanId = 3,
                    StartDate = new DateOnly(2026, 2, 1),
                    EndDate = new DateOnly(2027, 2, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 10, 26)
                },
                new Contract
                {
                    Id = 27,
                    CustomerId = 27,
                    ProductId = 3,
                    BeanId = 4,
                    StartDate = new DateOnly(2026, 3, 1),
                    EndDate = new DateOnly(2027, 3, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 10, 27)
                },
                new Contract
                {
                    Id = 28,
                    CustomerId = 28,
                    ProductId = 4,
                    BeanId = 1,
                    StartDate = new DateOnly(2026, 4, 1),
                    EndDate = new DateOnly(2027, 4, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 10, 28)
                },
                new Contract
                {
                    Id = 29,
                    CustomerId = 29,
                    ProductId = 1,
                    BeanId = 2,
                    StartDate = new DateOnly(2026, 5, 1),
                    EndDate = new DateOnly(2027, 5, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 10, 29)
                },
                new Contract
                {
                    Id = 30,
                    CustomerId = 30,
                    ProductId = 2,
                    BeanId = 3,
                    StartDate = new DateOnly(2026, 6, 1),
                    EndDate = new DateOnly(2027, 6, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 10, 30)
                },
                new Contract
                {
                    Id = 31,
                    CustomerId = 31,
                    ProductId = 3,
                    BeanId = 4,
                    StartDate = new DateOnly(2026, 7, 1),
                    EndDate = new DateOnly(2027, 7, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 10, 31)
                },
                new Contract
                {
                    Id = 32,
                    CustomerId = 32,
                    ProductId = 4,
                    BeanId = 1,
                    StartDate = new DateOnly(2026, 8, 1),
                    EndDate = new DateOnly(2027, 8, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 11, 1)
                },
                new Contract
                {
                    Id = 33,
                    CustomerId = 33,
                    ProductId = 1,
                    BeanId = 2,
                    StartDate = new DateOnly(2026, 9, 1),
                    EndDate = new DateOnly(2027, 9, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 11, 2)
                },
                new Contract
                {
                    Id = 34,
                    CustomerId = 34,
                    ProductId = 2,
                    BeanId = 3,
                    StartDate = new DateOnly(2026, 10, 1),
                    EndDate = new DateOnly(2027, 10, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 11, 3)
                },
                new Contract
                {
                    Id = 35,
                    CustomerId = 35,
                    ProductId = 3,
                    BeanId = 4,
                    StartDate = new DateOnly(2026, 11, 1),
                    EndDate = new DateOnly(2027, 11, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 11, 4)
                },
                new Contract
                {
                    Id = 36,
                    CustomerId = 36,
                    ProductId = 4,
                    BeanId = 1,
                    StartDate = new DateOnly(2026, 12, 1),
                    EndDate = new DateOnly(2027, 12, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 11, 5)
                },
                new Contract
                {
                    Id = 37,
                    CustomerId = 37,
                    ProductId = 1,
                    BeanId = 2,
                    StartDate = new DateOnly(2027, 1, 1),
                    EndDate = new DateOnly(2028, 1, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 11, 6)
                },
                new Contract
                {
                    Id = 38,
                    CustomerId = 38,
                    ProductId = 2,
                    BeanId = 3,
                    StartDate = new DateOnly(2027, 2, 1),
                    EndDate = new DateOnly(2028, 2, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 11, 7)
                },
                new Contract
                {
                    Id = 39,
                    CustomerId = 39,
                    ProductId = 3,
                    BeanId = 4,
                    StartDate = new DateOnly(2027, 3, 1),
                    EndDate = new DateOnly(2028, 3, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 11, 8)
                },
                new Contract
                {
                    Id = 40,
                    CustomerId = 40,
                    ProductId = 4,
                    BeanId = 1,
                    StartDate = new DateOnly(2027, 4, 1),
                    EndDate = new DateOnly(2028, 4, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 11, 9)
                },
                new Contract
                {
                    Id = 41,
                    CustomerId = 41,
                    ProductId = 1,
                    BeanId = 1,
                    StartDate = new DateOnly(2027, 5, 1),
                    EndDate = new DateOnly(2028, 5, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 11, 10)
                },
                new Contract
                {
                    Id = 42,
                    CustomerId = 42,
                    ProductId = 2,
                    BeanId = 2,
                    StartDate = new DateOnly(2027, 6, 1),
                    EndDate = new DateOnly(2028, 6, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 11, 11)
                },
                new Contract
                {
                    Id = 43,
                    CustomerId = 43,
                    ProductId = 3,
                    BeanId = 3,
                    StartDate = new DateOnly(2027, 7, 1),
                    EndDate = new DateOnly(2028, 7, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 11, 12)
                },
                new Contract
                {
                    Id = 44,
                    CustomerId = 44,
                    ProductId = 4,
                    BeanId = 1,
                    StartDate = new DateOnly(2027, 8, 1),
                    EndDate = new DateOnly(2028, 8, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 11, 13)
                },
                new Contract
                {
                    Id = 45,
                    CustomerId = 45,
                    ProductId = 1,
                    BeanId = 2,
                    StartDate = new DateOnly(2027, 9, 1),
                    EndDate = new DateOnly(2028, 9, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 11, 14)
                },
                new Contract
                {
                    Id = 46,
                    CustomerId = 46,
                    ProductId = 2,
                    BeanId = 3,
                    StartDate = new DateOnly(2027, 10, 1),
                    EndDate = new DateOnly(2028, 10, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 11, 15)
                },
                new Contract
                {
                    Id = 47,
                    CustomerId = 47,
                    ProductId = 3,
                    BeanId = 4,
                    StartDate = new DateOnly(2027, 11, 1),
                    EndDate = new DateOnly(2028, 11, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 11, 16)
                },
                new Contract
                {
                    Id = 48,
                    CustomerId = 48,
                    ProductId = 4,
                    BeanId = 1,
                    StartDate = new DateOnly(2027, 12, 1),
                    EndDate = new DateOnly(2028, 12, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 11, 17)
                },
                new Contract
                {
                    Id = 49,
                    CustomerId = 49,
                    ProductId = 1,
                    BeanId = 2,
                    StartDate = new DateOnly(2028, 1, 1),
                    EndDate = new DateOnly(2029, 1, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 11, 18)
                },
                new Contract
                {
                    Id = 50,
                    CustomerId = 50,
                    ProductId = 2,
                    BeanId = 3,
                    StartDate = new DateOnly(2028, 2, 1),
                    EndDate = new DateOnly(2029, 2, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 11, 19)
                },
                new Contract
                {
                    Id = 51,
                    CustomerId = 51,
                    ProductId = 3,
                    BeanId = 4,
                    StartDate = new DateOnly(2028, 3, 1),
                    EndDate = new DateOnly(2029, 3, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 11, 20)
                },
                new Contract
                {
                    Id = 52,
                    CustomerId = 52,
                    ProductId = 4,
                    BeanId = 1,
                    StartDate = new DateOnly(2028, 4, 1),
                    EndDate = new DateOnly(2029, 4, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 11, 21)
                },
                new Contract
                {
                    Id = 53,
                    CustomerId = 53,
                    ProductId = 1,
                    BeanId = 2,
                    StartDate = new DateOnly(2028, 5, 1),
                    EndDate = new DateOnly(2029, 5, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 11, 22)
                },
                new Contract
                {
                    Id = 54,
                    CustomerId = 54,
                    ProductId = 2,
                    BeanId = 3,
                    StartDate = new DateOnly(2028, 6, 1),
                    EndDate = new DateOnly(2029, 6, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 11, 23)
                },
                new Contract
                {
                    Id = 55,
                    CustomerId = 55,
                    ProductId = 3,
                    BeanId = 4,
                    StartDate = new DateOnly(2028, 7, 1),
                    EndDate = new DateOnly(2029, 7, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 11, 24)
                },
                new Contract
                {
                    Id = 56,
                    CustomerId = 56,
                    ProductId = 4,
                    BeanId = 1,
                    StartDate = new DateOnly(2028, 8, 1),
                    EndDate = new DateOnly(2029, 8, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 11, 25)
                },
                new Contract
                {
                    Id = 57,
                    CustomerId = 57,
                    ProductId = 1,
                    BeanId = 2,
                    StartDate = new DateOnly(2028, 9, 1),
                    EndDate = new DateOnly(2029, 9, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 11, 26)
                },
                new Contract
                {
                    Id = 58,
                    CustomerId = 58,
                    ProductId = 2,
                    BeanId = 3,
                    StartDate = new DateOnly(2028, 10, 1),
                    EndDate = new DateOnly(2029, 10, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 11, 27)
                },
                new Contract
                {
                    Id = 59,
                    CustomerId = 59,
                    ProductId = 3,
                    BeanId = 4,
                    StartDate = new DateOnly(2028, 11, 1),
                    EndDate = new DateOnly(2029, 11, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 11, 28)
                },
                new Contract
                {
                    Id = 60,
                    CustomerId = 60,
                    ProductId = 4,
                    BeanId = 1,
                    StartDate = new DateOnly(2028, 12, 1),
                    EndDate = new DateOnly(2029, 12, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 11, 29)
                },
                new Contract
                {
                    Id = 61,
                    CustomerId = 61,
                    ProductId = 1,
                    BeanId = 1,
                    StartDate = new DateOnly(2029, 1, 1),
                    EndDate = new DateOnly(2030, 1, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 11, 30)
                },
                new Contract
                {
                    Id = 62,
                    CustomerId = 62,
                    ProductId = 2,
                    BeanId = null,
                    StartDate = new DateOnly(2029, 2, 1),
                    EndDate = new DateOnly(2030, 2, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 12, 1)
                },
                new Contract
                {
                    Id = 63,
                    CustomerId = 63,
                    ProductId = 3,
                    BeanId = 3,
                    StartDate = new DateOnly(2029, 3, 1),
                    EndDate = new DateOnly(2030, 3, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 12, 2)
                },
                new Contract
                {
                    Id = 64,
                    CustomerId = 64,
                    ProductId = 4,
                    BeanId = null,
                    StartDate = new DateOnly(2029, 4, 1),
                    EndDate = new DateOnly(2030, 4, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 12, 3)
                },
                new Contract
                {
                    Id = 65,
                    CustomerId = 65,
                    ProductId = 1,
                    BeanId = 2,
                    StartDate = new DateOnly(2029, 5, 1),
                    EndDate = new DateOnly(2030, 5, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 12, 4)
                },
                new Contract
                {
                    Id = 66,
                    CustomerId = 66,
                    ProductId = 2,
                    BeanId = null,
                    StartDate = new DateOnly(2029, 6, 1),
                    EndDate = new DateOnly(2030, 6, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 12, 5)
                },
                new Contract
                {
                    Id = 67,
                    CustomerId = 67,
                    ProductId = 3,
                    BeanId = 3,
                    StartDate = new DateOnly(2029, 7, 1),
                    EndDate = new DateOnly(2030, 7, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 12, 6)
                },
                new Contract
                {
                    Id = 68,
                    CustomerId = 68,
                    ProductId = 4,
                    BeanId = null,
                    StartDate = new DateOnly(2029, 8, 1),
                    EndDate = new DateOnly(2030, 8, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 12, 7)
                },
                new Contract
                {
                    Id = 69,
                    CustomerId = 69,
                    ProductId = 1,
                    BeanId = 1,
                    StartDate = new DateOnly(2029, 9, 1),
                    EndDate = new DateOnly(2030, 9, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 12, 8)
                },
                new Contract
                {
                    Id = 70,
                    CustomerId = 70,
                    ProductId = 2,
                    BeanId = null,
                    StartDate = new DateOnly(2029, 10, 1),
                    EndDate = new DateOnly(2030, 10, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 12, 9)
                },
                new Contract
                {
                    Id = 71,
                    CustomerId = 71,
                    ProductId = 3,
                    BeanId = 4,
                    StartDate = new DateOnly(2029, 11, 1),
                    EndDate = new DateOnly(2030, 11, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 12, 10)
                },
                new Contract
                {
                    Id = 72,
                    CustomerId = 72,
                    ProductId = 4,
                    BeanId = null,
                    StartDate = new DateOnly(2029, 12, 1),
                    EndDate = new DateOnly(2030, 12, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 12, 11)
                },
                new Contract
                {
                    Id = 73,
                    CustomerId = 73,
                    ProductId = 1,
                    BeanId = 2,
                    StartDate = new DateOnly(2030, 1, 1),
                    EndDate = new DateOnly(2031, 1, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 12, 12)
                },
                new Contract
                {
                    Id = 74,
                    CustomerId = 74,
                    ProductId = 2,
                    BeanId = null,
                    StartDate = new DateOnly(2030, 2, 1),
                    EndDate = new DateOnly(2031, 2, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 12, 13)
                },
                new Contract
                {
                    Id = 75,
                    CustomerId = 75,
                    ProductId = 3,
                    BeanId = 3,
                    StartDate = new DateOnly(2030, 3, 1),
                    EndDate = new DateOnly(2031, 3, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 12, 14)
                },
                new Contract
                {
                    Id = 76,
                    CustomerId = 76,
                    ProductId = 4,
                    BeanId = null,
                    StartDate = new DateOnly(2030, 4, 1),
                    EndDate = new DateOnly(2031, 4, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 12, 15)
                },
                new Contract
                {
                    Id = 77,
                    CustomerId = 77,
                    ProductId = 1,
                    BeanId = 2,
                    StartDate = new DateOnly(2030, 5, 1),
                    EndDate = new DateOnly(2031, 5, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 12, 16)
                },
                new Contract
                {
                    Id = 78,
                    CustomerId = 78,
                    ProductId = 2,
                    BeanId = null,
                    StartDate = new DateOnly(2030, 6, 1),
                    EndDate = new DateOnly(2031, 6, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 12, 17)
                },
                new Contract
                {
                    Id = 79,
                    CustomerId = 79,
                    ProductId = 3,
                    BeanId = 4,
                    StartDate = new DateOnly(2030, 7, 1),
                    EndDate = new DateOnly(2031, 7, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 12, 18)
                },
                new Contract
                {
                    Id = 80,
                    CustomerId = 80,
                    ProductId = 4,
                    BeanId = null,
                    StartDate = new DateOnly(2030, 8, 1),
                    EndDate = new DateOnly(2031, 8, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 12, 19)
                },
                new Contract
                {
                    Id = 81,
                    CustomerId = 81,
                    ProductId = 1,
                    BeanId = 1,
                    StartDate = new DateOnly(2031, 1, 1),
                    EndDate = new DateOnly(2032, 1, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 12, 20)
                },
                new Contract
                {
                    Id = 82,
                    CustomerId = 82,
                    ProductId = 2,
                    BeanId = null,
                    StartDate = new DateOnly(2031, 2, 1),
                    EndDate = new DateOnly(2032, 2, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 12, 21)
                },
                new Contract
                {
                    Id = 83,
                    CustomerId = 83,
                    ProductId = 3,
                    BeanId = 3,
                    StartDate = new DateOnly(2031, 3, 1),
                    EndDate = new DateOnly(2032, 3, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 12, 22)
                },
                new Contract
                {
                    Id = 84,
                    CustomerId = 84,
                    ProductId = 4,
                    BeanId = null,
                    StartDate = new DateOnly(2031, 4, 1),
                    EndDate = new DateOnly(2032, 4, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 12, 23)
                },
                new Contract
                {
                    Id = 85,
                    CustomerId = 85,
                    ProductId = 1,
                    BeanId = 2,
                    StartDate = new DateOnly(2031, 5, 1),
                    EndDate = new DateOnly(2032, 5, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 12, 24)
                },
                new Contract
                {
                    Id = 86,
                    CustomerId = 86,
                    ProductId = 2,
                    BeanId = null,
                    StartDate = new DateOnly(2031, 6, 1),
                    EndDate = new DateOnly(2032, 6, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 12, 25)
                },
                new Contract
                {
                    Id = 87,
                    CustomerId = 87,
                    ProductId = 3,
                    BeanId = 3,
                    StartDate = new DateOnly(2031, 7, 1),
                    EndDate = new DateOnly(2032, 7, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 12, 26)
                },
                new Contract
                {
                    Id = 88,
                    CustomerId = 88,
                    ProductId = 4,
                    BeanId = null,
                    StartDate = new DateOnly(2031, 8, 1),
                    EndDate = new DateOnly(2032, 8, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 12, 27)
                },
                new Contract
                {
                    Id = 89,
                    CustomerId = 89,
                    ProductId = 1,
                    BeanId = 1,
                    StartDate = new DateOnly(2031, 9, 1),
                    EndDate = new DateOnly(2032, 9, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 12, 28)
                },
                new Contract
                {
                    Id = 90,
                    CustomerId = 90,
                    ProductId = 2,
                    BeanId = null,
                    StartDate = new DateOnly(2031, 10, 1),
                    EndDate = new DateOnly(2032, 10, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 12, 29)
                },
                new Contract
                {
                    Id = 91,
                    CustomerId = 91,
                    ProductId = 3,
                    BeanId = 4,
                    StartDate = new DateOnly(2031, 11, 1),
                    EndDate = new DateOnly(2032, 11, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2023, 12, 30)
                },
                new Contract
                {
                    Id = 92,
                    CustomerId = 92,
                    ProductId = 4,
                    BeanId = null,
                    StartDate = new DateOnly(2031, 12, 1),
                    EndDate = new DateOnly(2032, 12, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2023, 12, 31)
                },
                new Contract
                {
                    Id = 93,
                    CustomerId = 93,
                    ProductId = 1,
                    BeanId = 2,
                    StartDate = new DateOnly(2032, 1, 1),
                    EndDate = new DateOnly(2033, 1, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2024, 1, 1)
                },
                new Contract
                {
                    Id = 94,
                    CustomerId = 94,
                    ProductId = 2,
                    BeanId = null,
                    StartDate = new DateOnly(2032, 2, 1),
                    EndDate = new DateOnly(2033, 2, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2024, 1, 2)
                },
                new Contract
                {
                    Id = 95,
                    CustomerId = 95,
                    ProductId = 3,
                    BeanId = 3,
                    StartDate = new DateOnly(2032, 3, 1),
                    EndDate = new DateOnly(2033, 3, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2024, 1, 3)
                },
                new Contract
                {
                    Id = 96,
                    CustomerId = 96,
                    ProductId = 4,
                    BeanId = null,
                    StartDate = new DateOnly(2032, 4, 1),
                    EndDate = new DateOnly(2033, 4, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2024, 1, 4)
                },
                new Contract
                {
                    Id = 97,
                    CustomerId = 97,
                    ProductId = 1,
                    BeanId = 2,
                    StartDate = new DateOnly(2032, 5, 1),
                    EndDate = new DateOnly(2033, 5, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2024, 1, 5)
                },
                new Contract
                {
                    Id = 98,
                    CustomerId = 98,
                    ProductId = 2,
                    BeanId = null,
                    StartDate = new DateOnly(2032, 6, 1),
                    EndDate = new DateOnly(2033, 6, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2024, 1, 6)
                },
                new Contract
                {
                    Id = 99,
                    CustomerId = 99,
                    ProductId = 3,
                    BeanId = 4,
                    StartDate = new DateOnly(2032, 7, 1),
                    EndDate = new DateOnly(2033, 7, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2024, 1, 7)
                },
                new Contract
                {
                    Id = 100,
                    CustomerId = 100,
                    ProductId = 4,
                    BeanId = null,
                    StartDate = new DateOnly(2032, 8, 1),
                    EndDate = new DateOnly(2033, 8, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2024, 1, 8)
                },
                new Contract
                {
                    Id = 101,
                    CustomerId = 101,
                    ProductId = 1,
                    BeanId = 1,
                    StartDate = new DateOnly(2033, 1, 1),
                    EndDate = new DateOnly(2034, 1, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2024, 1, 9)
                },
                new Contract
                {
                    Id = 102,
                    CustomerId = 102,
                    ProductId = 2,
                    BeanId = null,
                    StartDate = new DateOnly(2033, 2, 1),
                    EndDate = new DateOnly(2034, 2, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2024, 1, 10)
                },
                new Contract
                {
                    Id = 103,
                    CustomerId = 103,
                    ProductId = 3,
                    BeanId = 3,
                    StartDate = new DateOnly(2033, 3, 1),
                    EndDate = new DateOnly(2034, 3, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2024, 1, 11)
                },
                new Contract
                {
                    Id = 104,
                    CustomerId = 104,
                    ProductId = 4,
                    BeanId = null,
                    StartDate = new DateOnly(2033, 4, 1),
                    EndDate = new DateOnly(2034, 4, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2024, 1, 12)
                },
                new Contract
                {
                    Id = 105,
                    CustomerId = 105,
                    ProductId = 1,
                    BeanId = 2,
                    StartDate = new DateOnly(2033, 5, 1),
                    EndDate = new DateOnly(2034, 5, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2024, 1, 13)
                },
                new Contract
                {
                    Id = 106,
                    CustomerId = 106,
                    ProductId = 2,
                    BeanId = null,
                    StartDate = new DateOnly(2033, 6, 1),
                    EndDate = new DateOnly(2034, 6, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2024, 1, 14)
                },
                new Contract
                {
                    Id = 107,
                    CustomerId = 107,
                    ProductId = 3,
                    BeanId = 3,
                    StartDate = new DateOnly(2033, 7, 1),
                    EndDate = new DateOnly(2034, 7, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2024, 1, 15)
                },
                new Contract
                {
                    Id = 108,
                    CustomerId = 108,
                    ProductId = 4,
                    BeanId = null,
                    StartDate = new DateOnly(2033, 8, 1),
                    EndDate = new DateOnly(2034, 8, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2024, 1, 16)
                },
                new Contract
                {
                    Id = 109,
                    CustomerId = 109,
                    ProductId = 1,
                    BeanId = 1,
                    StartDate = new DateOnly(2033, 9, 1),
                    EndDate = new DateOnly(2034, 9, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2024, 1, 17)
                },
                new Contract
                {
                    Id = 110,
                    CustomerId = 110,
                    ProductId = 2,
                    BeanId = null,
                    StartDate = new DateOnly(2033, 10, 1),
                    EndDate = new DateOnly(2034, 10, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2024, 1, 18)
                },
                new Contract
                {
                    Id = 111,
                    CustomerId = 111,
                    ProductId = 3,
                    BeanId = 4,
                    StartDate = new DateOnly(2033, 11, 1),
                    EndDate = new DateOnly(2034, 11, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2024, 1, 19)
                },
                new Contract
                {
                    Id = 112,
                    CustomerId = 112,
                    ProductId = 4,
                    BeanId = null,
                    StartDate = new DateOnly(2033, 12, 1),
                    EndDate = new DateOnly(2034, 12, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2024, 1, 20)
                },
                new Contract
                {
                    Id = 113,
                    CustomerId = 113,
                    ProductId = 1,
                    BeanId = 2,
                    StartDate = new DateOnly(2034, 1, 1),
                    EndDate = new DateOnly(2035, 1, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2024, 1, 21)
                },
                new Contract
                {
                    Id = 114,
                    CustomerId = 114,
                    ProductId = 2,
                    BeanId = null,
                    StartDate = new DateOnly(2034, 2, 1),
                    EndDate = new DateOnly(2035, 2, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2024, 1, 22)
                },
                new Contract
                {
                    Id = 115,
                    CustomerId = 115,
                    ProductId = 3,
                    BeanId = 3,
                    StartDate = new DateOnly(2034, 3, 1),
                    EndDate = new DateOnly(2035, 3, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2024, 1, 23)
                },
                new Contract
                {
                    Id = 116,
                    CustomerId = 116,
                    ProductId = 4,
                    BeanId = null,
                    StartDate = new DateOnly(2034, 4, 1),
                    EndDate = new DateOnly(2035, 4, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2024, 1, 24)
                },
                new Contract
                {
                    Id = 117,
                    CustomerId = 117,
                    ProductId = 1,
                    BeanId = 2,
                    StartDate = new DateOnly(2034, 5, 1),
                    EndDate = new DateOnly(2035, 5, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2024, 1, 25)
                },
                new Contract
                {
                    Id = 118,
                    CustomerId = 118,
                    ProductId = 2,
                    BeanId = null,
                    StartDate = new DateOnly(2034, 6, 1),
                    EndDate = new DateOnly(2035, 6, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2024, 1, 26)
                },
                new Contract
                {
                    Id = 119,
                    CustomerId = 119,
                    ProductId = 3,
                    BeanId = 4,
                    StartDate = new DateOnly(2034, 7, 1),
                    EndDate = new DateOnly(2035, 7, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2024, 1, 27)
                },
                new Contract
                {
                     Id = 120,
                     CustomerId = 120,
                     ProductId = 4,
                     BeanId = null,
                     StartDate = new DateOnly(2034, 8, 1),
                     EndDate = new DateOnly(2035, 8, 1),
                     IsLeased = false,
                     IsPaid = true,
                     LastUpdate = new DateOnly(2024, 1, 28)
                },
                new Contract
                {
                    Id = 121,
                    CustomerId = 121,
                    ProductId = 1,
                    BeanId = 1,
                    StartDate = new DateOnly(2034, 9, 1),
                    EndDate = new DateOnly(2035, 9, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2024, 1, 29)
                },
                new Contract
                {
                    Id = 122,
                    CustomerId = 122,
                    ProductId = 2,
                    BeanId = null,
                    StartDate = new DateOnly(2034, 10, 1),
                    EndDate = new DateOnly(2035, 10, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2024, 1, 30)
                },
                new Contract
                {
                    Id = 123,
                    CustomerId = 123,
                    ProductId = 3,
                    BeanId = 4,
                    StartDate = new DateOnly(2034, 11, 1),
                    EndDate = new DateOnly(2035, 11, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2024, 1, 31)
                },
                new Contract
                {
                    Id = 124,
                    CustomerId = 124,
                    ProductId = 4,
                    BeanId = null,
                    StartDate = new DateOnly(2034, 12, 1),
                    EndDate = new DateOnly(2035, 12, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2024, 2, 1)
                },
                new Contract
                {
                    Id = 125,
                    CustomerId = 125,
                    ProductId = 1,
                    BeanId = 2,
                    StartDate = new DateOnly(2035, 1, 1),
                    EndDate = new DateOnly(2036, 1, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2024, 2, 2)
                },
                new Contract
                {
                    Id = 126,
                    CustomerId = 126,
                    ProductId = 2,
                    BeanId = null,
                    StartDate = new DateOnly(2035, 2, 1),
                    EndDate = new DateOnly(2036, 2, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2024, 2, 3)
                },
                new Contract
                {
                    Id = 127,
                    CustomerId = 127,
                    ProductId = 3,
                    BeanId = 3,
                    StartDate = new DateOnly(2035, 3, 1),
                    EndDate = new DateOnly(2036, 3, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2024, 2, 4)
                },
                new Contract
                {
                    Id = 128,
                    CustomerId = 128,
                    ProductId = 4,
                    BeanId = null,
                    StartDate = new DateOnly(2035, 4, 1),
                    EndDate = new DateOnly(2036, 4, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2024, 2, 5)
                },
                new Contract
                {
                    Id = 129,
                    CustomerId = 129,
                    ProductId = 1,
                    BeanId = 2,
                    StartDate = new DateOnly(2035, 5, 1),
                    EndDate = new DateOnly(2036, 5, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2024, 2, 6)
                },
                new Contract
                {
                    Id = 130,
                    CustomerId = 130,
                    ProductId = 2,
                    BeanId = null,
                    StartDate = new DateOnly(2035, 6, 1),
                    EndDate = new DateOnly(2036, 6, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2024, 2, 7)
                },
                new Contract
                {
                    Id = 131,
                    CustomerId = 131,
                    ProductId = 3,
                    BeanId = 4,
                    StartDate = new DateOnly(2035, 7, 1),
                    EndDate = new DateOnly(2036, 7, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2024, 2, 8)
                },
                new Contract
                {
                    Id = 132,
                    CustomerId = 132,
                    ProductId = 4,
                    BeanId = null,
                    StartDate = new DateOnly(2035, 8, 1),
                    EndDate = new DateOnly(2036, 8, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2024, 2, 9)
                },
                new Contract
                {
                    Id = 133,
                    CustomerId = 133,
                    ProductId = 1,
                    BeanId = 1,
                    StartDate = new DateOnly(2035, 9, 1),
                    EndDate = new DateOnly(2036, 9, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2024, 2, 10)
                },
                new Contract
                {
                    Id = 134,
                    CustomerId = 134,
                    ProductId = 2,
                    BeanId = null,
                    StartDate = new DateOnly(2035, 10, 1),
                    EndDate = new DateOnly(2036, 10, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2024, 2, 11)
                },
                new Contract
                {
                    Id = 135,
                    CustomerId = 135,
                    ProductId = 3,
                    BeanId = 4,
                    StartDate = new DateOnly(2035, 11, 1),
                    EndDate = new DateOnly(2036, 11, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2024, 2, 12)
                },
                new Contract
                {
                    Id = 136,
                    CustomerId = 136,
                    ProductId = 4,
                    BeanId = null,
                    StartDate = new DateOnly(2035, 12, 1),
                    EndDate = new DateOnly(2036, 12, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2024, 2, 13)
                },
                new Contract
                {
                    Id = 137,
                    CustomerId = 137,
                    ProductId = 1,
                    BeanId = 2,
                    StartDate = new DateOnly(2036, 1, 1),
                    EndDate = new DateOnly(2037, 1, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2024, 2, 14)
                },
                new Contract
                {
                    Id = 138,
                    CustomerId = 138,
                    ProductId = 2,
                    BeanId = null,
                    StartDate = new DateOnly(2036, 2, 1),
                    EndDate = new DateOnly(2037, 2, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2024, 2, 15)
                },
                new Contract
                {
                    Id = 139,
                    CustomerId = 139,
                    ProductId = 3,
                    BeanId = 3,
                    StartDate = new DateOnly(2036, 3, 1),
                    EndDate = new DateOnly(2037, 3, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2024, 2, 16)
                },
                new Contract
                {
                    Id = 140,
                    CustomerId = 140,
                    ProductId = 4,
                    BeanId = null,
                    StartDate = new DateOnly(2036, 4, 1),
                    EndDate = new DateOnly(2037, 4, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2024, 2, 17)
                },
                new Contract
                {
                    Id = 141,
                    CustomerId = 141,
                    ProductId = 1,
                    BeanId = 2,
                    StartDate = new DateOnly(2036, 5, 1),
                    EndDate = new DateOnly(2037, 5, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2024, 2, 18)
                },
                new Contract
                {
                    Id = 142,
                    CustomerId = 142,
                    ProductId = 2,
                    BeanId = null,
                    StartDate = new DateOnly(2036, 6, 1),
                    EndDate = new DateOnly(2037, 6, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2024, 2, 19)
                },
                new Contract
                {
                    Id = 143,
                    CustomerId = 143,
                    ProductId = 3,
                    BeanId = 4,
                    StartDate = new DateOnly(2036, 7, 1),
                    EndDate = new DateOnly(2037, 7, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2024, 2, 20)
                },
                new Contract
                {
                    Id = 144,
                    CustomerId = 144,
                    ProductId = 4,
                    BeanId = null,
                    StartDate = new DateOnly(2036, 8, 1),
                    EndDate = new DateOnly(2037, 8, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2024, 2, 21)
                },
                new Contract
                {
                    Id = 145,
                    CustomerId = 145,
                    ProductId = 1,
                    BeanId = 1,
                    StartDate = new DateOnly(2036, 9, 1),
                    EndDate = new DateOnly(2037, 9, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2024, 2, 22)
                },
                new Contract
                {
                    Id = 146,
                    CustomerId = 146,
                    ProductId = 2,
                    BeanId = null,
                    StartDate = new DateOnly(2036, 10, 1),
                    EndDate = new DateOnly(2037, 10, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2024, 2, 23)
                },
                new Contract
                {
                    Id = 147,
                    CustomerId = 147,
                    ProductId = 3,
                    BeanId = 4,
                    StartDate = new DateOnly(2036, 11, 1),
                    EndDate = new DateOnly(2037, 11, 1),
                    IsLeased = true,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2024, 2, 24)
                },
                new Contract
                {
                    Id = 148,
                    CustomerId = 148,
                    ProductId = 4,
                    BeanId = null,
                    StartDate = new DateOnly(2036, 12, 1),
                    EndDate = new DateOnly(2037, 12, 1),
                    IsLeased = false,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2024, 2, 25)
                },
                new Contract
                {
                    Id = 149,
                    CustomerId = 149,
                    ProductId = 1,
                    BeanId = 2,
                    StartDate = new DateOnly(2037, 1, 1),
                    EndDate = new DateOnly(2038, 1, 1),
                    IsLeased = true,
                    IsPaid = true,
                    LastUpdate = new DateOnly(2024, 2, 26)
                },
                new Contract
                {
                    Id = 150,
                    CustomerId = 150,
                    ProductId = 2,
                    BeanId = null,
                    StartDate = new DateOnly(2037, 2, 1),
                    EndDate = new DateOnly(2038, 2, 1),
                    IsLeased = false,
                    IsPaid = false,
                    LastUpdate = new DateOnly(2024, 2, 27)
                } */
            );

            modelBuilder.Entity<Invoice>().HasData(
                new Invoice
                {
                    Id = 1,
                    CustomerId = 1,
                    ContractId = 1,
                    DateIssued = new DateTime(2024, 1, 5),
                    DueDate = new DateTime(2024, 2, 5),
                    TotalAmount = 499.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 2,
                    CustomerId = 2,
                    ContractId = 2,
                    DateIssued = new DateTime(2024, 2, 6),
                    DueDate = new DateTime(2024, 3, 6),
                    TotalAmount = 599.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 3,
                    CustomerId = 3,
                    ContractId = 3,
                    DateIssued = new DateTime(2024, 3, 7),
                    DueDate = new DateTime(2024, 4, 7),
                    TotalAmount = 799.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 4,
                    CustomerId = 4,
                    ContractId = 4,
                    DateIssued = new DateTime(2024, 4, 8),
                    DueDate = new DateTime(2024, 5, 8),
                    TotalAmount = 999.00M,
                    IsPaid = true
                }
                /*new Invoice
                {
                    Id = 5,
                    CustomerId = 5,
                    ContractId = 5,
                    DateIssued = new DateTime(2024, 5, 9),
                    DueDate = new DateTime(2024, 6, 9),
                    TotalAmount = 399.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 6,
                    CustomerId = 6,
                    ContractId = 6,
                    DateIssued = new DateTime(2024, 6, 10),
                    DueDate = new DateTime(2024, 7, 10),
                    TotalAmount = 899.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 7,
                    CustomerId = 7,
                    ContractId = 7,
                    DateIssued = new DateTime(2024, 7, 11),
                    DueDate = new DateTime(2024, 8, 11),
                    TotalAmount = 699.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 8,
                    CustomerId = 8,
                    ContractId = 8,
                    DateIssued = new DateTime(2024, 8, 12),
                    DueDate = new DateTime(2024, 9, 12),
                    TotalAmount = 1299.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 9,
                    CustomerId = 9,
                    ContractId = 9,
                    DateIssued = new DateTime(2024, 9, 13),
                    DueDate = new DateTime(2024, 10, 13),
                    TotalAmount = 599.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 10,
                    CustomerId = 10,
                    ContractId = 10,
                    DateIssued = new DateTime(2024, 10, 14),
                    DueDate = new DateTime(2024, 11, 14),
                    TotalAmount = 799.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 11,
                    CustomerId = 11,
                    ContractId = 11,
                    DateIssued = new DateTime(2024, 11, 15),
                    DueDate = new DateTime(2024, 12, 15),
                    TotalAmount = 499.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 12,
                    CustomerId = 12,
                    ContractId = 12,
                    DateIssued = new DateTime(2024, 12, 16),
                    DueDate = new DateTime(2025, 1, 16),
                    TotalAmount = 599.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 13,
                    CustomerId = 13,
                    ContractId = 13,
                    DateIssued = new DateTime(2025, 1, 17),
                    DueDate = new DateTime(2025, 2, 17),
                    TotalAmount = 799.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 14,
                    CustomerId = 14,
                    ContractId = 14,
                    DateIssued = new DateTime(2025, 2, 18),
                    DueDate = new DateTime(2025, 3, 18),
                    TotalAmount = 999.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 15,
                    CustomerId = 15,
                    ContractId = 15,
                    DateIssued = new DateTime(2025, 3, 19),
                    DueDate = new DateTime(2025, 4, 19),
                    TotalAmount = 399.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 16,
                    CustomerId = 16,
                    ContractId = 16,
                    DateIssued = new DateTime(2025, 4, 20),
                    DueDate = new DateTime(2025, 5, 20),
                    TotalAmount = 899.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 17,
                    CustomerId = 17,
                    ContractId = 17,
                    DateIssued = new DateTime(2025, 5, 21),
                    DueDate = new DateTime(2025, 6, 21),
                    TotalAmount = 699.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 18,
                    CustomerId = 18,
                    ContractId = 18,
                    DateIssued = new DateTime(2025, 6, 22),
                    DueDate = new DateTime(2025, 7, 22),
                    TotalAmount = 1299.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 19,
                    CustomerId = 19,
                    ContractId = 19,
                    DateIssued = new DateTime(2025, 7, 23),
                    DueDate = new DateTime(2025, 8, 23),
                    TotalAmount = 599.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 20,
                    CustomerId = 20,
                    ContractId = 20,
                    DateIssued = new DateTime(2025, 8, 24),
                    DueDate = new DateTime(2025, 9, 24),
                    TotalAmount = 799.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 21,
                    CustomerId = 21,
                    ContractId = 21,
                    DateIssued = new DateTime(2025, 9, 25),
                    DueDate = new DateTime(2025, 10, 25),
                    TotalAmount = 500.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 22,
                    CustomerId = 22,
                    ContractId = 22,
                    DateIssued = new DateTime(2025, 10, 26),
                    DueDate = new DateTime(2025, 11, 26),
                    TotalAmount = 600.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 23,
                    CustomerId = 23,
                    ContractId = 23,
                    DateIssued = new DateTime(2025, 11, 27),
                    DueDate = new DateTime(2025, 12, 27),
                    TotalAmount = 700.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 24,
                    CustomerId = 24,
                    ContractId = 24,
                    DateIssued = new DateTime(2025, 12, 28),
                    DueDate = new DateTime(2026, 1, 28),
                    TotalAmount = 800.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 25,
                    CustomerId = 25,
                    ContractId = 25,
                    DateIssued = new DateTime(2026, 1, 29),
                    DueDate = new DateTime(2026, 2, 29),
                    TotalAmount = 900.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 26,
                    CustomerId = 26,
                    ContractId = 26,
                    DateIssued = new DateTime(2026, 2, 1),
                    DueDate = new DateTime(2026, 3, 1),
                    TotalAmount = 1000.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 27,
                    CustomerId = 27,
                    ContractId = 27,
                    DateIssued = new DateTime(2026, 3, 2),
                    DueDate = new DateTime(2026, 4, 2),
                    TotalAmount = 1100.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 28,
                    CustomerId = 28,
                    ContractId = 28,
                    DateIssued = new DateTime(2026, 4, 3),
                    DueDate = new DateTime(2026, 5, 3),
                    TotalAmount = 1200.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 29,
                    CustomerId = 29,
                    ContractId = 29,
                    DateIssued = new DateTime(2026, 5, 4),
                    DueDate = new DateTime(2026, 6, 4),
                    TotalAmount = 1300.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 30,
                    CustomerId = 30,
                    ContractId = 30,
                    DateIssued = new DateTime(2026, 6, 5),
                    DueDate = new DateTime(2026, 7, 5),
                    TotalAmount = 1400.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 31,
                    CustomerId = 31,
                    ContractId = 31,
                    DateIssued = new DateTime(2026, 7, 6),
                    DueDate = new DateTime(2026, 8, 6),
                    TotalAmount = 1500.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 32,
                    CustomerId = 32,
                    ContractId = 32,
                    DateIssued = new DateTime(2026, 8, 7),
                    DueDate = new DateTime(2026, 9, 7),
                    TotalAmount = 1600.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 33,
                    CustomerId = 33,
                    ContractId = 33,
                    DateIssued = new DateTime(2026, 9, 8),
                    DueDate = new DateTime(2026, 10, 8),
                    TotalAmount = 1700.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 34,
                    CustomerId = 34,
                    ContractId = 34,
                    DateIssued = new DateTime(2026, 10, 9),
                    DueDate = new DateTime(2026, 11, 9),
                    TotalAmount = 1800.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 35,
                    CustomerId = 35,
                    ContractId = 35,
                    DateIssued = new DateTime(2026, 11, 10),
                    DueDate = new DateTime(2026, 12, 10),
                    TotalAmount = 1900.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 36,
                    CustomerId = 36,
                    ContractId = 36,
                    DateIssued = new DateTime(2026, 12, 11),
                    DueDate = new DateTime(2027, 1, 11),
                    TotalAmount = 2000.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 37,
                    CustomerId = 37,
                    ContractId = 37,
                    DateIssued = new DateTime(2027, 1, 12),
                    DueDate = new DateTime(2027, 2, 12),
                    TotalAmount = 2100.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 38,
                    CustomerId = 38,
                    ContractId = 38,
                    DateIssued = new DateTime(2027, 2, 13),
                    DueDate = new DateTime(2027, 3, 13),
                    TotalAmount = 2200.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 39,
                    CustomerId = 39,
                    ContractId = 39,
                    DateIssued = new DateTime(2027, 3, 14),
                    DueDate = new DateTime(2027, 4, 14),
                    TotalAmount = 2300.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 40,
                    CustomerId = 40,
                    ContractId = 40,
                    DateIssued = new DateTime(2027, 4, 15),
                    DueDate = new DateTime(2027, 5, 15),
                    TotalAmount = 2400.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 41,
                    CustomerId = 41,
                    ContractId = 41,
                    DateIssued = new DateTime(2027, 5, 16),
                    DueDate = new DateTime(2027, 6, 16),
                    TotalAmount = 2500.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 42,
                    CustomerId = 42,
                    ContractId = 42,
                    DateIssued = new DateTime(2027, 6, 17),
                    DueDate = new DateTime(2027, 7, 17),
                    TotalAmount = 2600.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 43,
                    CustomerId = 43,
                    ContractId = 43,
                    DateIssued = new DateTime(2027, 7, 18),
                    DueDate = new DateTime(2027, 8, 18),
                    TotalAmount = 2700.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 44,
                    CustomerId = 44,
                    ContractId = 44,
                    DateIssued = new DateTime(2027, 8, 19),
                    DueDate = new DateTime(2027, 9, 19),
                    TotalAmount = 2800.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 45,
                    CustomerId = 45,
                    ContractId = 45,
                    DateIssued = new DateTime(2027, 9, 20),
                    DueDate = new DateTime(2027, 10, 20),
                    TotalAmount = 2900.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 46,
                    CustomerId = 46,
                    ContractId = 46,
                    DateIssued = new DateTime(2027, 10, 21),
                    DueDate = new DateTime(2027, 11, 21),
                    TotalAmount = 3000.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 47,
                    CustomerId = 47,
                    ContractId = 47,
                    DateIssued = new DateTime(2027, 11, 22),
                    DueDate = new DateTime(2027, 12, 22),
                    TotalAmount = 3100.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 48,
                    CustomerId = 48,
                    ContractId = 48,
                    DateIssued = new DateTime(2027, 12, 23),
                    DueDate = new DateTime(2028, 1, 23),
                    TotalAmount = 3200.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 49,
                    CustomerId = 49,
                    ContractId = 49,
                    DateIssued = new DateTime(2028, 1, 24),
                    DueDate = new DateTime(2028, 2, 24),
                    TotalAmount = 3300.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 50,
                    CustomerId = 50,
                    ContractId = 50,
                    DateIssued = new DateTime(2028, 2, 25),
                    DueDate = new DateTime(2028, 3, 25),
                    TotalAmount = 3400.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 51,
                    CustomerId = 51,
                    ContractId = 51,
                    DateIssued = new DateTime(2028, 3, 26),
                    DueDate = new DateTime(2028, 4, 26),
                    TotalAmount = 3500.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 52,
                    CustomerId = 52,
                    ContractId = 52,
                    DateIssued = new DateTime(2028, 4, 27),
                    DueDate = new DateTime(2028, 5, 27),
                    TotalAmount = 3600.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 53,
                    CustomerId = 53,
                    ContractId = 53,
                    DateIssued = new DateTime(2028, 5, 28),
                    DueDate = new DateTime(2028, 6, 28),
                    TotalAmount = 3700.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 54,
                    CustomerId = 54,
                    ContractId = 54,
                    DateIssued = new DateTime(2028, 6, 29),
                    DueDate = new DateTime(2028, 7, 29),
                    TotalAmount = 3800.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 55,
                    CustomerId = 55,
                    ContractId = 55,
                    DateIssued = new DateTime(2028, 7, 30),
                    DueDate = new DateTime(2028, 8, 30),
                    TotalAmount = 3900.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 56,
                    CustomerId = 56,
                    ContractId = 56,
                    DateIssued = new DateTime(2028, 8, 31),
                    DueDate = new DateTime(2028, 9, 31),
                    TotalAmount = 4000.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 57,
                    CustomerId = 57,
                    ContractId = 57,
                    DateIssued = new DateTime(2028, 9, 1),
                    DueDate = new DateTime(2028, 10, 1),
                    TotalAmount = 4100.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 58,
                    CustomerId = 58,
                    ContractId = 58,
                    DateIssued = new DateTime(2028, 10, 2),
                    DueDate = new DateTime(2028, 11, 2),
                    TotalAmount = 4200.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 59,
                    CustomerId = 59,
                    ContractId = 59,
                    DateIssued = new DateTime(2028, 11, 3),
                    DueDate = new DateTime(2028, 12, 3),
                    TotalAmount = 4300.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 60,
                    CustomerId = 60,
                    ContractId = 60,
                    DateIssued = new DateTime(2028, 12, 4),
                    DueDate = new DateTime(2029, 1, 4),
                    TotalAmount = 4400.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 61,
                    CustomerId = 61,
                    ContractId = 61,
                    DateIssued = new DateTime(2029, 1, 5),
                    DueDate = new DateTime(2029, 2, 5),
                    TotalAmount = 4500.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 62,
                    CustomerId = 62,
                    ContractId = 62,
                    DateIssued = new DateTime(2029, 2, 6),
                    DueDate = new DateTime(2029, 3, 6),
                    TotalAmount = 4600.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 63,
                    CustomerId = 63,
                    ContractId = 63,
                    DateIssued = new DateTime(2029, 3, 7),
                    DueDate = new DateTime(2029, 4, 7),
                    TotalAmount = 4700.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 64,
                    CustomerId = 64,
                    ContractId = 64,
                    DateIssued = new DateTime(2029, 4, 8),
                    DueDate = new DateTime(2029, 5, 8),
                    TotalAmount = 4800.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 65,
                    CustomerId = 65,
                    ContractId = 65,
                    DateIssued = new DateTime(2029, 5, 9),
                    DueDate = new DateTime(2029, 6, 9),
                    TotalAmount = 4900.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 66,
                    CustomerId = 66,
                    ContractId = 66,
                    DateIssued = new DateTime(2029, 6, 10),
                    DueDate = new DateTime(2029, 7, 10),
                    TotalAmount = 5000.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 67,
                    CustomerId = 67,
                    ContractId = 67,
                    DateIssued = new DateTime(2029, 7, 11),
                    DueDate = new DateTime(2029, 8, 11),
                    TotalAmount = 5100.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 68,
                    CustomerId = 68,
                    ContractId = 68,
                    DateIssued = new DateTime(2029, 8, 12),
                    DueDate = new DateTime(2029, 9, 12),
                    TotalAmount = 5200.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 69,
                    CustomerId = 69,
                    ContractId = 69,
                    DateIssued = new DateTime(2029, 9, 13),
                    DueDate = new DateTime(2029, 10, 13),
                    TotalAmount = 5300.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 70,
                    CustomerId = 70,
                    ContractId = 70,
                    DateIssued = new DateTime(2029, 10, 14),
                    DueDate = new DateTime(2029, 11, 14),
                    TotalAmount = 5400.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 71,
                    CustomerId = 71,
                    ContractId = 71,
                    DateIssued = new DateTime(2029, 11, 15),
                    DueDate = new DateTime(2029, 12, 15),
                    TotalAmount = 5500.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 72,
                    CustomerId = 72,
                    ContractId = 72,
                    DateIssued = new DateTime(2029, 12, 16),
                    DueDate = new DateTime(2030, 1, 16),
                    TotalAmount = 5600.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 73,
                    CustomerId = 73,
                    ContractId = 73,
                    DateIssued = new DateTime(2030, 1, 17),
                    DueDate = new DateTime(2030, 2, 17),
                    TotalAmount = 5700.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 74,
                    CustomerId = 74,
                    ContractId = 74,
                    DateIssued = new DateTime(2030, 2, 18),
                    DueDate = new DateTime(2030, 3, 18),
                    TotalAmount = 5800.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 75,
                    CustomerId = 75,
                    ContractId = 75,
                    DateIssued = new DateTime(2030, 3, 19),
                    DueDate = new DateTime(2030, 4, 19),
                    TotalAmount = 5900.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 76,
                    CustomerId = 76,
                    ContractId = 76,
                    DateIssued = new DateTime(2030, 4, 20),
                    DueDate = new DateTime(2030, 5, 20),
                    TotalAmount = 6000.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 77,
                    CustomerId = 77,
                    ContractId = 77,
                    DateIssued = new DateTime(2030, 5, 21),
                    DueDate = new DateTime(2030, 6, 21),
                    TotalAmount = 6100.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 78,
                    CustomerId = 78,
                    ContractId = 78,
                    DateIssued = new DateTime(2030, 6, 22),
                    DueDate = new DateTime(2030, 7, 22),
                    TotalAmount = 6200.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 79,
                    CustomerId = 79,
                    ContractId = 79,
                    DateIssued = new DateTime(2030, 7, 23),
                    DueDate = new DateTime(2030, 8, 23),
                    TotalAmount = 6300.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 80,
                    CustomerId = 80,
                    ContractId = 80,
                    DateIssued = new DateTime(2030, 8, 24),
                    DueDate = new DateTime(2030, 9, 24),
                    TotalAmount = 6400.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 81,
                    CustomerId = 81,
                    ContractId = 81,
                    DateIssued = new DateTime(2030, 9, 25),
                    DueDate = new DateTime(2030, 10, 25),
                    TotalAmount = 6500.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 82,
                    CustomerId = 82,
                    ContractId = 82,
                    DateIssued = new DateTime(2030, 10, 26),
                    DueDate = new DateTime(2030, 11, 26),
                    TotalAmount = 6600.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 83,
                    CustomerId = 83,
                    ContractId = 83,
                    DateIssued = new DateTime(2030, 11, 27),
                    DueDate = new DateTime(2030, 12, 27),
                    TotalAmount = 6700.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 84,
                    CustomerId = 84,
                    ContractId = 84,
                    DateIssued = new DateTime(2030, 12, 28),
                    DueDate = new DateTime(2031, 1, 28),
                    TotalAmount = 6800.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 85,
                    CustomerId = 85,
                    ContractId = 85,
                    DateIssued = new DateTime(2031, 1, 29),
                    DueDate = new DateTime(2031, 2, 29),
                    TotalAmount = 6900.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 86,
                    CustomerId = 86,
                    ContractId = 86,
                    DateIssued = new DateTime(2031, 2, 1),
                    DueDate = new DateTime(2031, 3, 1),
                    TotalAmount = 7000.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 87,
                    CustomerId = 87,
                    ContractId = 87,
                    DateIssued = new DateTime(2031, 3, 2),
                    DueDate = new DateTime(2031, 4, 2),
                    TotalAmount = 7100.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 88,
                    CustomerId = 88,
                    ContractId = 88,
                    DateIssued = new DateTime(2031, 4, 3),
                    DueDate = new DateTime(2031, 5, 3),
                    TotalAmount = 7200.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 89,
                    CustomerId = 89,
                    ContractId = 89,
                    DateIssued = new DateTime(2031, 5, 4),
                    DueDate = new DateTime(2031, 6, 4),
                    TotalAmount = 7300.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 90,
                    CustomerId = 90,
                    ContractId = 90,
                    DateIssued = new DateTime(2031, 6, 5),
                    DueDate = new DateTime(2031, 7, 5),
                    TotalAmount = 7400.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 91,
                    CustomerId = 91,
                    ContractId = 91,
                    DateIssued = new DateTime(2031, 7, 6),
                    DueDate = new DateTime(2031, 8, 6),
                    TotalAmount = 7500.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 92,
                    CustomerId = 92,
                    ContractId = 92,
                    DateIssued = new DateTime(2031, 8, 7),
                    DueDate = new DateTime(2031, 9, 7),
                    TotalAmount = 7600.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 93,
                    CustomerId = 93,
                    ContractId = 93,
                    DateIssued = new DateTime(2031, 9, 8),
                    DueDate = new DateTime(2031, 10, 8),
                    TotalAmount = 7700.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 94,
                    CustomerId = 94,
                    ContractId = 94,
                    DateIssued = new DateTime(2031, 10, 9),
                    DueDate = new DateTime(2031, 11, 9),
                    TotalAmount = 7800.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 95,
                    CustomerId = 95,
                    ContractId = 95,
                    DateIssued = new DateTime(2031, 11, 10),
                    DueDate = new DateTime(2031, 12, 10),
                    TotalAmount = 7900.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 96,
                    CustomerId = 96,
                    ContractId = 96,
                    DateIssued = new DateTime(2031, 12, 11),
                    DueDate = new DateTime(2032, 1, 11),
                    TotalAmount = 8000.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 97,
                    CustomerId = 97,
                    ContractId = 97,
                    DateIssued = new DateTime(2032, 1, 12),
                    DueDate = new DateTime(2032, 2, 12),
                    TotalAmount = 8100.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 98,
                    CustomerId = 98,
                    ContractId = 98,
                    DateIssued = new DateTime(2032, 2, 13),
                    DueDate = new DateTime(2032, 3, 13),
                    TotalAmount = 8200.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 99,
                    CustomerId = 99,
                    ContractId = 99,
                    DateIssued = new DateTime(2032, 3, 14),
                    DueDate = new DateTime(2032, 4, 14),
                    TotalAmount = 8300.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 100,
                    CustomerId = 100,
                    ContractId = 100,
                    DateIssued = new DateTime(2032, 4, 15),
                    DueDate = new DateTime(2032, 5, 15),
                    TotalAmount = 8400.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 101,
                    CustomerId = 101,
                    ContractId = 101,
                    DateIssued = new DateTime(2032, 5, 16),
                    DueDate = new DateTime(2032, 6, 16),
                    TotalAmount = 8500.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 102,
                    CustomerId = 102,
                    ContractId = 102,
                    DateIssued = new DateTime(2032, 6, 17),
                    DueDate = new DateTime(2032, 7, 17),
                    TotalAmount = 8600.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 103,
                    CustomerId = 103,
                    ContractId = 103,
                    DateIssued = new DateTime(2032, 7, 18),
                    DueDate = new DateTime(2032, 8, 18),
                    TotalAmount = 8700.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 104,
                    CustomerId = 104,
                    ContractId = 104,
                    DateIssued = new DateTime(2032, 8, 19),
                    DueDate = new DateTime(2032, 9, 19),
                    TotalAmount = 8800.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 105,
                    CustomerId = 105,
                    ContractId = 105,
                    DateIssued = new DateTime(2032, 9, 20),
                    DueDate = new DateTime(2032, 10, 20),
                    TotalAmount = 8900.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 106,
                    CustomerId = 106,
                    ContractId = 106,
                    DateIssued = new DateTime(2032, 10, 21),
                    DueDate = new DateTime(2032, 11, 21),
                    TotalAmount = 9000.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 107,
                    CustomerId = 107,
                    ContractId = 107,
                    DateIssued = new DateTime(2032, 11, 22),
                    DueDate = new DateTime(2032, 12, 22),
                    TotalAmount = 9100.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 108,
                    CustomerId = 108,
                    ContractId = 108,
                    DateIssued = new DateTime(2032, 12, 23),
                    DueDate = new DateTime(2033, 1, 23),
                    TotalAmount = 9200.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 109,
                    CustomerId = 109,
                    ContractId = 109,
                    DateIssued = new DateTime(2033, 1, 24),
                    DueDate = new DateTime(2033, 2, 24),
                    TotalAmount = 9300.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 110,
                    CustomerId = 110,
                    ContractId = 110,
                    DateIssued = new DateTime(2033, 2, 25),
                    DueDate = new DateTime(2033, 3, 25),
                    TotalAmount = 9400.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 111,
                    CustomerId = 111,
                    ContractId = 111,
                    DateIssued = new DateTime(2033, 3, 26),
                    DueDate = new DateTime(2033, 4, 26),
                    TotalAmount = 9500.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 112,
                    CustomerId = 112,
                    ContractId = 112,
                    DateIssued = new DateTime(2033, 4, 27),
                    DueDate = new DateTime(2033, 5, 27),
                    TotalAmount = 9600.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 113,
                    CustomerId = 113,
                    ContractId = 113,
                    DateIssued = new DateTime(2033, 5, 28),
                    DueDate = new DateTime(2033, 6, 28),
                    TotalAmount = 9700.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 114,
                    CustomerId = 114,
                    ContractId = 114,
                    DateIssued = new DateTime(2033, 6, 29),
                    DueDate = new DateTime(2033, 7, 29),
                    TotalAmount = 9800.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 115,
                    CustomerId = 115,
                    ContractId = 115,
                    DateIssued = new DateTime(2033, 7, 30),
                    DueDate = new DateTime(2033, 8, 30),
                    TotalAmount = 9900.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 116,
                    CustomerId = 116,
                    ContractId = 116,
                    DateIssued = new DateTime(2033, 8, 31),
                    DueDate = new DateTime(2033, 9, 31),
                    TotalAmount = 10000.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 117,
                    CustomerId = 117,
                    ContractId = 117,
                    DateIssued = new DateTime(2033, 9, 1),
                    DueDate = new DateTime(2033, 10, 1),
                    TotalAmount = 10100.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 118,
                    CustomerId = 118,
                    ContractId = 118,
                    DateIssued = new DateTime(2033, 10, 2),
                    DueDate = new DateTime(2033, 11, 2),
                    TotalAmount = 10200.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 119,
                    CustomerId = 119,
                    ContractId = 119,
                    DateIssued = new DateTime(2033, 11, 3),
                    DueDate = new DateTime(2033, 12, 3),
                    TotalAmount = 10300.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 120,
                    CustomerId = 120,
                    ContractId = 120,
                    DateIssued = new DateTime(2033, 12, 4),
                    DueDate = new DateTime(2034, 1, 4),
                    TotalAmount = 10400.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 121,
                    CustomerId = 121,
                    ContractId = 121,
                    DateIssued = new DateTime(2034, 1, 5),
                    DueDate = new DateTime(2034, 2, 5),
                    TotalAmount = 10500.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 122,
                    CustomerId = 122,
                    ContractId = 122,
                    DateIssued = new DateTime(2034, 2, 6),
                    DueDate = new DateTime(2034, 3, 6),
                    TotalAmount = 10600.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 123,
                    CustomerId = 123,
                    ContractId = 123,
                    DateIssued = new DateTime(2034, 3, 7),
                    DueDate = new DateTime(2034, 4, 7),
                    TotalAmount = 10700.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 124,
                    CustomerId = 124,
                    ContractId = 124,
                    DateIssued = new DateTime(2034, 4, 8),
                    DueDate = new DateTime(2034, 5, 8),
                    TotalAmount = 10800.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 125,
                    CustomerId = 125,
                    ContractId = 125,
                    DateIssued = new DateTime(2034, 5, 9),
                    DueDate = new DateTime(2034, 6, 9),
                    TotalAmount = 10900.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 126,
                    CustomerId = 126,
                    ContractId = 126,
                    DateIssued = new DateTime(2034, 6, 10),
                    DueDate = new DateTime(2034, 7, 10),
                    TotalAmount = 11000.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 127,
                    CustomerId = 127,
                    ContractId = 127,
                    DateIssued = new DateTime(2034, 7, 11),
                    DueDate = new DateTime(2034, 8, 11),
                    TotalAmount = 11100.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 128,
                    CustomerId = 128,
                    ContractId = 128,
                    DateIssued = new DateTime(2034, 8, 12),
                    DueDate = new DateTime(2034, 9, 12),
                    TotalAmount = 11200.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 129,
                    CustomerId = 129,
                    ContractId = 129,
                    DateIssued = new DateTime(2034, 9, 13),
                    DueDate = new DateTime(2034, 10, 13),
                    TotalAmount = 11300.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 130,
                    CustomerId = 130,
                    ContractId = 130,
                    DateIssued = new DateTime(2034, 10, 14),
                    DueDate = new DateTime(2034, 11, 14),
                    TotalAmount = 11400.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 131,
                    CustomerId = 131,
                    ContractId = 131,
                    DateIssued = new DateTime(2034, 11, 15),
                    DueDate = new DateTime(2034, 12, 15),
                    TotalAmount = 11500.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 132,
                    CustomerId = 132,
                    ContractId = 132,
                    DateIssued = new DateTime(2034, 12, 16),
                    DueDate = new DateTime(2035, 1, 16),
                    TotalAmount = 11600.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 133,
                    CustomerId = 133,
                    ContractId = 133,
                    DateIssued = new DateTime(2035, 1, 17),
                    DueDate = new DateTime(2035, 2, 17),
                    TotalAmount = 11700.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 134,
                    CustomerId = 134,
                    ContractId = 134,
                    DateIssued = new DateTime(2035, 2, 18),
                    DueDate = new DateTime(2035, 3, 18),
                    TotalAmount = 11800.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 135,
                    CustomerId = 135,
                    ContractId = 135,
                    DateIssued = new DateTime(2035, 3, 19),
                    DueDate = new DateTime(2035, 4, 19),
                    TotalAmount = 11900.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 136,
                    CustomerId = 136,
                    ContractId = 136,
                    DateIssued = new DateTime(2035, 4, 20),
                    DueDate = new DateTime(2035, 5, 20),
                    TotalAmount = 12000.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 137,
                    CustomerId = 137,
                    ContractId = 137,
                    DateIssued = new DateTime(2035, 5, 21),
                    DueDate = new DateTime(2035, 6, 21),
                    TotalAmount = 12100.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 138,
                    CustomerId = 138,
                    ContractId = 138,
                    DateIssued = new DateTime(2035, 6, 22),
                    DueDate = new DateTime(2035, 7, 22),
                    TotalAmount = 12200.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 139,
                    CustomerId = 139,
                    ContractId = 139,
                    DateIssued = new DateTime(2035, 7, 23),
                    DueDate = new DateTime(2035, 8, 23),
                    TotalAmount = 12300.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 140,
                    CustomerId = 140,
                    ContractId = 140,
                    DateIssued = new DateTime(2035, 8, 24),
                    DueDate = new DateTime(2035, 9, 24),
                    TotalAmount = 12400.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 141,
                    CustomerId = 141,
                    ContractId = 141,
                    DateIssued = new DateTime(2035, 9, 25),
                    DueDate = new DateTime(2035, 10, 25),
                    TotalAmount = 12500.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 142,
                    CustomerId = 142,
                    ContractId = 142,
                    DateIssued = new DateTime(2035, 10, 26),
                    DueDate = new DateTime(2035, 11, 26),
                    TotalAmount = 12600.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 143,
                    CustomerId = 143,
                    ContractId = 143,
                    DateIssued = new DateTime(2035, 11, 27),
                    DueDate = new DateTime(2035, 12, 27),
                    TotalAmount = 12700.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 144,
                    CustomerId = 144,
                    ContractId = 144,
                    DateIssued = new DateTime(2035, 12, 28),
                    DueDate = new DateTime(2036, 1, 28),
                    TotalAmount = 12800.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 145,
                    CustomerId = 145,
                    ContractId = 145,
                    DateIssued = new DateTime(2036, 1, 29),
                    DueDate = new DateTime(2036, 2, 29),
                    TotalAmount = 12900.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 146,
                    CustomerId = 146,
                    ContractId = 146,
                    DateIssued = new DateTime(2036, 2, 1),
                    DueDate = new DateTime(2036, 3, 1),
                    TotalAmount = 13000.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 147,
                    CustomerId = 147,
                    ContractId = 147,
                    DateIssued = new DateTime(2036, 3, 2),
                    DueDate = new DateTime(2036, 4, 2),
                    TotalAmount = 13100.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 148,
                    CustomerId = 148,
                    ContractId = 148,
                    DateIssued = new DateTime(2036, 4, 3),
                    DueDate = new DateTime(2036, 5, 3),
                    TotalAmount = 13200.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 149,
                    CustomerId = 149,
                    ContractId = 149,
                    DateIssued = new DateTime(2036, 5, 4),
                    DueDate = new DateTime(2036, 6, 4),
                    TotalAmount = 13300.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 150,
                    CustomerId = 150,
                    ContractId = 150,
                    DateIssued = new DateTime(2036, 6, 5),
                    DueDate = new DateTime(2036, 7, 5),
                    TotalAmount = 13400.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 151,
                    CustomerId = 12,
                    ContractId = 78,
                    DateIssued = new DateTime(2036, 7, 6),
                    DueDate = new DateTime(2036, 8, 6),
                    TotalAmount = 13500.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 152,
                    CustomerId = 45,
                    ContractId = 31,
                    DateIssued = new DateTime(2036, 8, 7),
                    DueDate = new DateTime(2036, 9, 7),
                    TotalAmount = 13600.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 153,
                    CustomerId = 23,
                    ContractId = 102,
                    DateIssued = new DateTime(2036, 9, 8),
                    DueDate = new DateTime(2036, 10, 8),
                    TotalAmount = 13700.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 154,
                    CustomerId = 67,
                    ContractId = 87,
                    DateIssued = new DateTime(2036, 10, 9),
                    DueDate = new DateTime(2036, 11, 9),
                    TotalAmount = 13800.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 155,
                    CustomerId = 30,
                    ContractId = 40,
                    DateIssued = new DateTime(2036, 11, 10),
                    DueDate = new DateTime(2036, 12, 10),
                    TotalAmount = 13900.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 156,
                    CustomerId = 56,
                    ContractId = 15,
                    DateIssued = new DateTime(2036, 12, 11),
                    DueDate = new DateTime(2037, 1, 11),
                    TotalAmount = 14000.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 157,
                    CustomerId = 88,
                    ContractId = 63,
                    DateIssued = new DateTime(2037, 1, 12),
                    DueDate = new DateTime(2037, 2, 12),
                    TotalAmount = 14100.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 158,
                    CustomerId = 22,
                    ContractId = 49,
                    DateIssued = new DateTime(2037, 2, 13),
                    DueDate = new DateTime(2037, 3, 13),
                    TotalAmount = 14200.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 159,
                    CustomerId = 34,
                    ContractId = 10,
                    DateIssued = new DateTime(2037, 3, 14),
                    DueDate = new DateTime(2037, 4, 14),
                    TotalAmount = 14300.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 160,
                    CustomerId = 73,
                    ContractId = 91,
                    DateIssued = new DateTime(2037, 4, 15),
                    DueDate = new DateTime(2037, 5, 15),
                    TotalAmount = 14400.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 161,
                    CustomerId = 29,
                    ContractId = 66,
                    DateIssued = new DateTime(2037, 5, 16),
                    DueDate = new DateTime(2037, 6, 16),
                    TotalAmount = 14500.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 162,
                    CustomerId = 48,
                    ContractId = 121,
                    DateIssued = new DateTime(2037, 6, 17),
                    DueDate = new DateTime(2037, 7, 17),
                    TotalAmount = 14600.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 163,
                    CustomerId = 91,
                    ContractId = 55,
                    DateIssued = new DateTime(2037, 7, 18),
                    DueDate = new DateTime(2037, 8, 18),
                    TotalAmount = 14700.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 164,
                    CustomerId = 19,
                    ContractId = 134,
                    DateIssued = new DateTime(2037, 8, 19),
                    DueDate = new DateTime(2037, 9, 19),
                    TotalAmount = 14800.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 165,
                    CustomerId = 95,
                    ContractId = 77,
                    DateIssued = new DateTime(2037, 9, 20),
                    DueDate = new DateTime(2037, 10, 20),
                    TotalAmount = 14900.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 166,
                    CustomerId = 36,
                    ContractId = 109,
                    DateIssued = new DateTime(2037, 10, 21),
                    DueDate = new DateTime(2037, 11, 21),
                    TotalAmount = 15000.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 167,
                    CustomerId = 53,
                    ContractId = 99,
                    DateIssued = new DateTime(2037, 11, 22),
                    DueDate = new DateTime(2037, 12, 22),
                    TotalAmount = 15100.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 168,
                    CustomerId = 100,
                    ContractId = 125,
                    DateIssued = new DateTime(2037, 12, 23),
                    DueDate = new DateTime(2038, 1, 23),
                    TotalAmount = 15200.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 169,
                    CustomerId = 84,
                    ContractId = 58,
                    DateIssued = new DateTime(2038, 1, 24),
                    DueDate = new DateTime(2038, 2, 24),
                    TotalAmount = 15300.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 170,
                    CustomerId = 3,
                    ContractId = 85,
                    DateIssued = new DateTime(2038, 2, 25),
                    DueDate = new DateTime(2038, 3, 25),
                    TotalAmount = 15400.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 171,
                    CustomerId = 66,
                    ContractId = 142,
                    DateIssued = new DateTime(2038, 3, 26),
                    DueDate = new DateTime(2038, 4, 26),
                    TotalAmount = 15500.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 172,
                    CustomerId = 11,
                    ContractId = 11,
                    DateIssued = new DateTime(2038, 4, 27),
                    DueDate = new DateTime(2038, 5, 27),
                    TotalAmount = 15600.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 173,
                    CustomerId = 42,
                    ContractId = 74,
                    DateIssued = new DateTime(2038, 5, 28),
                    DueDate = new DateTime(2038, 6, 28),
                    TotalAmount = 15700.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 174,
                    CustomerId = 62,
                    ContractId = 145,
                    DateIssued = new DateTime(2038, 6, 29),
                    DueDate = new DateTime(2038, 7, 29),
                    TotalAmount = 15800.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 175,
                    CustomerId = 41,
                    ContractId = 36,
                    DateIssued = new DateTime(2038, 7, 30),
                    DueDate = new DateTime(2038, 8, 30),
                    TotalAmount = 15900.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 176,
                    CustomerId = 60,
                    ContractId = 12,
                    DateIssued = new DateTime(2038, 8, 31),
                    DueDate = new DateTime(2038, 9, 31),
                    TotalAmount = 16000.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 177,
                    CustomerId = 74,
                    ContractId = 129,
                    DateIssued = new DateTime(2038, 9, 1),
                    DueDate = new DateTime(2038, 10, 1),
                    TotalAmount = 16100.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 178,
                    CustomerId = 99,
                    ContractId = 75,
                    DateIssued = new DateTime(2038, 10, 2),
                    DueDate = new DateTime(2038, 11, 2),
                    TotalAmount = 16200.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 179,
                    CustomerId = 32,
                    ContractId = 50,
                    DateIssued = new DateTime(2038, 11, 3),
                    DueDate = new DateTime(2038, 12, 3),
                    TotalAmount = 16300.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 180,
                    CustomerId = 58,
                    ContractId = 103,
                    DateIssued = new DateTime(2038, 12, 4),
                    DueDate = new DateTime(2039, 1, 4),
                    TotalAmount = 16400.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 181,
                    CustomerId = 18,
                    ContractId = 92,
                    DateIssued = new DateTime(2039, 1, 5),
                    DueDate = new DateTime(2039, 2, 5),
                    TotalAmount = 16500.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 182,
                    CustomerId = 77,
                    ContractId = 22,
                    DateIssued = new DateTime(2039, 2, 6),
                    DueDate = new DateTime(2039, 3, 6),
                    TotalAmount = 16600.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 183,
                    CustomerId = 90,
                    ContractId = 118,
                    DateIssued = new DateTime(2039, 3, 7),
                    DueDate = new DateTime(2039, 4, 7),
                    TotalAmount = 16700.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 184,
                    CustomerId = 33,
                    ContractId = 39,
                    DateIssued = new DateTime(2039, 4, 8),
                    DueDate = new DateTime(2039, 5, 8),
                    TotalAmount = 16800.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 185,
                    CustomerId = 12,
                    ContractId = 73,
                    DateIssued = new DateTime(2039, 5, 9),
                    DueDate = new DateTime(2039, 6, 9),
                    TotalAmount = 16900.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 186,
                    CustomerId = 66,
                    ContractId = 15,
                    DateIssued = new DateTime(2039, 6, 10),
                    DueDate = new DateTime(2039, 7, 10),
                    TotalAmount = 17000.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 187,
                    CustomerId = 44,
                    ContractId = 134,
                    DateIssued = new DateTime(2039, 7, 11),
                    DueDate = new DateTime(2039, 8, 11),
                    TotalAmount = 17100.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 188,
                    CustomerId = 81,
                    ContractId = 98,
                    DateIssued = new DateTime(2039, 8, 12),
                    DueDate = new DateTime(2039, 9, 12),
                    TotalAmount = 17200.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 189,
                    CustomerId = 55,
                    ContractId = 66,
                    DateIssued = new DateTime(2039, 9, 13),
                    DueDate = new DateTime(2039, 10, 13),
                    TotalAmount = 17300.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 190,
                    CustomerId = 39,
                    ContractId = 111,
                    DateIssued = new DateTime(2039, 10, 14),
                    DueDate = new DateTime(2039, 11, 14),
                    TotalAmount = 17400.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 191,
                    CustomerId = 14,
                    ContractId = 61,
                    DateIssued = new DateTime(2039, 11, 15),
                    DueDate = new DateTime(2039, 12, 15),
                    TotalAmount = 17500.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 192,
                    CustomerId = 72,
                    ContractId = 24,
                    DateIssued = new DateTime(2039, 12, 16),
                    DueDate = new DateTime(2040, 1, 16),
                    TotalAmount = 17600.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 193,
                    CustomerId = 49,
                    ContractId = 59,
                    DateIssued = new DateTime(2040, 1, 17),
                    DueDate = new DateTime(2040, 2, 17),
                    TotalAmount = 17700.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 194,
                    CustomerId = 15,
                    ContractId = 132,
                    DateIssued = new DateTime(2040, 2, 18),
                    DueDate = new DateTime(2040, 3, 18),
                    TotalAmount = 17800.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 195,
                    CustomerId = 97,
                    ContractId = 48,
                    DateIssued = new DateTime(2040, 3, 19),
                    DueDate = new DateTime(2040, 4, 19),
                    TotalAmount = 17900.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 196,
                    CustomerId = 10,
                    ContractId = 80,
                    DateIssued = new DateTime(2040, 4, 20),
                    DueDate = new DateTime(2040, 5, 20),
                    TotalAmount = 18000.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 197,
                    CustomerId = 92,
                    ContractId = 12,
                    DateIssued = new DateTime(2040, 5, 21),
                    DueDate = new DateTime(2040, 6, 21),
                    TotalAmount = 18100.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 198,
                    CustomerId = 37,
                    ContractId = 56,
                    DateIssued = new DateTime(2040, 6, 22),
                    DueDate = new DateTime(2040, 7, 22),
                    TotalAmount = 18200.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 199,
                    CustomerId = 68,
                    ContractId = 139,
                    DateIssued = new DateTime(2040, 7, 23),
                    DueDate = new DateTime(2040, 8, 23),
                    TotalAmount = 18300.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 200,
                    CustomerId = 25,
                    ContractId = 69,
                    DateIssued = new DateTime(2040, 8, 24),
                    DueDate = new DateTime(2040, 9, 24),
                    TotalAmount = 18400.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 201,
                    CustomerId = 7,
                    ContractId = 134,
                    DateIssued = new DateTime(2040, 9, 25),
                    DueDate = new DateTime(2040, 10, 25),
                    TotalAmount = 18500.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 202,
                    CustomerId = 82,
                    ContractId = 19,
                    DateIssued = new DateTime(2040, 10, 26),
                    DueDate = new DateTime(2040, 11, 26),
                    TotalAmount = 18600.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 203,
                    CustomerId = 5,
                    ContractId = 88,
                    DateIssued = new DateTime(2040, 11, 27),
                    DueDate = new DateTime(2040, 12, 27),
                    TotalAmount = 18700.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 204,
                    CustomerId = 76,
                    ContractId = 29,
                    DateIssued = new DateTime(2040, 12, 28),
                    DueDate = new DateTime(2041, 1, 28),
                    TotalAmount = 18800.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 205,
                    CustomerId = 15,
                    ContractId = 37,
                    DateIssued = new DateTime(2041, 1, 29),
                    DueDate = new DateTime(2041, 2, 28),
                    TotalAmount = 18900.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 206,
                    CustomerId = 29,
                    ContractId = 64,
                    DateIssued = new DateTime(2041, 2, 1),
                    DueDate = new DateTime(2041, 3, 1),
                    TotalAmount = 19000.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 207,
                    CustomerId = 89,
                    ContractId = 43,
                    DateIssued = new DateTime(2041, 3, 2),
                    DueDate = new DateTime(2041, 4, 2),
                    TotalAmount = 19100.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 208,
                    CustomerId = 23,
                    ContractId = 105,
                    DateIssued = new DateTime(2041, 4, 3),
                    DueDate = new DateTime(2041, 5, 3),
                    TotalAmount = 19200.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 209,
                    CustomerId = 33,
                    ContractId = 56,
                    DateIssued = new DateTime(2041, 5, 4),
                    DueDate = new DateTime(2041, 6, 4),
                    TotalAmount = 19300.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 210,
                    CustomerId = 45,
                    ContractId = 22,
                    DateIssued = new DateTime(2041, 6, 5),
                    DueDate = new DateTime(2041, 7, 5),
                    TotalAmount = 19400.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 211,
                    CustomerId = 67,
                    ContractId = 84,
                    DateIssued = new DateTime(2041, 7, 6),
                    DueDate = new DateTime(2041, 8, 6),
                    TotalAmount = 19500.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 212,
                    CustomerId = 1,
                    ContractId = 12,
                    DateIssued = new DateTime(2041, 8, 7),
                    DueDate = new DateTime(2041, 9, 7),
                    TotalAmount = 19600.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 213,
                    CustomerId = 38,
                    ContractId = 61,
                    DateIssued = new DateTime(2041, 9, 8),
                    DueDate = new DateTime(2041, 10, 8),
                    TotalAmount = 19700.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 214,
                    CustomerId = 99,
                    ContractId = 97,
                    DateIssued = new DateTime(2041, 10, 9),
                    DueDate = new DateTime(2041, 11, 9),
                    TotalAmount = 19800.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 215,
                    CustomerId = 50,
                    ContractId = 10,
                    DateIssued = new DateTime(2041, 11, 10),
                    DueDate = new DateTime(2041, 12, 10),
                    TotalAmount = 19900.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 216,
                    CustomerId = 93,
                    ContractId = 41,
                    DateIssued = new DateTime(2041, 12, 11),
                    DueDate = new DateTime(2042, 1, 11),
                    TotalAmount = 20000.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 217,
                    CustomerId = 60,
                    ContractId = 77,
                    DateIssued = new DateTime(2042, 1, 12),
                    DueDate = new DateTime(2042, 2, 12),
                    TotalAmount = 20100.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 218,
                    CustomerId = 25,
                    ContractId = 99,
                    DateIssued = new DateTime(2042, 2, 13),
                    DueDate = new DateTime(2042, 3, 13),
                    TotalAmount = 20200.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 219,
                    CustomerId = 75,
                    ContractId = 51,
                    DateIssued = new DateTime(2042, 3, 14),
                    DueDate = new DateTime(2042, 4, 14),
                    TotalAmount = 20300.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 220,
                    CustomerId = 22,
                    ContractId = 111,
                    DateIssued = new DateTime(2042, 4, 15),
                    DueDate = new DateTime(2042, 5, 15),
                    TotalAmount = 20400.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 221,
                    CustomerId = 80,
                    ContractId = 67,
                    DateIssued = new DateTime(2042, 5, 16),
                    DueDate = new DateTime(2042, 6, 16),
                    TotalAmount = 20500.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 222,
                    CustomerId = 12,
                    ContractId = 45,
                    DateIssued = new DateTime(2042, 6, 17),
                    DueDate = new DateTime(2042, 7, 17),
                    TotalAmount = 20600.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 223,
                    CustomerId = 54,
                    ContractId = 119,
                    DateIssued = new DateTime(2042, 7, 18),
                    DueDate = new DateTime(2042, 8, 18),
                    TotalAmount = 20700.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 224,
                    CustomerId = 19,
                    ContractId = 55,
                    DateIssued = new DateTime(2042, 8, 19),
                    DueDate = new DateTime(2042, 9, 19),
                    TotalAmount = 20800.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 225,
                    CustomerId = 92,
                    ContractId = 30,
                    DateIssued = new DateTime(2042, 9, 20),
                    DueDate = new DateTime(2042, 10, 20),
                    TotalAmount = 20900.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 226,
                    CustomerId = 39,
                    ContractId = 42,
                    DateIssued = new DateTime(2042, 10, 21),
                    DueDate = new DateTime(2042, 11, 21),
                    TotalAmount = 21000.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 227,
                    CustomerId = 10,
                    ContractId = 104,
                    DateIssued = new DateTime(2042, 11, 22),
                    DueDate = new DateTime(2042, 12, 22),
                    TotalAmount = 21100.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 228,
                    CustomerId = 78,
                    ContractId = 59,
                    DateIssued = new DateTime(2042, 12, 23),
                    DueDate = new DateTime(2043, 1, 23),
                    TotalAmount = 21200.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 229,
                    CustomerId = 30,
                    ContractId = 15,
                    DateIssued = new DateTime(2043, 1, 24),
                    DueDate = new DateTime(2043, 2, 24),
                    TotalAmount = 21300.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 230,
                    CustomerId = 85,
                    ContractId = 38,
                    DateIssued = new DateTime(2043, 2, 25),
                    DueDate = new DateTime(2043, 3, 25),
                    TotalAmount = 21400.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 231,
                    CustomerId = 73,
                    ContractId = 99,
                    DateIssued = new DateTime(2043, 3, 26),
                    DueDate = new DateTime(2043, 4, 26),
                    TotalAmount = 21500.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 232,
                    CustomerId = 2,
                    ContractId = 48,
                    DateIssued = new DateTime(2043, 4, 27),
                    DueDate = new DateTime(2043, 5, 27),
                    TotalAmount = 21600.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 233,
                    CustomerId = 62,
                    ContractId = 113,
                    DateIssued = new DateTime(2043, 5, 28),
                    DueDate = new DateTime(2043, 6, 28),
                    TotalAmount = 21700.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 234,
                    CustomerId = 4,
                    ContractId = 71,
                    DateIssued = new DateTime(2043, 6, 29),
                    DueDate = new DateTime(2043, 7, 29),
                    TotalAmount = 21800.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 235,
                    CustomerId = 27,
                    ContractId = 34,
                    DateIssued = new DateTime(2043, 7, 30),
                    DueDate = new DateTime(2043, 8, 30),
                    TotalAmount = 21900.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 236,
                    CustomerId = 55,
                    ContractId = 25,
                    DateIssued = new DateTime(2043, 8, 31),
                    DueDate = new DateTime(2043, 9, 30),
                    TotalAmount = 22000.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 237,
                    CustomerId = 91,
                    ContractId = 52,
                    DateIssued = new DateTime(2043, 9, 1),
                    DueDate = new DateTime(2043, 10, 1),
                    TotalAmount = 22100.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 238,
                    CustomerId = 18,
                    ContractId = 26,
                    DateIssued = new DateTime(2043, 10, 2),
                    DueDate = new DateTime(2043, 11, 2),
                    TotalAmount = 22200.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 239,
                    CustomerId = 79,
                    ContractId = 114,
                    DateIssued = new DateTime(2043, 11, 3),
                    DueDate = new DateTime(2043, 12, 3),
                    TotalAmount = 22300.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 240,
                    CustomerId = 36,
                    ContractId = 66,
                    DateIssued = new DateTime(2043, 12, 4),
                    DueDate = new DateTime(2044, 1, 4),
                    TotalAmount = 22400.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 241,
                    CustomerId = 43,
                    ContractId = 92,
                    DateIssued = new DateTime(2044, 1, 5),
                    DueDate = new DateTime(2044, 2, 5),
                    TotalAmount = 22500.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 242,
                    CustomerId = 54,
                    ContractId = 37,
                    DateIssued = new DateTime(2044, 2, 6),
                    DueDate = new DateTime(2044, 3, 6),
                    TotalAmount = 22600.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 243,
                    CustomerId = 11,
                    ContractId = 71,
                    DateIssued = new DateTime(2044, 3, 7),
                    DueDate = new DateTime(2044, 4, 7),
                    TotalAmount = 22700.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 244,
                    CustomerId = 68,
                    ContractId = 18,
                    DateIssued = new DateTime(2044, 4, 8),
                    DueDate = new DateTime(2044, 5, 8),
                    TotalAmount = 22800.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 245,
                    CustomerId = 22,
                    ContractId = 39,
                    DateIssued = new DateTime(2044, 5, 9),
                    DueDate = new DateTime(2044, 6, 9),
                    TotalAmount = 22900.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 246,
                    CustomerId = 3,
                    ContractId = 108,
                    DateIssued = new DateTime(2044, 6, 10),
                    DueDate = new DateTime(2044, 7, 10),
                    TotalAmount = 23000.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 247,
                    CustomerId = 85,
                    ContractId = 12,
                    DateIssued = new DateTime(2044, 7, 11),
                    DueDate = new DateTime(2044, 8, 11),
                    TotalAmount = 23100.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 248,
                    CustomerId = 20,
                    ContractId = 46,
                    DateIssued = new DateTime(2044, 8, 12),
                    DueDate = new DateTime(2044, 9, 12),
                    TotalAmount = 23200.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 249,
                    CustomerId = 90,
                    ContractId = 93,
                    DateIssued = new DateTime(2044, 9, 13),
                    DueDate = new DateTime(2044, 10, 13),
                    TotalAmount = 23300.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 250,
                    CustomerId = 38,
                    ContractId = 23,
                    DateIssued = new DateTime(2044, 10, 14),
                    DueDate = new DateTime(2044, 11, 14),
                    TotalAmount = 23400.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 251,
                    CustomerId = 62,
                    ContractId = 58,
                    DateIssued = new DateTime(2044, 11, 15),
                    DueDate = new DateTime(2044, 12, 15),
                    TotalAmount = 23500.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 252,
                    CustomerId = 88,
                    ContractId = 85,
                    DateIssued = new DateTime(2044, 12, 16),
                    DueDate = new DateTime(2045, 1, 16),
                    TotalAmount = 23600.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 253,
                    CustomerId = 77,
                    ContractId = 31,
                    DateIssued = new DateTime(2045, 1, 17),
                    DueDate = new DateTime(2045, 2, 17),
                    TotalAmount = 23700.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 254,
                    CustomerId = 99,
                    ContractId = 98,
                    DateIssued = new DateTime(2045, 2, 18),
                    DueDate = new DateTime(2045, 3, 18),
                    TotalAmount = 23800.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 255,
                    CustomerId = 30,
                    ContractId = 72,
                    DateIssued = new DateTime(2045, 3, 19),
                    DueDate = new DateTime(2045, 4, 19),
                    TotalAmount = 23900.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 256,
                    CustomerId = 5,
                    ContractId = 106,
                    DateIssued = new DateTime(2045, 4, 20),
                    DueDate = new DateTime(2045, 5, 20),
                    TotalAmount = 24000.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 257,
                    CustomerId = 65,
                    ContractId = 13,
                    DateIssued = new DateTime(2045, 5, 21),
                    DueDate = new DateTime(2045, 6, 21),
                    TotalAmount = 24100.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 258,
                    CustomerId = 14,
                    ContractId = 88,
                    DateIssued = new DateTime(2045, 6, 22),
                    DueDate = new DateTime(2045, 7, 22),
                    TotalAmount = 24200.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 259,
                    CustomerId = 76,
                    ContractId = 54,
                    DateIssued = new DateTime(2045, 7, 23),
                    DueDate = new DateTime(2045, 8, 23),
                    TotalAmount = 24300.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 260,
                    CustomerId = 48,
                    ContractId = 26,
                    DateIssued = new DateTime(2045, 8, 24),
                    DueDate = new DateTime(2045, 9, 24),
                    TotalAmount = 24400.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 261,
                    CustomerId = 29,
                    ContractId = 100,
                    DateIssued = new DateTime(2045, 9, 25),
                    DueDate = new DateTime(2045, 10, 25),
                    TotalAmount = 24500.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 262,
                    CustomerId = 91,
                    ContractId = 39,
                    DateIssued = new DateTime(2045, 10, 26),
                    DueDate = new DateTime(2045, 11, 26),
                    TotalAmount = 24600.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 263,
                    CustomerId = 12,
                    ContractId = 17,
                    DateIssued = new DateTime(2045, 11, 27),
                    DueDate = new DateTime(2045, 12, 27),
                    TotalAmount = 24700.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 264,
                    CustomerId = 36,
                    ContractId = 66,
                    DateIssued = new DateTime(2045, 12, 28),
                    DueDate = new DateTime(2046, 1, 28),
                    TotalAmount = 24800.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 265,
                    CustomerId = 15,
                    ContractId = 75,
                    DateIssued = new DateTime(2046, 1, 29),
                    DueDate = new DateTime(2046, 2, 28),
                    TotalAmount = 24900.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 266,
                    CustomerId = 70,
                    ContractId = 114,
                    DateIssued = new DateTime(2046, 2, 1),
                    DueDate = new DateTime(2046, 3, 1),
                    TotalAmount = 25000.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 267,
                    CustomerId = 53,
                    ContractId = 83,
                    DateIssued = new DateTime(2046, 3, 2),
                    DueDate = new DateTime(2046, 4, 2),
                    TotalAmount = 25100.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 268,
                    CustomerId = 80,
                    ContractId = 69,
                    DateIssued = new DateTime(2046, 4, 3),
                    DueDate = new DateTime(2046, 5, 3),
                    TotalAmount = 25200.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 269,
                    CustomerId = 7,
                    ContractId = 49,
                    DateIssued = new DateTime(2046, 5, 4),
                    DueDate = new DateTime(2046, 6, 4),
                    TotalAmount = 25300.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 270,
                    CustomerId = 61,
                    ContractId = 44,
                    DateIssued = new DateTime(2046, 6, 5),
                    DueDate = new DateTime(2046, 7, 5),
                    TotalAmount = 25400.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 271,
                    CustomerId = 35,
                    ContractId = 94,
                    DateIssued = new DateTime(2046, 7, 6),
                    DueDate = new DateTime(2046, 8, 6),
                    TotalAmount = 25500.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 272,
                    CustomerId = 98,
                    ContractId = 62,
                    DateIssued = new DateTime(2046, 8, 7),
                    DueDate = new DateTime(2046, 9, 7),
                    TotalAmount = 25600.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 273,
                    CustomerId = 18,
                    ContractId = 104,
                    DateIssued = new DateTime(2046, 9, 8),
                    DueDate = new DateTime(2046, 10, 8),
                    TotalAmount = 25700.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 274,
                    CustomerId = 39,
                    ContractId = 89,
                    DateIssued = new DateTime(2046, 10, 9),
                    DueDate = new DateTime(2046, 11, 9),
                    TotalAmount = 25800.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 275,
                    CustomerId = 8,
                    ContractId = 34,
                    DateIssued = new DateTime(2046, 11, 10),
                    DueDate = new DateTime(2046, 12, 10),
                    TotalAmount = 25900.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 276,
                    CustomerId = 84,
                    ContractId = 50,
                    DateIssued = new DateTime(2046, 12, 11),
                    DueDate = new DateTime(2047, 1, 11),
                    TotalAmount = 26000.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 277,
                    CustomerId = 49,
                    ContractId = 73,
                    DateIssued = new DateTime(2047, 1, 12),
                    DueDate = new DateTime(2047, 2, 12),
                    TotalAmount = 26100.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 278,
                    CustomerId = 65,
                    ContractId = 57,
                    DateIssued = new DateTime(2047, 2, 13),
                    DueDate = new DateTime(2047, 3, 13),
                    TotalAmount = 26200.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 279,
                    CustomerId = 19,
                    ContractId = 99,
                    DateIssued = new DateTime(2047, 3, 14),
                    DueDate = new DateTime(2047, 4, 14),
                    TotalAmount = 26300.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 280,
                    CustomerId = 90,
                    ContractId = 27,
                    DateIssued = new DateTime(2047, 4, 15),
                    DueDate = new DateTime(2047, 5, 15),
                    TotalAmount = 26400.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 281,
                    CustomerId = 55,
                    ContractId = 72,
                    DateIssued = new DateTime(2047, 5, 16),
                    DueDate = new DateTime(2047, 6, 16),
                    TotalAmount = 26500.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 282,
                    CustomerId = 4,
                    ContractId = 110,
                    DateIssued = new DateTime(2047, 6, 17),
                    DueDate = new DateTime(2047, 7, 17),
                    TotalAmount = 26600.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 283,
                    CustomerId = 27,
                    ContractId = 25,
                    DateIssued = new DateTime(2047, 7, 18),
                    DueDate = new DateTime(2047, 8, 18),
                    TotalAmount = 26700.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 284,
                    CustomerId = 66,
                    ContractId = 42,
                    DateIssued = new DateTime(2047, 8, 19),
                    DueDate = new DateTime(2047, 9, 19),
                    TotalAmount = 26800.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 285,
                    CustomerId = 89,
                    ContractId = 12,
                    DateIssued = new DateTime(2047, 9, 20),
                    DueDate = new DateTime(2047, 10, 20),
                    TotalAmount = 26900.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 286,
                    CustomerId = 14,
                    ContractId = 53,
                    DateIssued = new DateTime(2047, 10, 21),
                    DueDate = new DateTime(2047, 11, 21),
                    TotalAmount = 27000.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 287,
                    CustomerId = 88,
                    ContractId = 39,
                    DateIssued = new DateTime(2047, 11, 22),
                    DueDate = new DateTime(2047, 12, 22),
                    TotalAmount = 27100.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 288,
                    CustomerId = 25,
                    ContractId = 88,
                    DateIssued = new DateTime(2047, 12, 23),
                    DueDate = new DateTime(2048, 1, 23),
                    TotalAmount = 27200.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 289,
                    CustomerId = 47,
                    ContractId = 62,
                    DateIssued = new DateTime(2048, 1, 24),
                    DueDate = new DateTime(2048, 2, 24),
                    TotalAmount = 27300.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 290,
                    CustomerId = 80,
                    ContractId = 10,
                    DateIssued = new DateTime(2048, 2, 25),
                    DueDate = new DateTime(2048, 3, 25),
                    TotalAmount = 27400.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 291,
                    CustomerId = 34,
                    ContractId = 28,
                    DateIssued = new DateTime(2048, 3, 26),
                    DueDate = new DateTime(2048, 4, 26),
                    TotalAmount = 27500.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 292,
                    CustomerId = 99,
                    ContractId = 51,
                    DateIssued = new DateTime(2048, 4, 27),
                    DueDate = new DateTime(2048, 5, 27),
                    TotalAmount = 27600.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 293,
                    CustomerId = 59,
                    ContractId = 96,
                    DateIssued = new DateTime(2048, 5, 28),
                    DueDate = new DateTime(2048, 6, 28),
                    TotalAmount = 27700.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 294,
                    CustomerId = 18,
                    ContractId = 29,
                    DateIssued = new DateTime(2048, 6, 29),
                    DueDate = new DateTime(2048, 7, 29),
                    TotalAmount = 27800.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 295,
                    CustomerId = 7,
                    ContractId = 83,
                    DateIssued = new DateTime(2048, 7, 30),
                    DueDate = new DateTime(2048, 8, 30),
                    TotalAmount = 27900.00M,
                    IsPaid = true
                },
                new Invoice { Id = 296, CustomerId = 63, ContractId = 70, DateIssued = new DateTime(2048, 8, 31), DueDate = new DateTime(2048, 9, 30), TotalAmount = 28000.00M, IsPaid = false },
                new Invoice
                {
                    Id = 297,
                    CustomerId = 32,
                    ContractId = 102,
                    DateIssued = new DateTime(2048, 9, 1),
                    DueDate = new DateTime(2048, 10, 1),
                    TotalAmount = 28100.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 298,
                    CustomerId = 21,
                    ContractId = 41,
                    DateIssued = new DateTime(2048, 10, 2),
                    DueDate = new DateTime(2048, 11, 2),
                    TotalAmount = 28200.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 299,
                    CustomerId = 40,
                    ContractId = 67,
                    DateIssued = new DateTime(2048, 11, 3),
                    DueDate = new DateTime(2048, 12, 3),
                    TotalAmount = 28300.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 300,
                    CustomerId = 92,
                    ContractId = 19,
                    DateIssued = new DateTime(2048, 12, 4),
                    DueDate = new DateTime(2049, 1, 4),
                    TotalAmount = 28400.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 301,
                    CustomerId = 31,
                    ContractId = 5,
                    DateIssued = new DateTime(2049, 1, 5),
                    DueDate = new DateTime(2049, 2, 5),
                    TotalAmount = 28500.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 302,
                    CustomerId = 12,
                    ContractId = 81,
                    DateIssued = new DateTime(2049, 2, 6),
                    DueDate = new DateTime(2049, 3, 6),
                    TotalAmount = 28600.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 303,
                    CustomerId = 45,
                    ContractId = 24,
                    DateIssued = new DateTime(2049, 3, 7),
                    DueDate = new DateTime(2049, 4, 7),
                    TotalAmount = 28700.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 304,
                    CustomerId = 9,
                    ContractId = 62,
                    DateIssued = new DateTime(2049, 4, 8),
                    DueDate = new DateTime(2049, 5, 8),
                    TotalAmount = 28800.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 305,
                    CustomerId = 78,
                    ContractId = 11,
                    DateIssued = new DateTime(2049, 5, 9),
                    DueDate = new DateTime(2049, 6, 9),
                    TotalAmount = 28900.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 306,
                    CustomerId = 36,
                    ContractId = 102,
                    DateIssued = new DateTime(2049, 6, 10),
                    DueDate = new DateTime(2049, 7, 10),
                    TotalAmount = 29000.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 307,
                    CustomerId = 53,
                    ContractId = 39,
                    DateIssued = new DateTime(2049, 7, 11),
                    DueDate = new DateTime(2049, 8, 11),
                    TotalAmount = 29100.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 308,
                    CustomerId = 23,
                    ContractId = 77,
                    DateIssued = new DateTime(2049, 8, 12),
                    DueDate = new DateTime(2049, 9, 12),
                    TotalAmount = 29200.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 309,
                    CustomerId = 67,
                    ContractId = 16,
                    DateIssued = new DateTime(2049, 9, 13),
                    DueDate = new DateTime(2049, 10, 13),
                    TotalAmount = 29300.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 310,
                    CustomerId = 19,
                    ContractId = 95,
                    DateIssued = new DateTime(2049, 10, 14),
                    DueDate = new DateTime(2049, 11, 14),
                    TotalAmount = 29400.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 311,
                    CustomerId = 88,
                    ContractId = 54,
                    DateIssued = new DateTime(2049, 11, 15),
                    DueDate = new DateTime(2049, 12, 15),
                    TotalAmount = 29500.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 312,
                    CustomerId = 16,
                    ContractId = 80,
                    DateIssued = new DateTime(2049, 12, 16),
                    DueDate = new DateTime(2050, 1, 16),
                    TotalAmount = 29600.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 313,
                    CustomerId = 37,
                    ContractId = 34,
                    DateIssued = new DateTime(2050, 1, 17),
                    DueDate = new DateTime(2050, 2, 17),
                    TotalAmount = 29700.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 314,
                    CustomerId = 70,
                    ContractId = 78,
                    DateIssued = new DateTime(2050, 2, 18),
                    DueDate = new DateTime(2050, 3, 18),
                    TotalAmount = 29800.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 315,
                    CustomerId = 39,
                    ContractId = 41,
                    DateIssued = new DateTime(2050, 3, 19),
                    DueDate = new DateTime(2050, 4, 19),
                    TotalAmount = 29900.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 316,
                    CustomerId = 24,
                    ContractId = 107,
                    DateIssued = new DateTime(2050, 4, 20),
                    DueDate = new DateTime(2050, 5, 20),
                    TotalAmount = 30000.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 317,
                    CustomerId = 60,
                    ContractId = 36,
                    DateIssued = new DateTime(2050, 5, 21),
                    DueDate = new DateTime(2050, 6, 21),
                    TotalAmount = 30100.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 318,
                    CustomerId = 34,
                    ContractId = 92,
                    DateIssued = new DateTime(2050, 6, 22),
                    DueDate = new DateTime(2050, 7, 22),
                    TotalAmount = 30200.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 319,
                    CustomerId = 10,
                    ContractId = 65,
                    DateIssued = new DateTime(2050, 7, 23),
                    DueDate = new DateTime(2050, 8, 23),
                    TotalAmount = 30300.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 320,
                    CustomerId = 51,
                    ContractId = 49,
                    DateIssued = new DateTime(2050, 8, 24),
                    DueDate = new DateTime(2050, 9, 24),
                    TotalAmount = 30400.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 321,
                    CustomerId = 32,
                    ContractId = 88,
                    DateIssued = new DateTime(2050, 9, 25),
                    DueDate = new DateTime(2050, 10, 25),
                    TotalAmount = 30500.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 322,
                    CustomerId = 42,
                    ContractId = 21,
                    DateIssued = new DateTime(2050, 10, 26),
                    DueDate = new DateTime(2050, 11, 26),
                    TotalAmount = 30600.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 323,
                    CustomerId = 7,
                    ContractId = 72,
                    DateIssued = new DateTime(2050, 11, 27),
                    DueDate = new DateTime(2050, 12, 27),
                    TotalAmount = 30700.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 324,
                    CustomerId = 66,
                    ContractId = 16,
                    DateIssued = new DateTime(2050, 12, 28),
                    DueDate = new DateTime(2051, 1, 28),
                    TotalAmount = 30800.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 325,
                    CustomerId = 44,
                    ContractId = 43,
                    DateIssued = new DateTime(2051, 1, 29),
                    DueDate = new DateTime(2051, 2, 29),
                    TotalAmount = 30900.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 326,
                    CustomerId = 63,
                    ContractId = 84,
                    DateIssued = new DateTime(2051, 2, 1),
                    DueDate = new DateTime(2051, 3, 1),
                    TotalAmount = 31000.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 327,
                    CustomerId = 26,
                    ContractId = 3,
                    DateIssued = new DateTime(2051, 3, 2),
                    DueDate = new DateTime(2051, 4, 2),
                    TotalAmount = 31100.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 328,
                    CustomerId = 79,
                    ContractId = 70,
                    DateIssued = new DateTime(2051, 4, 3),
                    DueDate = new DateTime(2051, 5, 3),
                    TotalAmount = 31200.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 329,
                    CustomerId = 54,
                    ContractId = 9,
                    DateIssued = new DateTime(2051, 5, 4),
                    DueDate = new DateTime(2051, 6, 4),
                    TotalAmount = 31300.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 330,
                    CustomerId = 14,
                    ContractId = 91,
                    DateIssued = new DateTime(2051, 6, 5),
                    DueDate = new DateTime(2051, 7, 5),
                    TotalAmount = 31400.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 331,
                    CustomerId = 20,
                    ContractId = 58,
                    DateIssued = new DateTime(2051, 7, 6),
                    DueDate = new DateTime(2051, 8, 6),
                    TotalAmount = 31500.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 332,
                    CustomerId = 81,
                    ContractId = 31,
                    DateIssued = new DateTime(2051, 8, 7),
                    DueDate = new DateTime(2051, 9, 7),
                    TotalAmount = 31600.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 333,
                    CustomerId = 49,
                    ContractId = 17,
                    DateIssued = new DateTime(2051, 9, 8),
                    DueDate = new DateTime(2051, 10, 8),
                    TotalAmount = 31700.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 334,
                    CustomerId = 11,
                    ContractId = 74,
                    DateIssued = new DateTime(2051, 10, 9),
                    DueDate = new DateTime(2051, 11, 9),
                    TotalAmount = 31800.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 335,
                    CustomerId = 22,
                    ContractId = 6,
                    DateIssued = new DateTime(2051, 11, 10),
                    DueDate = new DateTime(2051, 12, 10),
                    TotalAmount = 31900.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 336,
                    CustomerId = 38,
                    ContractId = 64,
                    DateIssued = new DateTime(2051, 12, 11),
                    DueDate = new DateTime(2052, 1, 11),
                    TotalAmount = 32000.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 337,
                    CustomerId = 8,
                    ContractId = 73,
                    DateIssued = new DateTime(2052, 1, 12),
                    DueDate = new DateTime(2052, 2, 12),
                    TotalAmount = 32100.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 338,
                    CustomerId = 87,
                    ContractId = 55,
                    DateIssued = new DateTime(2052, 2, 13),
                    DueDate = new DateTime(2052, 3, 13),
                    TotalAmount = 32200.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 339,
                    CustomerId = 75,
                    ContractId = 97,
                    DateIssued = new DateTime(2052, 3, 14),
                    DueDate = new DateTime(2052, 4, 14),
                    TotalAmount = 32300.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 340,
                    CustomerId = 65,
                    ContractId = 30,
                    DateIssued = new DateTime(2052, 4, 15),
                    DueDate = new DateTime(2052, 5, 15),
                    TotalAmount = 32400.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 341,
                    CustomerId = 1,
                    ContractId = 15,
                    DateIssued = new DateTime(2052, 5, 16),
                    DueDate = new DateTime(2052, 6, 16),
                    TotalAmount = 32500.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 342,
                    CustomerId = 30,
                    ContractId = 50,
                    DateIssued = new DateTime(2052, 6, 17),
                    DueDate = new DateTime(2052, 7, 17),
                    TotalAmount = 32600.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 343,
                    CustomerId = 33,
                    ContractId = 44,
                    DateIssued = new DateTime(2052, 7, 18),
                    DueDate = new DateTime(2052, 8, 18),
                    TotalAmount = 32700.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 344,
                    CustomerId = 61,
                    ContractId = 66,
                    DateIssued = new DateTime(2052, 8, 19),
                    DueDate = new DateTime(2052, 9, 19),
                    TotalAmount = 32800.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 345,
                    CustomerId = 48,
                    ContractId = 8,
                    DateIssued = new DateTime(2052, 9, 20),
                    DueDate = new DateTime(2052, 10, 20),
                    TotalAmount = 32900.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 346,
                    CustomerId = 3,
                    ContractId = 23,
                    DateIssued = new DateTime(2052, 10, 21),
                    DueDate = new DateTime(2052, 11, 21),
                    TotalAmount = 33000.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 347,
                    CustomerId = 71,
                    ContractId = 60,
                    DateIssued = new DateTime(2052, 11, 22),
                    DueDate = new DateTime(2052, 12, 22),
                    TotalAmount = 33100.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 348,
                    CustomerId = 64,
                    ContractId = 48,
                    DateIssued = new DateTime(2052, 12, 23),
                    DueDate = new DateTime(2053, 1, 23),
                    TotalAmount = 33200.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 349,
                    CustomerId = 52,
                    ContractId = 76,
                    DateIssued = new DateTime(2053, 1, 24),
                    DueDate = new DateTime(2053, 2, 24),
                    TotalAmount = 33300.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 350,
                    CustomerId = 43,
                    ContractId = 99,
                    DateIssued = new DateTime(2053, 2, 25),
                    DueDate = new DateTime(2053, 3, 25),
                    TotalAmount = 33400.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 351,
                    CustomerId = 15,
                    ContractId = 37,
                    DateIssued = new DateTime(2053, 3, 26),
                    DueDate = new DateTime(2053, 4, 26),
                    TotalAmount = 33500.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 352,
                    CustomerId = 59,
                    ContractId = 90,
                    DateIssued = new DateTime(2053, 4, 27),
                    DueDate = new DateTime(2053, 5, 27),
                    TotalAmount = 33600.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 353,
                    CustomerId = 77,
                    ContractId = 86,
                    DateIssued = new DateTime(2053, 5, 28),
                    DueDate = new DateTime(2053, 6, 28),
                    TotalAmount = 33700.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 354,
                    CustomerId = 29,
                    ContractId = 11,
                    DateIssued = new DateTime(2053, 6, 29),
                    DueDate = new DateTime(2053, 7, 29),
                    TotalAmount = 33800.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 355,
                    CustomerId = 76,
                    ContractId = 3,
                    DateIssued = new DateTime(2053, 7, 30),
                    DueDate = new DateTime(2053, 8, 30),
                    TotalAmount = 33900.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 356,
                    CustomerId = 13,
                    ContractId = 5,
                    DateIssued = new DateTime(2053, 8, 31),
                    DueDate = new DateTime(2053, 9, 30),
                    TotalAmount = 34000.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 357,
                    CustomerId = 72,
                    ContractId = 22,
                    DateIssued = new DateTime(2053, 9, 1),
                    DueDate = new DateTime(2053, 10, 1),
                    TotalAmount = 34100.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 358,
                    CustomerId = 80,
                    ContractId = 68,
                    DateIssued = new DateTime(2053, 10, 2),
                    DueDate = new DateTime(2053, 11, 2),
                    TotalAmount = 34200.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 359,
                    CustomerId = 35,
                    ContractId = 80,
                    DateIssued = new DateTime(2053, 11, 3),
                    DueDate = new DateTime(2053, 12, 3),
                    TotalAmount = 34300.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 360,
                    CustomerId = 86,
                    ContractId = 17,
                    DateIssued = new DateTime(2053, 12, 4),
                    DueDate = new DateTime(2054, 1, 4),
                    TotalAmount = 34400.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 361,
                    CustomerId = 4,
                    ContractId = 1,
                    DateIssued = new DateTime(2054, 1, 5),
                    DueDate = new DateTime(2054, 2, 5),
                    TotalAmount = 34500.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 362,
                    CustomerId = 41,
                    ContractId = 2,
                    DateIssued = new DateTime(2054, 2, 6),
                    DueDate = new DateTime(2054, 3, 6),
                    TotalAmount = 34600.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 363,
                    CustomerId = 14,
                    ContractId = 3,
                    DateIssued = new DateTime(2054, 3, 7),
                    DueDate = new DateTime(2054, 4, 7),
                    TotalAmount = 34700.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 364,
                    CustomerId = 9,
                    ContractId = 4,
                    DateIssued = new DateTime(2054, 4, 8),
                    DueDate = new DateTime(2054, 5, 8),
                    TotalAmount = 34800.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 365,
                    CustomerId = 27,
                    ContractId = 5,
                    DateIssued = new DateTime(2054, 5, 9),
                    DueDate = new DateTime(2054, 6, 9),
                    TotalAmount = 34900.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 366,
                    CustomerId = 25,
                    ContractId = 14,
                    DateIssued = new DateTime(2054, 6, 10),
                    DueDate = new DateTime(2054, 7, 10),
                    TotalAmount = 35000.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 367,
                    CustomerId = 46,
                    ContractId = 19,
                    DateIssued = new DateTime(2054, 7, 11),
                    DueDate = new DateTime(2054, 8, 11),
                    TotalAmount = 35100.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 368,
                    CustomerId = 7,
                    ContractId = 7,
                    DateIssued = new DateTime(2054, 8, 12),
                    DueDate = new DateTime(2054, 9, 12),
                    TotalAmount = 35200.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 369,
                    CustomerId = 17,
                    ContractId = 15,
                    DateIssued = new DateTime(2054, 9, 13),
                    DueDate = new DateTime(2054, 10, 13),
                    TotalAmount = 35300.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 370,
                    CustomerId = 73,
                    ContractId = 36,
                    DateIssued = new DateTime(2054, 10, 14),
                    DueDate = new DateTime(2054, 11, 14),
                    TotalAmount = 35400.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 371,
                    CustomerId = 18,
                    ContractId = 12,
                    DateIssued = new DateTime(2054, 11, 15),
                    DueDate = new DateTime(2054, 12, 15),
                    TotalAmount = 35500.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 372,
                    CustomerId = 5,
                    ContractId = 26,
                    DateIssued = new DateTime(2054, 12, 16),
                    DueDate = new DateTime(2055, 1, 16),
                    TotalAmount = 35600.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 373,
                    CustomerId = 59,
                    ContractId = 28,
                    DateIssued = new DateTime(2055, 1, 17),
                    DueDate = new DateTime(2055, 2, 17),
                    TotalAmount = 35700.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 374,
                    CustomerId = 68,
                    ContractId = 10,
                    DateIssued = new DateTime(2055, 2, 18),
                    DueDate = new DateTime(2055, 3, 18),
                    TotalAmount = 35800.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 375,
                    CustomerId = 11,
                    ContractId = 35,
                    DateIssued = new DateTime(2055, 3, 19),
                    DueDate = new DateTime(2055, 4, 19),
                    TotalAmount = 35900.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 376,
                    CustomerId = 41,
                    ContractId = 55,
                    DateIssued = new DateTime(2055, 4, 20),
                    DueDate = new DateTime(2055, 5, 20),
                    TotalAmount = 36000.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 377,
                    CustomerId = 30,
                    ContractId = 8,
                    DateIssued = new DateTime(2055, 5, 21),
                    DueDate = new DateTime(2055, 6, 21),
                    TotalAmount = 36100.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 378,
                    CustomerId = 20,
                    ContractId = 14,
                    DateIssued = new DateTime(2055, 6, 22),
                    DueDate = new DateTime(2055, 7, 22),
                    TotalAmount = 36200.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 379,
                    CustomerId = 39,
                    ContractId = 17,
                    DateIssued = new DateTime(2055, 7, 23),
                    DueDate = new DateTime(2055, 8, 23),
                    TotalAmount = 36300.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 380,
                    CustomerId = 61,
                    ContractId = 19,
                    DateIssued = new DateTime(2055, 8, 24),
                    DueDate = new DateTime(2055, 9, 24),
                    TotalAmount = 36400.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 381,
                    CustomerId = 88,
                    ContractId = 27,
                    DateIssued = new DateTime(2055, 9, 25),
                    DueDate = new DateTime(2055, 10, 25),
                    TotalAmount = 36500.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 382,
                    CustomerId = 49,
                    ContractId = 32,
                    DateIssued = new DateTime(2055, 10, 26),
                    DueDate = new DateTime(2055, 11, 26),
                    TotalAmount = 36600.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 383,
                    CustomerId = 74,
                    ContractId = 42,
                    DateIssued = new DateTime(2055, 11, 27),
                    DueDate = new DateTime(2055, 12, 27),
                    TotalAmount = 36700.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 384,
                    CustomerId = 66,
                    ContractId = 57,
                    DateIssued = new DateTime(2055, 12, 28),
                    DueDate = new DateTime(2056, 1, 28),
                    TotalAmount = 36800.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 385,
                    CustomerId = 12,
                    ContractId = 11,
                    DateIssued = new DateTime(2056, 1, 29),
                    DueDate = new DateTime(2056, 2, 29),
                    TotalAmount = 36900.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 386,
                    CustomerId = 63,
                    ContractId = 3,
                    DateIssued = new DateTime(2056, 2, 1),
                    DueDate = new DateTime(2056, 3, 1),
                    TotalAmount = 37000.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 387,
                    CustomerId = 83,
                    ContractId = 4,
                    DateIssued = new DateTime(2056, 3, 2),
                    DueDate = new DateTime(2056, 4, 2),
                    TotalAmount = 37100.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 388,
                    CustomerId = 53,
                    ContractId = 19,
                    DateIssued = new DateTime(2056, 4, 3),
                    DueDate = new DateTime(2056, 5, 3),
                    TotalAmount = 37200.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 389,
                    CustomerId = 1,
                    ContractId = 22,
                    DateIssued = new DateTime(2056, 5, 4),
                    DueDate = new DateTime(2056, 6, 4),
                    TotalAmount = 37300.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 390,
                    CustomerId = 36,
                    ContractId = 38,
                    DateIssued = new DateTime(2056, 6, 5),
                    DueDate = new DateTime(2056, 7, 5),
                    TotalAmount = 37400.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 391,
                    CustomerId = 47,
                    ContractId = 12,
                    DateIssued = new DateTime(2056, 7, 6),
                    DueDate = new DateTime(2056, 8, 6),
                    TotalAmount = 37500.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 392,
                    CustomerId = 19,
                    ContractId = 6,
                    DateIssued = new DateTime(2056, 8, 7),
                    DueDate = new DateTime(2056, 9, 7),
                    TotalAmount = 37600.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 393,
                    CustomerId = 18,
                    ContractId = 26,
                    DateIssued = new DateTime(2056, 9, 8),
                    DueDate = new DateTime(2056, 10, 8),
                    TotalAmount = 37700.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 394,
                    CustomerId = 73,
                    ContractId = 18,
                    DateIssued = new DateTime(2056, 10, 9),
                    DueDate = new DateTime(2056, 11, 9),
                    TotalAmount = 37800.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 395,
                    CustomerId = 24,
                    ContractId = 1,
                    DateIssued = new DateTime(2056, 11, 10),
                    DueDate = new DateTime(2056, 12, 10),
                    TotalAmount = 37900.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 396,
                    CustomerId = 29,
                    ContractId = 3,
                    DateIssued = new DateTime(2056, 12, 11),
                    DueDate = new DateTime(2057, 1, 11),
                    TotalAmount = 38000.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 397,
                    CustomerId = 42,
                    ContractId = 7,
                    DateIssued = new DateTime(2057, 1, 12),
                    DueDate = new DateTime(2057, 2, 12),
                    TotalAmount = 38100.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 398,
                    CustomerId = 34,
                    ContractId = 9,
                    DateIssued = new DateTime(2057, 2, 13),
                    DueDate = new DateTime(2057, 3, 13),
                    TotalAmount = 38200.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 399,
                    CustomerId = 76,
                    ContractId = 11,
                    DateIssued = new DateTime(2057, 3, 14),
                    DueDate = new DateTime(2057, 4, 14),
                    TotalAmount = 38300.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 400,
                    CustomerId = 88,
                    ContractId = 14,
                    DateIssued = new DateTime(2057, 4, 15),
                    DueDate = new DateTime(2057, 5, 15),
                    TotalAmount = 38400.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 401,
                    CustomerId = 2,
                    ContractId = 5,
                    DateIssued = new DateTime(2057, 5, 16),
                    DueDate = new DateTime(2057, 6, 16),
                    TotalAmount = 38500.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 402,
                    CustomerId = 27,
                    ContractId = 8,
                    DateIssued = new DateTime(2057, 6, 17),
                    DueDate = new DateTime(2057, 7, 17),
                    TotalAmount = 38600.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 403,
                    CustomerId = 54,
                    ContractId = 12,
                    DateIssued = new DateTime(2057, 7, 18),
                    DueDate = new DateTime(2057, 8, 18),
                    TotalAmount = 38700.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 404,
                    CustomerId = 8,
                    ContractId = 6,
                    DateIssued = new DateTime(2057, 8, 19),
                    DueDate = new DateTime(2057, 9, 19),
                    TotalAmount = 38800.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 405,
                    CustomerId = 13,
                    ContractId = 10,
                    DateIssued = new DateTime(2057, 9, 20),
                    DueDate = new DateTime(2057, 10, 20),
                    TotalAmount = 38900.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 406,
                    CustomerId = 37,
                    ContractId = 15,
                    DateIssued = new DateTime(2057, 10, 21),
                    DueDate = new DateTime(2057, 11, 21),
                    TotalAmount = 39000.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 407,
                    CustomerId = 61,
                    ContractId = 7,
                    DateIssued = new DateTime(2057, 11, 22),
                    DueDate = new DateTime(2057, 12, 22),
                    TotalAmount = 39100.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 408,
                    CustomerId = 9,
                    ContractId = 4,
                    DateIssued = new DateTime(2057, 12, 23),
                    DueDate = new DateTime(2058, 1, 23),
                    TotalAmount = 39200.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 409,
                    CustomerId = 16,
                    ContractId = 3,
                    DateIssued = new DateTime(2058, 1, 24),
                    DueDate = new DateTime(2058, 2, 24),
                    TotalAmount = 39300.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 410,
                    CustomerId = 22,
                    ContractId = 2,
                    DateIssued = new DateTime(2058, 2, 25),
                    DueDate = new DateTime(2058, 3, 25),
                    TotalAmount = 39400.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 411,
                    CustomerId = 70,
                    ContractId = 14,
                    DateIssued = new DateTime(2058, 3, 26),
                    DueDate = new DateTime(2058, 4, 26),
                    TotalAmount = 39500.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 412,
                    CustomerId = 47,
                    ContractId = 11,
                    DateIssued = new DateTime(2058, 4, 27),
                    DueDate = new DateTime(2058, 5, 27),
                    TotalAmount = 39600.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 413,
                    CustomerId = 78,
                    ContractId = 5,
                    DateIssued = new DateTime(2058, 5, 28),
                    DueDate = new DateTime(2058, 6, 28),
                    TotalAmount = 39700.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 414,
                    CustomerId = 56,
                    ContractId = 8,
                    DateIssued = new DateTime(2058, 6, 29),
                    DueDate = new DateTime(2058, 7, 29),
                    TotalAmount = 39800.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 415,
                    CustomerId = 34,
                    ContractId = 20,
                    DateIssued = new DateTime(2058, 7, 30),
                    DueDate = new DateTime(2058, 8, 30),
                    TotalAmount = 39900.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 416,
                    CustomerId = 12,
                    ContractId = 22,
                    DateIssued = new DateTime(2058, 8, 31),
                    DueDate = new DateTime(2058, 9, 30),
                    TotalAmount = 40000.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 417,
                    CustomerId = 48,
                    ContractId = 25,
                    DateIssued = new DateTime(2058, 9, 1),
                    DueDate = new DateTime(2058, 10, 1),
                    TotalAmount = 40100.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 418,
                    CustomerId = 85,
                    ContractId = 6,
                    DateIssued = new DateTime(2058, 10, 2),
                    DueDate = new DateTime(2058, 11, 2),
                    TotalAmount = 40200.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 419,
                    CustomerId = 63,
                    ContractId = 30,
                    DateIssued = new DateTime(2058, 11, 3),
                    DueDate = new DateTime(2058, 12, 3),
                    TotalAmount = 40300.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 420,
                    CustomerId = 40,
                    ContractId = 18,
                    DateIssued = new DateTime(2058, 12, 4),
                    DueDate = new DateTime(2059, 1, 4),
                    TotalAmount = 40400.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 421,
                    CustomerId = 26,
                    ContractId = 3,
                    DateIssued = new DateTime(2059, 1, 5),
                    DueDate = new DateTime(2059, 2, 5),
                    TotalAmount = 40501.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 422,
                    CustomerId = 35,
                    ContractId = 8,
                    DateIssued = new DateTime(2059, 2, 6),
                    DueDate = new DateTime(2059, 3, 6),
                    TotalAmount = 40602.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 423,
                    CustomerId = 71,
                    ContractId = 15,
                    DateIssued = new DateTime(2059, 3, 7),
                    DueDate = new DateTime(2059, 4, 7),
                    TotalAmount = 40703.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 424,
                    CustomerId = 29,
                    ContractId = 12,
                    DateIssued = new DateTime(2059, 4, 8),
                    DueDate = new DateTime(2059, 5, 8),
                    TotalAmount = 40804.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 425,
                    CustomerId = 88,
                    ContractId = 20,
                    DateIssued = new DateTime(2059, 5, 9),
                    DueDate = new DateTime(2059, 6, 9),
                    TotalAmount = 40905.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 426,
                    CustomerId = 14,
                    ContractId = 4,
                    DateIssued = new DateTime(2059, 6, 10),
                    DueDate = new DateTime(2059, 7, 10),
                    TotalAmount = 41006.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 427,
                    CustomerId = 41,
                    ContractId = 9,
                    DateIssued = new DateTime(2059, 7, 11),
                    DueDate = new DateTime(2059, 8, 11),
                    TotalAmount = 41107.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 428,
                    CustomerId = 55,
                    ContractId = 18,
                    DateIssued = new DateTime(2059, 8, 12),
                    DueDate = new DateTime(2059, 9, 12),
                    TotalAmount = 41208.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 429,
                    CustomerId = 67,
                    ContractId = 5,
                    DateIssued = new DateTime(2059, 9, 13),
                    DueDate = new DateTime(2059, 10, 13),
                    TotalAmount = 41309.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 430,
                    CustomerId = 2,
                    ContractId = 3,
                    DateIssued = new DateTime(2059, 10, 14),
                    DueDate = new DateTime(2059, 11, 14),
                    TotalAmount = 41410.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 431,
                    CustomerId = 46,
                    ContractId = 6,
                    DateIssued = new DateTime(2059, 11, 15),
                    DueDate = new DateTime(2059, 12, 15),
                    TotalAmount = 41511.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 432,
                    CustomerId = 31,
                    ContractId = 11,
                    DateIssued = new DateTime(2059, 12, 16),
                    DueDate = new DateTime(2060, 1, 16),
                    TotalAmount = 41612.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 433,
                    CustomerId = 36,
                    ContractId = 10,
                    DateIssued = new DateTime(2060, 1, 17),
                    DueDate = new DateTime(2060, 2, 17),
                    TotalAmount = 41713.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 434,
                    CustomerId = 58,
                    ContractId = 15,
                    DateIssued = new DateTime(2060, 2, 18),
                    DueDate = new DateTime(2060, 3, 18),
                    TotalAmount = 41814.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 435,
                    CustomerId = 12,
                    ContractId = 12,
                    DateIssued = new DateTime(2060, 3, 19),
                    DueDate = new DateTime(2060, 4, 19),
                    TotalAmount = 41915.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 436,
                    CustomerId = 70,
                    ContractId = 4,
                    DateIssued = new DateTime(2060, 4, 20),
                    DueDate = new DateTime(2060, 5, 20),
                    TotalAmount = 42016.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 437,
                    CustomerId = 74,
                    ContractId = 9,
                    DateIssued = new DateTime(2060, 5, 21),
                    DueDate = new DateTime(2060, 6, 21),
                    TotalAmount = 42117.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 438,
                    CustomerId = 69,
                    ContractId = 3,
                    DateIssued = new DateTime(2060, 6, 22),
                    DueDate = new DateTime(2060, 7, 22),
                    TotalAmount = 42218.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 439,
                    CustomerId = 10,
                    ContractId = 6,
                    DateIssued = new DateTime(2060, 7, 23),
                    DueDate = new DateTime(2060, 8, 23),
                    TotalAmount = 42319.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 440,
                    CustomerId = 19,
                    ContractId = 14,
                    DateIssued = new DateTime(2060, 8, 24),
                    DueDate = new DateTime(2060, 9, 24),
                    TotalAmount = 42420.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 441,
                    CustomerId = 15,
                    ContractId = 7,
                    DateIssued = new DateTime(2060, 9, 25),
                    DueDate = new DateTime(2060, 10, 25),
                    TotalAmount = 42521.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 442,
                    CustomerId = 82,
                    ContractId = 2,
                    DateIssued = new DateTime(2060, 10, 26),
                    DueDate = new DateTime(2060, 11, 26),
                    TotalAmount = 42622.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 443,
                    CustomerId = 30,
                    ContractId = 1,
                    DateIssued = new DateTime(2060, 11, 27),
                    DueDate = new DateTime(2060, 12, 27),
                    TotalAmount = 42723.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 444,
                    CustomerId = 64,
                    ContractId = 3,
                    DateIssued = new DateTime(2060, 12, 28),
                    DueDate = new DateTime(2061, 1, 28),
                    TotalAmount = 42824.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 445,
                    CustomerId = 87,
                    ContractId = 5,
                    DateIssued = new DateTime(2061, 1, 29),
                    DueDate = new DateTime(2061, 2, 28),
                    TotalAmount = 42925.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 446,
                    CustomerId = 4,
                    ContractId = 10,
                    DateIssued = new DateTime(2061, 2, 1),
                    DueDate = new DateTime(2061, 3, 1),
                    TotalAmount = 43026.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 447,
                    CustomerId = 39,
                    ContractId = 12,
                    DateIssued = new DateTime(2061, 3, 2),
                    DueDate = new DateTime(2061, 4, 2),
                    TotalAmount = 43127.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 448,
                    CustomerId = 51,
                    ContractId = 18,
                    DateIssued = new DateTime(2061, 4, 3),
                    DueDate = new DateTime(2061, 5, 3),
                    TotalAmount = 43228.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 449,
                    CustomerId = 18,
                    ContractId = 20,
                    DateIssued = new DateTime(2061, 5, 4),
                    DueDate = new DateTime(2061, 6, 4),
                    TotalAmount = 43329.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 450,
                    CustomerId = 72,
                    ContractId = 14,
                    DateIssued = new DateTime(2061, 6, 5),
                    DueDate = new DateTime(2061, 7, 5),
                    TotalAmount = 43430.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 451,
                    CustomerId = 44,
                    ContractId = 8,
                    DateIssued = new DateTime(2061, 7, 6),
                    DueDate = new DateTime(2061, 8, 6),
                    TotalAmount = 43531.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 452,
                    CustomerId = 7,
                    ContractId = 16,
                    DateIssued = new DateTime(2061, 8, 7),
                    DueDate = new DateTime(2061, 9, 7),
                    TotalAmount = 43632.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 453,
                    CustomerId = 60,
                    ContractId = 11,
                    DateIssued = new DateTime(2061, 9, 8),
                    DueDate = new DateTime(2061, 10, 8),
                    TotalAmount = 43733.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 454,
                    CustomerId = 1,
                    ContractId = 17,
                    DateIssued = new DateTime(2061, 10, 9),
                    DueDate = new DateTime(2061, 11, 9),
                    TotalAmount = 43834.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 455,
                    CustomerId = 26,
                    ContractId = 3,
                    DateIssued = new DateTime(2061, 11, 10),
                    DueDate = new DateTime(2061, 12, 10),
                    TotalAmount = 43935.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 456,
                    CustomerId = 57,
                    ContractId = 15,
                    DateIssued = new DateTime(2061, 12, 11),
                    DueDate = new DateTime(2062, 1, 11),
                    TotalAmount = 44036.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 457,
                    CustomerId = 75,
                    ContractId = 9,
                    DateIssued = new DateTime(2062, 1, 12),
                    DueDate = new DateTime(2062, 2, 12),
                    TotalAmount = 44137.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 458,
                    CustomerId = 33,
                    ContractId = 6,
                    DateIssued = new DateTime(2062, 2, 13),
                    DueDate = new DateTime(2062, 3, 13),
                    TotalAmount = 44238.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 459,
                    CustomerId = 19,
                    ContractId = 12,
                    DateIssued = new DateTime(2062, 3, 14),
                    DueDate = new DateTime(2062, 4, 14),
                    TotalAmount = 44339.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 460,
                    CustomerId = 11,
                    ContractId = 2,
                    DateIssued = new DateTime(2062, 4, 15),
                    DueDate = new DateTime(2062, 5, 15),
                    TotalAmount = 44440.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 461,
                    CustomerId = 28,
                    ContractId = 7,
                    DateIssued = new DateTime(2062, 5, 16),
                    DueDate = new DateTime(2062, 6, 16),
                    TotalAmount = 44541.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 462,
                    CustomerId = 72,
                    ContractId = 8,
                    DateIssued = new DateTime(2062, 6, 17),
                    DueDate = new DateTime(2062, 7, 17),
                    TotalAmount = 44642.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 463,
                    CustomerId = 38,
                    ContractId = 5,
                    DateIssued = new DateTime(2062, 7, 18),
                    DueDate = new DateTime(2062, 8, 18),
                    TotalAmount = 44743.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 464,
                    CustomerId = 22,
                    ContractId = 3,
                    DateIssued = new DateTime(2062, 8, 19),
                    DueDate = new DateTime(2062, 9, 19),
                    TotalAmount = 44844.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 465,
                    CustomerId = 14,
                    ContractId = 12,
                    DateIssued = new DateTime(2062, 9, 20),
                    DueDate = new DateTime(2062, 10, 20),
                    TotalAmount = 44945.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 466,
                    CustomerId = 35,
                    ContractId = 11,
                    DateIssued = new DateTime(2062, 10, 21),
                    DueDate = new DateTime(2062, 11, 21),
                    TotalAmount = 45046.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 467,
                    CustomerId = 84,
                    ContractId = 9,
                    DateIssued = new DateTime(2062, 11, 22),
                    DueDate = new DateTime(2062, 12, 22),
                    TotalAmount = 45147.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 468,
                    CustomerId = 57,
                    ContractId = 8,
                    DateIssued = new DateTime(2062, 12, 23),
                    DueDate = new DateTime(2063, 1, 23),
                    TotalAmount = 45248.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 469,
                    CustomerId = 13,
                    ContractId = 4,
                    DateIssued = new DateTime(2063, 1, 24),
                    DueDate = new DateTime(2063, 2, 24),
                    TotalAmount = 45349.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 470,
                    CustomerId = 39,
                    ContractId = 6,
                    DateIssued = new DateTime(2063, 2, 25),
                    DueDate = new DateTime(2063, 3, 25),
                    TotalAmount = 45450.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 471,
                    CustomerId = 71,
                    ContractId = 2,
                    DateIssued = new DateTime(2063, 3, 26),
                    DueDate = new DateTime(2063, 4, 26),
                    TotalAmount = 45551.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 472,
                    CustomerId = 18,
                    ContractId = 1,
                    DateIssued = new DateTime(2063, 4, 27),
                    DueDate = new DateTime(2063, 5, 27),
                    TotalAmount = 45652.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 473,
                    CustomerId = 9,
                    ContractId = 14,
                    DateIssued = new DateTime(2063, 5, 28),
                    DueDate = new DateTime(2063, 6, 28),
                    TotalAmount = 45753.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 474,
                    CustomerId = 40,
                    ContractId = 15,
                    DateIssued = new DateTime(2063, 6, 29),
                    DueDate = new DateTime(2063, 7, 29),
                    TotalAmount = 45854.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 475,
                    CustomerId = 85,
                    ContractId = 7,
                    DateIssued = new DateTime(2063, 7, 30),
                    DueDate = new DateTime(2063, 8, 30),
                    TotalAmount = 45955.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 476,
                    CustomerId = 44,
                    ContractId = 3,
                    DateIssued = new DateTime(2063, 8, 31),
                    DueDate = new DateTime(2063, 9, 30),
                    TotalAmount = 46056.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 477,
                    CustomerId = 26,
                    ContractId = 10,
                    DateIssued = new DateTime(2063, 9, 1),
                    DueDate = new DateTime(2063, 10, 1),
                    TotalAmount = 46157.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 478,
                    CustomerId = 47,
                    ContractId = 12,
                    DateIssued = new DateTime(2063, 10, 2),
                    DueDate = new DateTime(2063, 11, 2),
                    TotalAmount = 46258.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 479,
                    CustomerId = 61,
                    ContractId = 4,
                    DateIssued = new DateTime(2063, 11, 3),
                    DueDate = new DateTime(2063, 12, 3),
                    TotalAmount = 46359.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 480,
                    CustomerId = 36,
                    ContractId = 6,
                    DateIssued = new DateTime(2063, 12, 4),
                    DueDate = new DateTime(2064, 1, 4),
                    TotalAmount = 46460.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 481,
                    CustomerId = 73,
                    ContractId = 1,
                    DateIssued = new DateTime(2064, 1, 5),
                    DueDate = new DateTime(2064, 2, 5),
                    TotalAmount = 46561.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 482,
                    CustomerId = 24,
                    ContractId = 3,
                    DateIssued = new DateTime(2064, 2, 6),
                    DueDate = new DateTime(2064, 3, 6),
                    TotalAmount = 46662.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 483,
                    CustomerId = 49,
                    ContractId = 5,
                    DateIssued = new DateTime(2064, 3, 7),
                    DueDate = new DateTime(2064, 4, 7),
                    TotalAmount = 46763.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 484,
                    CustomerId = 8,
                    ContractId = 14,
                    DateIssued = new DateTime(2064, 4, 8),
                    DueDate = new DateTime(2064, 5, 8),
                    TotalAmount = 46864.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 485,
                    CustomerId = 45,
                    ContractId = 8,
                    DateIssued = new DateTime(2064, 5, 9),
                    DueDate = new DateTime(2064, 6, 9),
                    TotalAmount = 46965.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 486,
                    CustomerId = 10,
                    ContractId = 10,
                    DateIssued = new DateTime(2064, 6, 10),
                    DueDate = new DateTime(2064, 7, 10),
                    TotalAmount = 47066.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 487,
                    CustomerId = 37,
                    ContractId = 12,
                    DateIssued = new DateTime(2064, 7, 11),
                    DueDate = new DateTime(2064, 8, 11),
                    TotalAmount = 47167.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 488,
                    CustomerId = 66,
                    ContractId = 9,
                    DateIssued = new DateTime(2064, 8, 12),
                    DueDate = new DateTime(2064, 9, 12),
                    TotalAmount = 47268.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 489,
                    CustomerId = 78,
                    ContractId = 1,
                    DateIssued = new DateTime(2064, 9, 13),
                    DueDate = new DateTime(2064, 10, 13),
                    TotalAmount = 47369.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 490,
                    CustomerId = 50,
                    ContractId = 7,
                    DateIssued = new DateTime(2064, 10, 14),
                    DueDate = new DateTime(2064, 11, 14),
                    TotalAmount = 47470.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 491,
                    CustomerId = 5,
                    ContractId = 2,
                    DateIssued = new DateTime(2064, 11, 15),
                    DueDate = new DateTime(2064, 12, 15),
                    TotalAmount = 47571.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 492,
                    CustomerId = 63,
                    ContractId = 3,
                    DateIssued = new DateTime(2064, 12, 16),
                    DueDate = new DateTime(2065, 1, 16),
                    TotalAmount = 47672.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 493,
                    CustomerId = 77,
                    ContractId = 4,
                    DateIssued = new DateTime(2065, 1, 17),
                    DueDate = new DateTime(2065, 2, 17),
                    TotalAmount = 47773.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 494,
                    CustomerId = 21,
                    ContractId = 6,
                    DateIssued = new DateTime(2065, 2, 18),
                    DueDate = new DateTime(2065, 3, 18),
                    TotalAmount = 47874.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 495,
                    CustomerId = 62,
                    ContractId = 8,
                    DateIssued = new DateTime(2065, 3, 19),
                    DueDate = new DateTime(2065, 4, 19),
                    TotalAmount = 47975.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 496,
                    CustomerId = 80,
                    ContractId = 1,
                    DateIssued = new DateTime(2065, 4, 20),
                    DueDate = new DateTime(2065, 5, 20),
                    TotalAmount = 48076.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 497,
                    CustomerId = 16,
                    ContractId = 5,
                    DateIssued = new DateTime(2065, 5, 21),
                    DueDate = new DateTime(2065, 6, 21),
                    TotalAmount = 48177.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 498,
                    CustomerId = 53,
                    ContractId = 7,
                    DateIssued = new DateTime(2065, 6, 22),
                    DueDate = new DateTime(2065, 7, 22),
                    TotalAmount = 48278.00M,
                    IsPaid = false
                },
                new Invoice
                {
                    Id = 499,
                    CustomerId = 25,
                    ContractId = 9,
                    DateIssued = new DateTime(2065, 7, 23),
                    DueDate = new DateTime(2065, 8, 23),
                    TotalAmount = 48379.00M,
                    IsPaid = true
                },
                new Invoice
                {
                    Id = 500,
                    CustomerId = 34,
                    ContractId = 10,
                    DateIssued = new DateTime(2065, 8, 24),
                    DueDate = new DateTime(2065, 9, 24),
                    TotalAmount = 48480.00M,
                    IsPaid = false
                } */
            );

            modelBuilder.Entity<IncendentReport>().HasData(
                new IncendentReport
                {
                    Id = 1,
                    CustomerId = 1,
                    DateReported = new DateTime(2024, 1, 10),
                    InitialMessage = "Koffieautomaat start niet op.",
                    CoffeeMachineType = "Barroc Intens Italian Light",
                    FaultCode = "E01",
                    IsResolved = false,
                    FollowUp = null,
                    IncidentDescription = "De koffieautomaat reageert niet op de aan/uit-knop."
                },
                new IncendentReport
                {
                    Id = 2,
                    CustomerId = 2,
                    DateReported = new DateTime(2024, 1, 12),
                    InitialMessage = "Er komt geen water uit de machine.",
                    CoffeeMachineType = "Barroc Intens Italian",
                    FaultCode = "E02",
                    IsResolved = true,
                    FollowUp = "Watervoorziening gecontroleerd, probleem opgelost.",
                    IncidentDescription = "De waterpomp leek defect, maar het bleek een verstopte waterfilter te zijn."
                },
                new IncendentReport
                {
                    Id = 3,
                    CustomerId = 3,
                    DateReported = new DateTime(2024, 1, 15),
                    InitialMessage = "Koffie smaakt vreemd.",
                    CoffeeMachineType = "Barroc Intens Italian Deluxe",
                    FaultCode = "E03",
                    IsResolved = false,
                    FollowUp = null,
                    IncidentDescription = "Klant meldt dat de koffie niet goed smaakt. Mogelijk defecte onderdelen."
                },
                new IncendentReport
                {
                    Id = 4,
                    CustomerId = 4,
                    DateReported = new DateTime(2024, 1, 20),
                    InitialMessage = "Machine maakt een raar geluid.",
                    CoffeeMachineType = "Barroc Intens Italian Deluxe Special",
                    FaultCode = "E04",
                    IsResolved = true,
                    FollowUp = "Reservoir sensor vervangen.",
                    IncidentDescription = "De machine maakt een schurend geluid. Sensor was defect en is vervangen."
                }/*
                new IncendentReport
                {
                    Id = 5,
                    CustomerId = 5,
                    DateReported = new DateTime(2024, 1, 22),
                    InitialMessage = "Koffieautomaat lekt water.",
                    CoffeeMachineType = "Barroc Intens Italian",
                    FaultCode = "E05",
                    IsResolved = false,
                    FollowUp = null,
                    IncidentDescription = "De koffieautomaat vertoont lekkage onderaan."
                },
                new IncendentReport
                {
                    Id = 6,
                    CustomerId = 6,
                    DateReported = new DateTime(2024, 1, 25),
                    InitialMessage = "Koffie komt niet uit de uitloop.",
                    CoffeeMachineType = "Barroc Intens Italian Light",
                    FaultCode = "E06",
                    IsResolved = true,
                    FollowUp = "Reiniging van de uitloop uitgevoerd.",
                    IncidentDescription = "De uitloop was verstopt door koffiedik."
                },
                new IncendentReport
                {
                    Id = 7,
                    CustomerId = 7,
                    DateReported = new DateTime(2024, 1, 28),
                    InitialMessage = "Machine geeft een foutmelding.",
                    CoffeeMachineType = "Barroc Intens Italian Deluxe",
                    FaultCode = "E07",
                    IsResolved = false,
                    FollowUp = null,
                    IncidentDescription = "De machine geeft foutcode E07 weer tijdens gebruik."
                },
                new IncendentReport
                {
                    Id = 8,
                    CustomerId = 8,
                    DateReported = new DateTime(2024, 2, 1),
                    InitialMessage = "Koffieautomaat maakt te veel lawaai.",
                    CoffeeMachineType = "Barroc Intens Italian",
                    FaultCode = "E08",
                    IsResolved = true,
                    FollowUp = "Motor vervangen.",
                    IncidentDescription = "De motor van de koffieautomaat was defect en is vervangen."
                },
                new IncendentReport
                {
                    Id = 9,
                    CustomerId = 9,
                    DateReported = new DateTime(2024, 2, 3),
                    InitialMessage = "Koffieautomaat slaat af tijdens gebruik.",
                    CoffeeMachineType = "Barroc Intens Italian Light",
                    FaultCode = "E09",
                    IsResolved = false,
                    FollowUp = null,
                    IncidentDescription = "De machine stopt na enkele seconden met het zetten van koffie."
                },
                new IncendentReport
                {
                    Id = 10,
                    CustomerId = 10,
                    DateReported = new DateTime(2024, 2, 5),
                    InitialMessage = "Geen stroom naar de machine.",
                    CoffeeMachineType = "Barroc Intens Italian Deluxe",
                    FaultCode = "E10",
                    IsResolved = true,
                    FollowUp = "Stroomkabel vervangen.",
                    IncidentDescription = "De stroomkabel was defect."
                },
                new IncendentReport
                {
                    Id = 11,
                    CustomerId = 11,
                    DateReported = new DateTime(2024, 2, 7),
                    InitialMessage = "Koffieautomaat warmt niet op.",
                    CoffeeMachineType = "Barroc Intens Italian",
                    FaultCode = "E11",
                    IsResolved = false,
                    FollowUp = null,
                    IncidentDescription = "De machine warmt niet op en kan geen koffie zetten."
                },
                new IncendentReport
                {
                    Id = 12,
                    CustomerId = 12,
                    DateReported = new DateTime(2024, 2, 10),
                    InitialMessage = "Koffieautomaat geeft te weinig koffie.",
                    CoffeeMachineType = "Barroc Intens Italian Light",
                    FaultCode = "E12",
                    IsResolved = true,
                    FollowUp = "Instellingen gecorrigeerd.",
                    IncidentDescription = "De instellingen voor koffiesterkte waren verkeerd."
                },
                new IncendentReport
                {
                    Id = 13,
                    CustomerId = 13,
                    DateReported = new DateTime(2024, 2, 12),
                    InitialMessage = "Er is een brandlucht.",
                    CoffeeMachineType = "Barroc Intens Italian Deluxe",
                    FaultCode = "E13",
                    IsResolved = false,
                    FollowUp = null,
                    IncidentDescription = "Er is een brandlucht waarneembaar bij gebruik."
                },
                new IncendentReport
                {
                    Id = 14,
                    CustomerId = 14,
                    DateReported = new DateTime(2024, 2, 15),
                    InitialMessage = "Koffieautomaat maakt een schurend geluid.",
                    CoffeeMachineType = "Barroc Intens Italian",
                    FaultCode = "E14",
                    IsResolved = true,
                    FollowUp = "Onderdeel gesmeerd.",
                    IncidentDescription = "Een onderdeel van de machine had gebrek aan smeermiddel."
                },
                new IncendentReport
                {
                    Id = 15,
                    CustomerId = 15,
                    DateReported = new DateTime(2024, 2, 18),
                    InitialMessage = "Koffieautomaat kan niet worden gestart.",
                    CoffeeMachineType = "Barroc Intens Italian Light",
                    FaultCode = "E15",
                    IsResolved = false,
                    FollowUp = null,
                    IncidentDescription = "De aan/uit-knop reageert niet."
                },
                new IncendentReport
                {
                    Id = 16,
                    CustomerId = 16,
                    DateReported = new DateTime(2024, 2, 20),
                    InitialMessage = "Koffieautomaat zet geen koffie.",
                    CoffeeMachineType = "Barroc Intens Italian Deluxe",
                    FaultCode = "E16",
                    IsResolved = true,
                    FollowUp = "Reservoir gereinigd.",
                    IncidentDescription = "Het waterreservoir was verstopt."
                },
                new IncendentReport
                {
                    Id = 17,
                    CustomerId = 17,
                    DateReported = new DateTime(2024, 2, 22),
                    InitialMessage = "Koffie komt met vertraging.",
                    CoffeeMachineType = "Barroc Intens Italian",
                    FaultCode = "E17",
                    IsResolved = false,
                    FollowUp = null,
                    IncidentDescription = "De koffie komt met vertraging uit de machine."
                },
                new IncendentReport
                {
                    Id = 18,
                    CustomerId = 18,
                    DateReported = new DateTime(2024, 2, 25),
                    InitialMessage = "Koffieautomaat geeft geen foutmelding.",
                    CoffeeMachineType = "Barroc Intens Italian Light",
                    FaultCode = "E18",
                    IsResolved = true,
                    FollowUp = "Diagnose uitgevoerd, alles werkt nu.",
                    IncidentDescription = "De machine leek niet goed te functioneren, maar er was geen foutmelding."
                },
                new IncendentReport
                {
                    Id = 19,
                    CustomerId = 19,
                    DateReported = new DateTime(2024, 3, 1),
                    InitialMessage = "Koffieautomaat lekt aan de zijkant.",
                    CoffeeMachineType = "Barroc Intens Italian Deluxe",
                    FaultCode = "E19",
                    IsResolved = false,
                    FollowUp = null,
                    IncidentDescription = "Er is water zichtbaar aan de zijkant van de machine."
                },
                new IncendentReport
                {
                    Id = 20,
                    CustomerId = 20,
                    DateReported = new DateTime(2024, 3, 3),
                    InitialMessage = "Koffieautomaat kan geen warme dranken zetten.",
                    CoffeeMachineType = "Barroc Intens Italian",
                    FaultCode = "E20",
                    IsResolved = true,
                    FollowUp = "Verwarmingselement vervangen.",
                    IncidentDescription = "Het verwarmingselement was defect."
                },
                new IncendentReport
                {
                    Id = 21,
                    CustomerId = 21,
                    DateReported = new DateTime(2024, 3, 5),
                    InitialMessage = "Machine blijft vastzitten.",
                    CoffeeMachineType = "Barroc Intens Italian Light",
                    FaultCode = "E21",
                    IsResolved = false,
                    FollowUp = null,
                    IncidentDescription = "De koffieautomaat blijft steken tijdens het zetten."
                },
                new IncendentReport
                {
                    Id = 22,
                    CustomerId = 22,
                    DateReported = new DateTime(2024, 3, 7),
                    InitialMessage = "Koffieautomaat draait niet goed.",
                    CoffeeMachineType = "Barroc Intens Italian Deluxe",
                    FaultCode = "E22",
                    IsResolved = true,
                    FollowUp = "Motor gerepareerd.",
                    IncidentDescription = "De motor had een probleem."
                },
                new IncendentReport
                {
                    Id = 23,
                    CustomerId = 23,
                    DateReported = new DateTime(2024, 3, 10),
                    InitialMessage = "Er komt geen schuim op de koffie.",
                    CoffeeMachineType = "Barroc Intens Italian",
                    FaultCode = "E23",
                    IsResolved = false,
                    FollowUp = null,
                    IncidentDescription = "De melkschuimer lijkt defect."
                },
                new IncendentReport
                {
                    Id = 24,
                    CustomerId = 24,
                    DateReported = new DateTime(2024, 3, 12),
                    InitialMessage = "Koffieautomaat stopt halverwege.",
                    CoffeeMachineType = "Barroc Intens Italian Light",
                    FaultCode = "E24",
                    IsResolved = true,
                    FollowUp = "Onderdeel vervangen.",
                    IncidentDescription = "Een onderdeel was defect en is vervangen."
                },
                new IncendentReport
                {
                    Id = 25,
                    CustomerId = 25,
                    DateReported = new DateTime(2024, 3, 15),
                    InitialMessage = "Koffieautomaat geeft geen geluid.",
                    CoffeeMachineType = "Barroc Intens Italian Deluxe",
                    FaultCode = "E25",
                    IsResolved = false,
                    FollowUp = null,
                    IncidentDescription = "De machine maakt geen geluid bij gebruik."
                },
                new IncendentReport
                {
                    Id = 26,
                    CustomerId = 26,
                    DateReported = new DateTime(2024, 3, 17),
                    InitialMessage = "Koffieautomaat maakt een knallend geluid.",
                    CoffeeMachineType = "Barroc Intens Italian",
                    FaultCode = "E26",
                    IsResolved = true,
                    FollowUp = "Verbindingen gecontroleerd.",
                    IncidentDescription = "Er was een knallend geluid tijdens het gebruik."
                },
                new IncendentReport
                {
                    Id = 27,
                    CustomerId = 27,
                    DateReported = new DateTime(2024, 3, 20),
                    InitialMessage = "Koffieautomaat heeft een fout in de software.",
                    CoffeeMachineType = "Barroc Intens Italian Light",
                    FaultCode = "E27",
                    IsResolved = false,
                    FollowUp = null,
                    IncidentDescription = "De software lijkt vast te lopen."
                },
                new IncendentReport
                {
                    Id = 28,
                    CustomerId = 28,
                    DateReported = new DateTime(2024, 3, 22),
                    InitialMessage = "Koffieautomaat verliest druk.",
                    CoffeeMachineType = "Barroc Intens Italian Deluxe",
                    FaultCode = "E28",
                    IsResolved = true,
                    FollowUp = "Drukregelaar vervangen.",
                    IncidentDescription = "De drukregelaar was defect."
                },
                new IncendentReport
                {
                    Id = 29,
                    CustomerId = 29,
                    DateReported = new DateTime(2024, 3, 25),
                    InitialMessage = "Koffieautomaat produceert geen stoom.",
                    CoffeeMachineType = "Barroc Intens Italian",
                    FaultCode = "E29",
                    IsResolved = false,
                    FollowUp = null,
                    IncidentDescription = "De stoomfunctie werkt niet."
                },
                new IncendentReport
                {
                    Id = 30,
                    CustomerId = 30,
                    DateReported = new DateTime(2024, 3, 27),
                    InitialMessage = "Koffieautomaat werkt niet goed.",
                    CoffeeMachineType = "Barroc Intens Italian Light",
                    FaultCode = "E30",
                    IsResolved = true,
                    FollowUp = "Alle onderdelen gecontroleerd.",
                    IncidentDescription = "Er was een probleem met de werking."
                },
                new IncendentReport
                {
                    Id = 31,
                    CustomerId = 31,
                    DateReported = new DateTime(2024, 3, 30),
                    InitialMessage = "Koffieautomaat maakt een raar geluid.",
                    CoffeeMachineType = "Barroc Intens Italian Deluxe",
                    FaultCode = "E31",
                    IsResolved = false,
                    FollowUp = null,
                    IncidentDescription = "De machine produceert een onregelmatig geluid."
                },
                new IncendentReport
                {
                    Id = 32,
                    CustomerId = 32,
                    DateReported = new DateTime(2024, 4, 1),
                    InitialMessage = "Er is lekkage onder de machine.",
                    CoffeeMachineType = "Barroc Intens Italian",
                    FaultCode = "E32",
                    IsResolved = true,
                    FollowUp = "Lekkage verholpen.",
                    IncidentDescription = "Water lekte onder de machine."
                },
                new IncendentReport
                {
                    Id = 33,
                    CustomerId = 33,
                    DateReported = new DateTime(2024, 4, 3),
                    InitialMessage = "Koffieautomaat maakt geen koffie.",
                    CoffeeMachineType = "Barroc Intens Italian Light",
                    FaultCode = "E33",
                    IsResolved = false,
                    FollowUp = null,
                    IncidentDescription = "De machine functioneert niet."
                },
                new IncendentReport
                {
                    Id = 34,
                    CustomerId = 34,
                    DateReported = new DateTime(2024, 4, 5),
                    InitialMessage = "Koffieautomaat doet niets.",
                    CoffeeMachineType = "Barroc Intens Italian Deluxe",
                    FaultCode = "E34",
                    IsResolved = true,
                    FollowUp = "Onderdeel vervangen.",
                    IncidentDescription = "De machine reageert niet op aan/uit."
                },
                new IncendentReport
                {
                    Id = 35,
                    CustomerId = 35,
                    DateReported = new DateTime(2024, 4, 7),
                    InitialMessage = "Koffieautomaat is traag.",
                    CoffeeMachineType = "Barroc Intens Italian",
                    FaultCode = "E35",
                    IsResolved = false,
                    FollowUp = null,
                    IncidentDescription = "De machine is traag met het zetten van koffie."
                },
                new IncendentReport
                {
                    Id = 36,
                    CustomerId = 36,
                    DateReported = new DateTime(2024, 4, 9),
                    InitialMessage = "Koffieautomaat vertoont storingen.",
                    CoffeeMachineType = "Barroc Intens Italian Light",
                    FaultCode = "E36",
                    IsResolved = true,
                    FollowUp = "Probleem verholpen.",
                    IncidentDescription = "Er waren meerdere storingen."
                },
                new IncendentReport
                {
                    Id = 37,
                    CustomerId = 37,
                    DateReported = new DateTime(2024, 4, 11),
                    InitialMessage = "Koffieautomaat maakt te veel geluid.",
                    CoffeeMachineType = "Barroc Intens Italian Deluxe",
                    FaultCode = "E37",
                    IsResolved = false,
                    FollowUp = null,
                    IncidentDescription = "De machine maakt een storend geluid tijdens gebruik."
                },
                new IncendentReport
                {
                    Id = 38,
                    CustomerId = 38,
                    DateReported = new DateTime(2024, 4, 13),
                    InitialMessage = "Koffieautomaat kan niet worden afgesloten.",
                    CoffeeMachineType = "Barroc Intens Italian",
                    FaultCode = "E38",
                    IsResolved = true,
                    FollowUp = "Probleem opgelost.",
                    IncidentDescription = "De knop om de machine uit te schakelen werkt niet."
                },
                new IncendentReport
                {
                    Id = 39,
                    CustomerId = 39,
                    DateReported = new DateTime(2024, 4, 15),
                    InitialMessage = "Koffieautomaat verwarmt niet.",
                    CoffeeMachineType = "Barroc Intens Italian Light",
                    FaultCode = "E39",
                    IsResolved = false,
                    FollowUp = null,
                    IncidentDescription = "De machine blijft koud tijdens gebruik."
                },
                new IncendentReport
                {
                    Id = 40,
                    CustomerId = 40,
                    DateReported = new DateTime(2024, 4, 17),
                    InitialMessage = "Koffieautomaat produceert geen warme dranken.",
                    CoffeeMachineType = "Barroc Intens Italian Deluxe",
                    FaultCode = "E40",
                    IsResolved = true,
                    FollowUp = "Verwarmingsonderdeel vervangen.",
                    IncidentDescription = "Het verwarmingselement was defect."
                },
                new IncedentReport
                {
                    Id = 41,
                    CustomerId = 41,
                    DateReported = new DateTime(2024, 4, 19),
                    InitialMessage = "Koffieautomaat schakelt vanzelf uit.",
                    CoffeeMachineType = "Barroc Intens Italian",
                    FaultCode = "E41",
                    IsResolved = false,
                    FollowUp = null,
                    IncidentDescription = "De machine schakelt na enkele minuten automatisch uit."
                },
                new IncedentReport
                {
                    Id = 42,
                    CustomerId = 42,
                    DateReported = new DateTime(2024, 4, 21),
                    InitialMessage = "Koffie komt niet heet genoeg.",
                    CoffeeMachineType = "Barroc Intens Italian Light",
                    FaultCode = "E42",
                    IsResolved = true,
                    FollowUp = "Temperatuurinstellingen aangepast.",
                    IncidentDescription = "De koffie was lauw bij het zetten."
                },
                new IncedentReport
                {
                    Id = 43,
                    CustomerId = 43,
                    DateReported = new DateTime(2024, 4, 23),
                    InitialMessage = "Koffieautomaat geeft vreemde geluiden.",
                    CoffeeMachineType = "Barroc Intens Italian Deluxe",
                    FaultCode = "E43",
                    IsResolved = false,
                    FollowUp = null,
                    IncidentDescription = "De machine maakt een piepend geluid tijdens gebruik."
                },
                new IncedentReport
                {
                    Id = 44,
                    CustomerId = 44,
                    DateReported = new DateTime(2024, 4, 25),
                    InitialMessage = "Koffieautomaat heeft geen druk.",
                    CoffeeMachineType = "Barroc Intens Italian",
                    FaultCode = "E44",
                    IsResolved = true,
                    FollowUp = "Drukregelaar vervangen.",
                    IncidentDescription = "De machine heeft onvoldoende druk om koffie te zetten."
                },
                new IncedentReport
                {
                    Id = 45,
                    CustomerId = 45,
                    DateReported = new DateTime(2024, 4, 27),
                    InitialMessage = "Koffieautomaat is moeilijk schoon te maken.",
                    CoffeeMachineType = "Barroc Intens Italian Light",
                    FaultCode = "E45",
                    IsResolved = false,
                    FollowUp = null,
                    IncidentDescription = "De machine heeft veel koffiedik dat moeilijk te bereiken is."
                }*/
            );

            modelBuilder.Entity<CustomerOrder>().HasData(
                new CustomerOrder
                {
                    Id = 1,
                    CustomerId = 1,
                    ProductId = 1,
                    BeanId = 1,
                    Quantity = 2,
                    Price = 499.00M,
                    OrderDate = new DateTime(2024, 2, 1),
                    IsPaid = true
                },
                new CustomerOrder
                {
                    Id = 2,
                    CustomerId = 2,
                    ProductId = 3,
                    BeanId = 2,
                    Quantity = 1,
                    Price = 799.00M,
                    OrderDate = new DateTime(2024, 2, 5),
                    IsPaid = false
                },
                new CustomerOrder
                {
                    Id = 3,
                    CustomerId = 3,
                    ProductId = 2,
                    BeanId = 3,
                    Quantity = 3,
                    Price = 1797.00M, // 3 x 599.00
                    OrderDate = new DateTime(2024, 2, 10),
                    IsPaid = true
                },
                new CustomerOrder
                {
                    Id = 4,
                    CustomerId = 4,
                    ProductId = 4,
                    BeanId = 4,
                    Quantity = 1,
                    Price = 999.00M,
                    OrderDate = new DateTime(2024, 2, 15),
                    IsPaid = false
                }
            );

            modelBuilder.Entity<PartOrder>().HasData(
                new PartOrder
                {
                    Id = 1,
                    PartId = 1,
                    Quantity = 10,
                    Price = 3.90m, // 10 x 0.39m
                    OrderDate = new DateTime(2024, 1, 15)
                },
                new PartOrder
                {
                    Id = 2,
                    PartId = 4,
                    Quantity = 2,
                    Price = 137.38m, // 2 x 68.69m
                    OrderDate = new DateTime(2024, 1, 20)
                },
                new PartOrder
                {
                    Id = 3,
                    PartId = 6,
                    Quantity = 1,
                    Price = 299.45m,
                    OrderDate = new DateTime(2024, 1, 25)
                },
                new PartOrder
                {
                    Id = 4,
                    PartId = 7,
                    Quantity = 5,
                    Price = 449.95m, // 5 x 89.99m
                    OrderDate = new DateTime(2024, 2, 1)
                },
                new PartOrder
                {
                    Id = 5,
                    PartId = 9,
                    Quantity = 1,
                    Price = 478.59m,
                    OrderDate = new DateTime(2024, 2, 5)
                }
            );

            modelBuilder.Entity<Maintenance>().HasData(
                new Maintenance
                {
                    Id = 1,
                    UserId = 11,
                    CostumerId = 1,
                    Description = "Routine onderhoud koffieautomaat.",
                    AppointmentDate = new DateTime(2024, 1, 15, 10, 0, 0)
                },
                new Maintenance
                {
                    Id = 2,
                    UserId = 12,
                    CostumerId = 2,
                    Description = "Probleem met waterfilter vervangen.",
                    AppointmentDate = new DateTime(2024, 1, 20, 14, 30, 0)
                },
                new Maintenance
                {
                    Id = 3,
                    UserId = 13,
                    CostumerId = 3,
                    Description = "Algemene inspectie van de apparatuur.",
                    AppointmentDate = new DateTime(2024, 1, 25, 9, 0, 0)
                },
                new Maintenance
                {
                    Id = 4,
                    UserId = 14,
                    CostumerId = 4,
                    Description = "Reparatie van de koffiemachine.",
                    AppointmentDate = new DateTime(2024, 2, 1, 11, 15, 0)
                },
                new Maintenance
                {
                    Id = 5,
                    UserId = 11,
                    CostumerId = 5,
                    Description = "Installatie van nieuwe koffieautomaat.",
                    AppointmentDate = new DateTime(2024, 2, 5, 13, 45, 0)
                }
            );

            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Id = 1,
                    Name = "Finance",
                    HeadDepartmentId = 1,
                },
                new Department
                {
                    Id = 2,
                    Name = "Sales",
                    HeadDepartmentId = 2,
                },
                new Department
                {
                    Id = 3,
                    Name = "Inkoop",
                    HeadDepartmentId = 7,
                },
                new Department
                {
                    Id = 4,
                    Name = "Maintenance",
                    HeadDepartmentId = 10,
                }
            );
        }
    }
}
