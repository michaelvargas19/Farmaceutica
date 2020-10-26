using System;
using System.Collections.Generic;
using System.Text;

namespace DespachosDTO.Ofertas
{
    public class OfertaDTO
    {
        public bool exitoso { get; set; }
        public int IdOferta { get; set; }
        public string Usuario { get; set; }
        public DateTime FechaPostulacion { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public long Precio { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public int IdDespacho { get; set; }
        public string Mensaje { get; set; }

    }
}
