using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace serverdespacho.Entidades
{
    [Table("_LogAuthenticacionAPI")]
    public class AppLogAuthenticacionAPI
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLog { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        public string Application { get; set; }

        [Required]
        public string Method { get; set; }

        [Required]
        public string Entity { get; set; }

        [Required]
        public bool IsException { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public string Parameters { get; set; }


    }
}
