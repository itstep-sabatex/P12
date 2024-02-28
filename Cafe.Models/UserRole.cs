using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public Role? Role { get; set; }
        public int RoleId { get; set; }
        public Waiter? Waiter { get; set; }
        public int WaiterId { get; set; }
    }
}
