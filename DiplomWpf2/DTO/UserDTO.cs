using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DiplomWpf2.DTO
{
    public partial class UserDTO
    {
        public int IdUser { get; set; }
        public string NameUser { get; set; } = null!;

        public string EmailUser { get; set; } = null!;
        public string ParolUser { get; set; } = null!;
        public string NumberUser { get; set; }
        public DateTime? DeleteAt { get; set; }
    }
}
