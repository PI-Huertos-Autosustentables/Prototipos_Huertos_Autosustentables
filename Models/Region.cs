using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prototipos_Huertos_Autosustentables.Models
{
    public class Region
    {
        public Region()
        {
            Cultivo = new HashSet<Cultivo>();
        }
        [Key]
        public int IdRegiones { get; set; }
        public int? IdClima { get; set; }
        public string NombreRegiones { get; set; }

        public virtual Clima IdClimaNavigation { get; set; }
        public virtual ICollection<Cultivo> Cultivo { get; set; }
    }
}
