using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomWpf2
{
    class User
    {
        private static User _instance;
        public static User Instance => _instance ??= new User();
        public int IdUser { get; set; }
        public string NameUser { get; set; }
        public string EmailUser { get; set; }
        //public int? Role { get; set; }

        private List<User> _bukets = new List<User>();
        public User() { }

        public void Add(User buket)
        {
            _bukets.Add(buket);
        }
    }
}
