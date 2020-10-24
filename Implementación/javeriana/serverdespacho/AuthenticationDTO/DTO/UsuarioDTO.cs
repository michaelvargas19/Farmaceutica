using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutenticacionDTO.DTO
{
    public class UsuarioDTO
    {
        public bool exitoso { get; set; }

        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }

        
        [Required]
        public string Nombres { get; set; }

        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string Telefono { get; set; }
        
        public string? Area { get; set; }

        public string? Organizacion { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Conraseña")]
        public string Contrasena { get; set; }


        [Required]
        public List<int> Roles { get; set; }


    }
}
