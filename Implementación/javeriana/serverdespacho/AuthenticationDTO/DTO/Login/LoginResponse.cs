using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutenticacionDTO.DTO.Login
{
    public class LoginResponse
    {
        [Required]
        public bool Autenticacion { get; set; }

        public string TokenJWT { get; set; }

        [Required]
        public string Mensaje { get; set; }

        [Required]
        public bool Bloqueado { get; set; }
        
        public string URLdesbloqueo { get; set; }

    }
}
