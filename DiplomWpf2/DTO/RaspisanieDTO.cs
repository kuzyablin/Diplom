using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomWpf2.DTO
{
    public partial class RaspisanieDTO
    {
        public int IdRaspisanie { get; set; }
        public int? IdSotrud { get; set; }
        public int? IdSmena { get; set; }
        public virtual SmenaDTO? IdSmenaNavigation { get; set; }
        public virtual SotrudDTO? IdSotrudNavigation { get; set; }
    }
}
