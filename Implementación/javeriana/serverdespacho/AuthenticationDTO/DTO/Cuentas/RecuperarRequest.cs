﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutenticacionDTO.DTO.Cuentas
{
    public class RecuperarRequest
    {
        [Required]
        [MaxLength(450)]
        public string AbreviacionApp { get; set; }

        [Required]
        public string Usuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string NuevaContrasena { get; set; }

        [Required]
        public string TokenJWT { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(6)]
        public string CodigoVerificacion { get; set; }

        
    }
}
