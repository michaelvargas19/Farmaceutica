﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutenticacionDTO.DTO.Proceso
{
    public class ResultadoResponse
    {
        [Required] 
        public string Proceso { get; set; }

        [Required]
        public bool Exitoso { get; set; }

        [Required]
        public string Mensaje { get; set; }
    }
}
