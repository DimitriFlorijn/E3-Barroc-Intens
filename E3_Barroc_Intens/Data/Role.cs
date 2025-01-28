using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_Barroc_Intens.Data
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RoleUser> RoleUsers { get; set; } = new List<RoleUser>();
    }
}
