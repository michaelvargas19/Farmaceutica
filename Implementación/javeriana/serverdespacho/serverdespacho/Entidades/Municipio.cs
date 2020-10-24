using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace serverdespacho.Entidades
{
    [Table("Municipios")]
    public class Municipio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodigoDane { get; set; }

        public string Nombre { get  ; set; }

        [Required]
        [ForeignKey("Departamento")]
        public int CodigoDepartamento { get; set; }

        public Departamento Departamento { get; set; }

    }
}
