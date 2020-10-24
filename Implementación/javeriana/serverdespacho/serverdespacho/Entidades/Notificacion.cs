using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace serverdespacho.Entidades
{
    [Table("Notificaciones")]
    public class Notificacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOferta { get; set; }

        [Required]
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        [Required]
        [ForeignKey("TipoNotificacion")]
        public int IdTipoNotificacion { get; set; }
        public TipoNotificacion TipoNotificacion { get; set; }

        [Required]
        public string Mensaje {get;set;}
        
        [Required]
        [MaxLength(160)]
        public string MensajeCorto { get; set; }

        [Required]
        public DateTime FechaEnvio { get; set; }

        [Required]
        public bool Entregada { get; set; }

    }
}
