using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace serverdespacho.Entidades
{
    public class Usuario : IdentityUser<int>
    {
        [Required(ErrorMessage = "FirstName is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required.")]
        public string LastName { get; set; }
        
        public string? Area { get; set; }

        public string? Organization { get; set; }

        [ForeignKey("IdUsuario")]
        public ICollection<Catalogo> Catalogos { get; set; }
        
        [ForeignKey("IdUsuario")]
        public ICollection<Despacho> Despachos { get; set; }

    }
}
