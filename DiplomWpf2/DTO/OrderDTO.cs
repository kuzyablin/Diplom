using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomWpf2.DTO
{
    public partial class OrderDTO
    {
        public int IdOrder { get; set; }
        public int IdUser { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal? PriceOrder { get; set; }
        public int? IdSkidka { get; set; }
        public DateTime? DeleteAt { get; set; }
        public int? IdStatus { get; set; }
        public virtual SkidkaDTO? IdSkidkaNavigation { get; set; } = new();
        public virtual StatusDTO? IdStatusNavigation { get; set; } = new();
        public virtual UserDTO IdUserNavigation { get; set; } = new();
        public List<BuketDTO> Bukets { get; set; } = new();
        public List<TovarDTO> Tovars { get; set; } = new();
    }
}
