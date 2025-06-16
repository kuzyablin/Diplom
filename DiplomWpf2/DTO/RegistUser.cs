using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomWpf2.DTO
{
    public partial class RegistUser
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUser { get; set; }
        public string NameUser { get; set; } = null!;
        public string EmailUser { get; set; } = null!;
        public string ParolUser { get; set; } = null!;
        public string NumberUser { get; set; }
        public string kod { get; set; } = null!;
    }
}
