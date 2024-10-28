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

            modelBuilder.Entity<Part>().HasData(
                new Part { Id = 1, Name = "Rubber 10 mm", Description = "", Price = 0.39m, BrandId = 1 },
                new Part { Id = 2, Name = "Rubber 14 mm", Description = "", Price = 0.45m, BrandId = 1 },
                new Part { Id = 3, Name = "Slang", Description = "", Price = 4.45m, BrandId = 1 },
                new Part { Id = 4, Name = "Voeding (elektra)", Description = "", Price = 68.69m, BrandId = 1 },
                new Part { Id = 5, Name = "Ontkalker", Description = "", Price = 4.00m, BrandId = 1 },
                new Part { Id = 6, Name = "Waterfilter", Description = "", Price = 299.45m, BrandId = 1 },
                new Part { Id = 7, Name = "Reservoir sensor", Description = "", Price = 89.99m, BrandId = 1 },
                new Part { Id = 8, Name = "Druppelstop", Description = "", Price = 122.43m, BrandId = 1 },
                new Part { Id = 9, Name = "Electrische pomp", Description = "", Price = 478.59m, BrandId = 1 },
                new Part { Id = 10, Name = "Tandwiel 110mm", Description = "", Price = 5.45m, BrandId = 1 },
                new Part { Id = 11, Name = "Tandwiel 70mm", Description = "", Price = 5.25m, BrandId = 1 },
                new Part { Id = 12, Name = "Maalmotor", Description = "", Price = 119.20m, BrandId = 1 },
                new Part { Id = 13, Name = "Zeef", Description = "", Price = 28.80m, BrandId = 1 },
                new Part { Id = 14, Name = "Reinigingstabletten", Description = "", Price = 3.45m, BrandId = 1 },
                new Part { Id = 15, Name = "Reinigingsborsteltjes", Description = "", Price = 8.45m, BrandId = 1 },
                new Part { Id = 16, Name = "Ontkalkingspijp", Description = "", Price = 21.70m, BrandId = 1 }
            );

            modelBuilder.Entity<Storage>().HasData(
                new Storage { /*Id = 1,*/ ProductId = 1, BeanId = 1, PartId = 1, Amount = 10 },
                new Storage { /*Id = 2,*/ ProductId = 2, BeanId = 2, PartId = 2, Amount = 5 },
                new Storage { /*Id = 3,*/ ProductId = 3, BeanId = 3, PartId = 3, Amount = 20 },
                new Storage { /*Id = 4,*/ ProductId = 4, BeanId = 4, PartId = 4, Amount = 15 }
            );

            modelBuilder.Entity<Contract>().HasData(
                new Contract { Id = 1, CustomerId = 1, ProductId = 1, BeanId = 1, StartDate = new DateOnly(2024, 1, 1), EndDate = new DateOnly(2025, 1, 1), IsLeased = true, IsPaid = false, LastUpdate = new DateOnly(2023, 10, 1) },
                new Contract { Id = 2, CustomerId = 2, ProductId = 2, BeanId = 2, StartDate = new DateOnly(2024, 2, 1), EndDate = new DateOnly(2025, 2, 1), IsLeased = true, IsPaid = true, LastUpdate = new DateOnly(2023, 10, 2) },
                new Contract { Id = 3, CustomerId = 3, ProductId = 3, BeanId = null, StartDate = new DateOnly(2024, 3, 1), EndDate = new DateOnly(2025, 3, 1), IsLeased = false, IsPaid = false, LastUpdate = new DateOnly(2023, 10, 3) },
                new Contract { Id = 4, CustomerId = 4, ProductId = 4, BeanId = 3, StartDate = new DateOnly(2024, 4, 1), EndDate = new DateOnly(2025, 4, 1), IsLeased = true, IsPaid = true, LastUpdate = new DateOnly(2023, 10, 4) }
            );

            modelBuilder.Entity<Invoice>().HasData(
                new Invoice { Id = 1, CustomerId = 1, ContractId = 1, DateIssued = new DateTime(2024, 1, 5), DueDate = new DateTime(2024, 2, 5), TotalAmount = 499.00M, IsPaid = false },
                new Invoice { Id = 2, CustomerId = 2, ContractId = 2, DateIssued = new DateTime(2024, 2, 6), DueDate = new DateTime(2024, 3, 6), TotalAmount = 599.00M, IsPaid = true },
                new Invoice { Id = 3, CustomerId = 3, ContractId = 3, DateIssued = new DateTime(2024, 3, 7), DueDate = new DateTime(2024, 4, 7), TotalAmount = 799.00M, IsPaid = false },
                new Invoice { Id = 4, CustomerId = 4, ContractId = 4, DateIssued = new DateTime(2024, 4, 8), DueDate = new DateTime(2024, 5, 8), TotalAmount = 999.00M, IsPaid = true }
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
                }
            );

            modelBuilder.Entity<CustomerOder>().HasData(
                new CustomerOder
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
                new CustomerOder
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
                new CustomerOder
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
                new CustomerOder
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
