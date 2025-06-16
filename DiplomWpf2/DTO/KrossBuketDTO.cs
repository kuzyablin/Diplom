using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomWpf2.DTO
{
    public partial class KrossBuketDTO
    {
        public int IdKrossBuket { get; set; }
        public int IdBuket { get; set; }
        public int IdTovar { get; set; }
        public int? Value { get; set; }
        public virtual TovarDTO IdTovarNavigation { get; set; } = null!;
        public virtual BuketDTO IdBuketNavigation { get; set; } = null!;
    }
}
