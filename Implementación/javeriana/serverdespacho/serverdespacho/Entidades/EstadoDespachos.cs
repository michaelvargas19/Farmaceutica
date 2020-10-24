using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace serverdespacho.Entidades
{
    [Table("EstadosDespachos")]
    public class EstadoDespachos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstado { get; set; }

        [Required]
        public string Nombre { get; set; }

    }
}
