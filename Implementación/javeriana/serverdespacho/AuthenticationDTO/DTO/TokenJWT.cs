using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutenticacionDTO.DTO
{
    /// <summary> 
    /// Enter description here for class X.  
    /// ID string generated is "T:N.X". 
    /// </summary> 
    public class TokenJWT
    {
        
        [Required]
        public string Token { get; set; }

        public bool TokenValido { get; set; }

    }
}
