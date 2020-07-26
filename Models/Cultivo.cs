using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prototipos_Huertos_Autosustentables.Models
{
    public class Cultivo
    {
        public Cultivo()
        {
            DetalleCultivosUsuario = new HashSet<DetalleCultivosUsuario>();
        }
        [Key]
        public int IdCultivo { get; set; }
        public int? IdTipoCultivos { get; set; }
        public int? IdRegiones { get; set; }
        public string NombreCultivos { get; set; }
        public string IntroduccionCultivos { get; set; }
        public string CuerpoCultivos { get; set; }
        public string Recomendaciones { get; set; }


        public virtual Region IdRegionesNavigation { get; set; }
        public virtual TipoCultivo IdTipoCultivosNavigation { get; set; }
        public virtual ICollection<DetalleCultivosUsuario> DetalleCultivosUsuario { get; set; }
    }
}
