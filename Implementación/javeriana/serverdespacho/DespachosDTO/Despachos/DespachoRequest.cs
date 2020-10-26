using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DespachosDTO.Despachos
{
    public class DespachoRequest
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFinOfertas { get; set; }

        [Required]
        public DateTime FechaCierreDespacho { get; set; }

        [Required]
        public int IdMunicipioOrigen { get; set; }

        [Required]
        public int IdMunicipioDestino { get; set; }
    }
}
