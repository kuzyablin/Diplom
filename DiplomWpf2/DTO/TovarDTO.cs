using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomWpf2.DTO
{
    public partial class TovarDTO
    {
        public int IdTovar { get; set; }
        public string NameTovar { get; set; } = null!;
        public decimal PriceTovar { get; set; }
        public byte[]? ImageTovar { get; set; }
        public int StockTovar { get; set; }
        public int IdTypeTovar { get; set; }
        public DateTime? DeleteAt { get; set; }
        public virtual TypeTovarDTO IdTypeTovarNavigation { get; set; } = null!;
    }
}
