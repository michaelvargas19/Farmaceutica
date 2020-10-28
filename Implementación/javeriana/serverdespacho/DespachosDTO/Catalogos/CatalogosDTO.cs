using DespachosDTO.Servicios;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace DespachosDTO.Catalogos
{
    public class CatalogosDTO
    {
        public bool Exitoso { get; set; }
        public int IdCatalogo { get; set; }

        public string Usuario { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaCreacion { get; set; }

        public ICollection<ServicioDTO> Servicios { get; set; }

        public string Mensaje { get; set; }
    }
}
