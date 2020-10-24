using System;
using System.ComponentModel.DataAnnotations;

namespace AutenticacionDTO.DTO.Cuentas
{
    
    public class CodigoResponse
    {
        [Required]
        [MaxLength(450)]
        public string AbreviacionApp { get; set; }
        
        [Required]
        public string TokenJWT { get; set; }

        [Required]
        public bool CodigoGenerado { get; set; }

        [Required]
        public int LongitudCodigo { get; set; }

        [Required]
        public int MinutosVida { get; set; }

        public DateTime FechaGeneracion { get; set; }

        public DateTime FechaExpiracion { get; set; }

        public string Mensaje { get; set; }
    }
}
