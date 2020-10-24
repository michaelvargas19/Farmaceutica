using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace serverdespacho.Entidades
{
    [Table("Despachos")]
    public class Despacho
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDespacho { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }

        public Usuario Usuario { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFinOfertas { get; set; }

        [Required]
        public DateTime FechaCierreDespacho { get; set; }

        [Required]
        [ForeignKey("Estado")]
        public int IdEstado { get; set; }
        public EstadoDespachos Estado { get; set; }


        [ForeignKey("IdDespacho")]
        public ICollection<Oferta> Ofertas { get; set; }
        


    }
}
