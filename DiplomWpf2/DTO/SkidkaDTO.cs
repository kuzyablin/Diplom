using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomWpf2.DTO
{
    public partial class SkidkaDTO
    {
        public int IdSkidka { get; set; }
        public string? NameSkidka { get; set; }
        public double PriceOrder { get; set; }
        public DateTime? DeleteAt { get; set; }
    }
}
