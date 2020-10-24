using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutenticacionDTO.DTO.Cuentas
{
    public class RecuperarResponse
    {
        [Required]
        public string AbreviacionApp { get; set; }

        [Required]
        public bool Exitoso { get; set; }

        [Required]
        public string Mensaje { get; set; }


        public string TokenJWTSesion { get; set; }

        
    }
}
