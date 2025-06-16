using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomWpf2.DTO
{
    public partial class SotrudDTO
    {
        public int IdSotrud { get; set; }
        public string ParolSotrud { get; set; } = null!;
        public string LoginSotrud { get; set; } = null!;
        public string NameSotrud { get; set; } = null!;
    }
}
