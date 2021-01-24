using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_User.Models
{
    public class User
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Role { get; set; }
    }
}
