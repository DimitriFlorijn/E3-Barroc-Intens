using Microsoft.EntityFrameworkCore;
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
        public static void MakeUser(string name, string email, string password, int roleId)
        {
            using (var db = new AppDbContext())
            {
                var newUser = new User
                {
                    Name = name,
                    Email = email,
                    Password = HashPassword(password)
                };

                db.Users.Add(newUser);
                db.SaveChanges();

                var role = db.Roles.Find(roleId);
                if (role != null)
                {
                    var roleUser = new RoleUser
                    {
                        RoleId = roleId,
                        UserId = newUser.Id,
                    };

                    db.RoleUsers.Add(roleUser);
                    db.SaveChanges();
                }
            }
        }
        public static void UpdateUser(int userId, string name = null, string email = null, string password = null)
        {
            using (var db = new AppDbContext())
            {
                var user = db.Users.Find(userId);
                if (user != null)
                {
                    if (name != null && name != "")
                    {
                        user.Name = name;
                    }
                    if (email != null && email != "")
                    {
                        user.Email = email;
                    }
                    if (password != null && password != "")
                    {
                        user.Password = HashPassword(password);
                    }
                    db.SaveChanges();
                }
            }
        }
        public static void DeleteUser(int userId)
        {
            using (var db = new AppDbContext())
            {
                var user = db.Users.Where(u => u.Id == userId).Include(u => u.RoleUsers).FirstOrDefault();
                if (user != null)
                {
                    var roleUser = db.RoleUsers.Where(ru => ru.UserId == userId).ToList();
                    db.RoleUsers.RemoveRange(roleUser);
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
            }
        }
        private static string HashPassword(string password)
        {
            // moet nog een hash-functie worden toegevoegd
            return password;
        }
    }
}
