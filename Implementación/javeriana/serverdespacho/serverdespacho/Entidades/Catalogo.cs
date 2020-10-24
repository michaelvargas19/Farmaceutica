using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace serverdespacho.Entidades
{
    [Table("Catalogos")]
    public class Catalogo
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCatalogo { get; set; }

        [Required]
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }

        public Usuario Usuario { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [ForeignKey("IdCatalogo")]
        public ICollection<Servicio> Servicios { get; set; }

    }
}
