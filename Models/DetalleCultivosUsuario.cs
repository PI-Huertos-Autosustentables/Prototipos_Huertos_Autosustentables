using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Prototipos_Huertos_Autosustentables.Models
{
    public class DetalleCultivosUsuario
    {
        [Key]
        public int IdDetalle { get; set; }
        public int? IdCultivo { get; set; }
        public string IdUsers { get; set; }
        public double? MetrosCuadrasDetalle { get; set; }
        public double? PrecioSemillasDetalle { get; set; }
        public string LugarCultivoDetalle { get; set; }

        public virtual Cultivo IdCultivoNavigation { get; set; }
        //public virtual AspNetUsers IdUsersNavigation { get; set; }
    }
}
