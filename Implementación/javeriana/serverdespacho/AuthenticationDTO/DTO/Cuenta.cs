using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace AutenticacionDTO.DTO
{
    public class Cuenta
    {
        [Required]
        [MaxLength(450)]
        public string AbreviacionAPP { get; set; }

        [Required]
        public string Usuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Contrasena { get; set; }

        [DataType(DataType.Password)]
        public string NuevaContrasena { get; set; }

        [Required]
        public string TokenJWT { get; set; }

        public bool datosParaLogin() {

            if ((AbreviacionAPP.Length > 0) && (Usuario.Length > 0) && (Contrasena.Length > 0))
            {
                return true;
            }

            return false;
        }

        public bool datosParaActualizacion()
        {
            if ((AbreviacionAPP.Length > 0) && (Usuario.Length > 0) &&
                (Contrasena.Length > 0) && (NuevaContrasena.Length > 0))
            {
                if (Contrasena.CompareTo(NuevaContrasena) == 0) {
                    return false;
                } 

                return true;
            }

            return false;
        }

    }
}
