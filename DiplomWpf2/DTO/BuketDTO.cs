using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomWpf2.DTO
{
    public partial class BuketDTO
    {
        public int IdBuket { get; set; }
        public byte[]? ImageBuket { get; set; }
        public decimal? PriceBuket { get; set; }
        public DateTime? DeleteAt { get; set; }
        public string? NameBuket { get; set; }
        public List<TovarDTO> Tovars { get; set; }
    }
}
