using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutenticacionDTO.DTO.Login
{
    public class LoginRequest
    {
        
        [Required]
        public string Usuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Contrasena { get; set; }

        public bool datosParaLogin()
        {

            if ((Usuario.Length > 0) && (Contrasena.Length > 0))
            {
                return true;
            }

            return false;
        }

    }
}
