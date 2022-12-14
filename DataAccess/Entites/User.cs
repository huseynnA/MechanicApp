using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entites
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Salt { get; set; }
        public string PasswordHash { get; set; }
        public List<Cart> Cart { get; set; } = new List<Cart>();    
    }
}
