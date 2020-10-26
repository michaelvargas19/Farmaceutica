using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace serverdespacho.Entidades
{
    [Table("Ofertas")]
    public class Oferta
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOferta { get; set; }

        [Required]
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        [Required]
        public DateTime FechaPostulacion { get; set; }
        
        public DateTime? FechaFinalizacion { get; set; }

        [Required]
        public long Precio { get; set; }

        [Required]
        [ForeignKey("Estado")]
        public int IdEstado { get; set; }
        public EstadoOfertas Estado { get; set; }

        [Required]
        [ForeignKey("Despacho")]
        public int IdDespacho { get; set; }
        public Despacho Despacho { get; set; }

        
    }
}
