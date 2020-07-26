using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prototipos_Huertos_Autosustentables.Models
{
    public partial class Clima
    {
        public Clima()
        {
            Region = new HashSet<Region>();
        }
        [Key]
        public int IdClima { get; set; }
        public string NombreClima { get; set; }
        
        public virtual ICollection<Region> Region { get; set; }
    }
}
