using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace serverdespacho.Entidades
{

    [Table("TiposNotificaciones")]
    public class TipoNotificacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoNotificacion { get; set; }
        
        [Required]
        public string Nombre { get; set; }
    }
}
