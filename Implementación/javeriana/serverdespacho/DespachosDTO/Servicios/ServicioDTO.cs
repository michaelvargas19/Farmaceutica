using System;
using System.Collections.Generic;
using System.Text;

namespace DespachosDTO.Servicios
{
    public class ServicioDTO
    {
        public bool Exitoso { get; set; }
        public int IdServicio { get; set; }

        public int IdCatalogo { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int IdMunicipioOrigen { get; set; }

        public int IdMunicipioDestino { get; set; }

        public long Precio { get; set; }

        public string Mensaje { get; set; }
    }
}
