using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace serverdespacho.Entidades
{
    [Table("Servicios")]
    public class Servicio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdServicio { get; set; }

        [Required]
        [ForeignKey("Catalogo")]
        public int IdCatalogo { get; set; }

        public Catalogo Catalogo { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public int IdCiudadOrigen { get; set; }

        [Required]
        [ForeignKey("MunicipioOrigen")]
        public int IdMunicipioOrigen { get; set; }

        public Municipio MunicipioOrigen { get; set; }

        [Required]
        [ForeignKey("MunicipioDestino")]
        public int IdMunicipioDestino { get; set; }

        public Municipio MunicipioDestino { get; set; }

        [Required]
        public long Precio { get; set; }

    }
}
