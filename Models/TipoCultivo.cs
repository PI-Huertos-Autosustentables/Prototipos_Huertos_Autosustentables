using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prototipos_Huertos_Autosustentables.Models
{
    public class TipoCultivo
    {
        public TipoCultivo()
        {
            Cultivo = new HashSet<Cultivo>();
        }
        [Key]
        public int IdTipoCultivos { get; set; }
        public string NombreTipoCultivos { get; set; }

        public virtual ICollection<Cultivo> Cultivo { get; set; }
    }
}
