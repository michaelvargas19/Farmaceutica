using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace serverdespacho.Entidades
{
    [Table("Departamentos")]
    public class Departamento
    {
        [Key]
        public int CodigoDane { get; set; }

        [Required]
        public string Nombre { get; set; }
        
        [Required]
        public string Region { get; set; }
                
        [ForeignKey("CodigoDepartamento")]
        public ICollection<Municipio> Municipios { get; set; }
    }
}
