using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomWpf2.DTO
{
    public partial class OrderTovarDTO
    {
        public int IdOrderTovar { get; set; }
        public int? IdOrder { get; set; }
        public int? IdTovar { get; set; }
        public int? Value { get; set; }
        public virtual OrderDTO? IdOrderNavigation { get; set; }
        public virtual TovarDTO? IdTovarNavigation { get; set; }
    }
}
