using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DiplomWpf2.DTO
{
    public partial class KrossOrder
    {
        public int IdKrossOrder { get; set; }

        public int? IdOrder { get; set; }

        public int? IdBuket { get; set; }

        public int? IdTovar { get; set; }

        public int? Kolvo { get; set; }

        public virtual BuketDTO IdBuketNavigation { get; set; }

        public virtual OrderDTO IdOrderNavigation { get; set; }

        public virtual TovarDTO IdTovarNavigation { get; set; }
    }
}
