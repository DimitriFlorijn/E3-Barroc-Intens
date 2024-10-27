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
        //public static List<User> GetUsers()
        //{
        //    using (var db = new AppDbContext())
        //    {
        //        return db.Users.ToList();
        //    }
        //}
        //public static List<Bean> GetBeans()
        //{
        //    using (var db = new AppDbContext())
        //    {
        //        return db.Bean.ToList();
        //    }
        //}
        //public static List<Brand> GetBrands()
        //{
        //    using (var db = new AppDbContext())
        //    {
        //        return db.Brands.ToList();
        //    }
        //}
        //public static List<Contract> GetContracts()
        //{
        //    using (var db = new AppDbContext())
        //    {
        //        return db.Contracts.ToList();
        //    }
        //}
        //public static List<Customer> GetCustomers()
        //{
        //    using (var db = new AppDbContext())
        //    {
        //        return db.Customers.ToList();
        //    }
        //}
        //public static List<CustomerOder> GetCustomerOders()
        //{
        //    using (var db = new AppDbContext())
        //    {
        //        return db.CustomerOders.ToList();
        //    }
        //}
        //public static List<Department> GetDepartments()
        //{
        //    using (var db = new AppDbContext())
        //    {
        //        return db.Department.ToList();
        //    }
        //}
        //public static List<Maintenance> GetMaintenances()
        //{
        //    using (var db = new AppDbContext())
        //    {
        //        return db.Maintenances.ToList();
        //    }
        //}
        //public static List<Part> GetParts()
        //{
        //    using (var db = new AppDbContext())
        //    {
        //        return db.Parts.ToList();
        //    }
        //}
        //public static List<PartOrder> GetPartOrders()
        //{
        //    using (var db = new AppDbContext())
        //    {
        //        return db.PartOrder.ToList();
        //    }
        //}
        //public static List<Product> GetProducts()
        //{
        //    using (var db = new AppDbContext())
        //    {
        //        return db.Products.ToList();
        //    }
        //}
        //public static List<Role> GetRoles()
        //{
        //    using (var db = new AppDbContext())
        //    {
        //        return db.Roles.ToList();
        //    }
        //}
        //public static List<RoleUser> GetRoleUsers()
        //{
        //    using (var db = new AppDbContext())
        //    {
        //        return db.RoleUsers.ToList();
        //    }
        //}
        //public static List<Storage> GetStorages()
        //{
        //    using (var db = new AppDbContext())
        //    {
        //        return db.Storages.ToList();
        //    }
        //}
        //public static void AddUser(string name, string email, string password, int roleId)
        //{
        //    using (var db = new AppDbContext())
        //    {
        //        var newUser = new User
        //        {
        //            Name = name,
        //            Email = email,
        //            Password = HashPassword(password)
        //        };

        //        db.Users.Add(newUser);
        //        db.SaveChanges();

        //        var role = db.Roles.Find(roleId);
        //        if (role != null)
        //        {
        //            var roleUser = new RoleUser
        //            {
        //                RoleId = roleId,
        //                UserId = newUser.Id,
        //            };

        //            db.RoleUsers.Add(roleUser);
        //            db.SaveChanges();
        //        }
        //    }
        //}
        //public static void AddBean()
        //{

        //}
        //public static void UpdateBean()
        //{

        //}
        //public static void DeleteBean()
        //{

        //}
        //public static void AddBrand()
        //{

        //}
        //public static void UpdateBrand()
        //{

        //}
        //public static void DeleteBrand()
        //{

        //}
        //public static void MakeContract()
        //{

        //}
        //public static void UpdateContract()
        //{

        //}
        //public static void DeleteContract()
        //{

        //}
        //public static void AddCustomer()
        //{

        //}
        //public static void UpdateCustomer()
        //{

        //}
        //public static void DeleteCustomer()
        //{

        //}
        //public static void AddCustomerOrder()
        //{

        //}
        //public static void UpdateCustomerOrder()
        //{

        //}
        //public static void DeleteCustomerOrder()
        //{

        //}
        //public static void AddDepartment()
        //{

        //}
        //public static void UpdateDepartment()
        //{

        //}
        //public static void DeleteDepartment()
        //{

        //}
        //public static void AddMaintenance()
        //{

        //}
        //public static void UpdateMaintenance()
        //{

        //}
        //public static void DeleteMaintenance()
        //{

        //}
        //public static void AddPart()
        //{

        //}
        //public static void UpdatePart()
        //{

        //}
        //public static void DeletePart()
        //{

        //}
        //public static void AddPartOrder()
        //{

        //}
        //public static void UpdatePartOrder()
        //{

        //}
        //public static void DeletePartOrder()
        //{

        //}
        //public static void AddProduct()
        //{

        //}
        //public static void UpdateProduct()
        //{

        //}
        //public static void DeleteProduct()
        //{

        //}
        //public static void AddRole(string name, List<int> userIds = null)
        //{
        //    using (var db = new AppDbContext())
        //    {
        //        var newRole = new Role
        //        {
        //            Name = name,
        //        };
        //        db.Roles.Add(newRole);
        //        db.SaveChanges();
        //        if (userIds != null)
        //        {
        //            foreach (var userId in userIds)
        //            {
        //                if (userId > 0)
        //                {
        //                    var newRoleUser = new RoleUser
        //                    {
        //                        UserId = userId,
        //                        RoleId = newRole.Id
        //                    };

        //                    db.RoleUsers.Add(newRoleUser);
        //                }
        //            }

        //            db.SaveChanges();
        //        }
        //    }
        //}
        //public static void UpdateRole(int RoleId, string name)
        //{
        //    using (var db = new AppDbContext())
        //    {
        //        var role = db.Roles.Find(RoleId);
        //        if (role != null)
        //        {
        //            role.Name = name;
        //            db.SaveChanges();
        //        }
        //    }
        //}
        //public static void DeleteRole()
        //{

        //}
        //public static void AddRoleUser()
        //{

        //}
        //public static void UpdateRoleUser()
        //{

        //}
        //public static void DeleteRoleUser()
        //{

        //}
        //public static void AddStorage()
        //{

        //}
        //public static void UpdateStorage()
        //{

        //}
        //public static void DeleteStorage()
        //{

        //}
        //public static void UpdateUser(int userId, string name = null, string email = null, string password = null)
        //{
        //    using (var db = new AppDbContext())
        //    {
        //        var user = db.Users.Find(userId);
        //        if (user != null)
        //        {
        //            if (name != null && name != "")
        //            {
        //                user.Name = name;
        //            }
        //            if (email != null && email != "")
        //            {
        //                user.Email = email;
        //            }
        //            if (password != null && password != "")
        //            {
        //                user.Password = HashPassword(password);
        //            }
        //            db.SaveChanges();
        //        }
        //    }
        //}
        //public static void DeleteUser(int userId)
        //{
        //    using (var db = new AppDbContext())
        //    {
        //        var user = db.Users.Where(u => u.Id == userId).Include(u => u.RoleUsers).FirstOrDefault();
        //        if (user != null)
        //        {
        //            var roleUser = db.RoleUsers.Where(ru => ru.UserId == userId).ToList();
        //            db.RoleUsers.RemoveRange(roleUser);
        //            db.Users.Remove(user);
        //            db.SaveChanges();
        //        }
        //    }
        //}
        //private static string HashPassword(string password)
        //{
        //    // moet nog een hash-functie worden toegevoegd
        //    return password;
        //}
    }
}
