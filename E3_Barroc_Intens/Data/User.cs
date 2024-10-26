using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_Barroc_Intens.Data
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool BkrRegisted { get; set; }
        public List<RoleUser> RoleUsers { get; set; } = new List<RoleUser>();
        public List<Maintenance> Maintenances { get; set; } = new List<Maintenance>();
    }
}
