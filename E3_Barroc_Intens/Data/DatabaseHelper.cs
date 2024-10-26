using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_Barroc_Intens.Data
{
    internal static class DatabaseHelper
    {
        public static List<User> GetUsers()
        {
            using (var db = new AppDbContext())
            {
                return db.Users.ToList();
            }
        }
        public static List<Bean> GetBeans()
        {
            using (var db = new AppDbContext())
            {
                return db.Bean.ToList();
            }
        }
        public static List<Brand> GetBrands()
        {
            using (var db = new AppDbContext())
            {
                return db.Brands.ToList();
            }
        }
        public static List<Contract> GetContracts()
        {
            using (var db = new AppDbContext())
            {
                return db.Contracts.ToList();
            }
        }
        public static List<Customer> GetCustomers()
        {
            using (var db = new AppDbContext())
            {
                return db.Customers.ToList();
            }
        }
        public static List<CustomerOder> GetCustomerOders()
        {
            using (var db = new AppDbContext())
            {
                return db.CustomerOders.ToList();
            }
        }
        public static List<Department> GetDepartments()
        {
            using (var db = new AppDbContext())
            {
                return db.Department.ToList();
            }
        }
        public static List<Maintenance> GetMaintenances()
        {
            using (var db = new AppDbContext())
            {
                return db.Maintenances.ToList();
            }
        }
        public static List<Part> GetParts()
        {
            using (var db = new AppDbContext())
            {
                return db.Parts.ToList();
            }
        }
        public static List<PartOrder> GetPartOrders()
        {
            using (var db = new AppDbContext())
            {
                return db.PartOrder.ToList();
            }
        }
        public static List<Product> GetProducts()
        {
            using (var db = new AppDbContext())
            {
                return db.Products.ToList();
            }
        }
        public static List<Role> GetRoles()
        {
            using (var db = new AppDbContext())
            {
                return db.Roles.ToList();
            }
        }
        public static List<RoleUser> GetRoleUsers()
        {
            using (var db = new AppDbContext())
            {
                return db.RoleUsers.ToList();
            }
        }
        public static List<Storage> GetStorages()
        {
            using (var db = new AppDbContext())
            {
                return db.Storages.ToList();
            }
        }
    }
}
