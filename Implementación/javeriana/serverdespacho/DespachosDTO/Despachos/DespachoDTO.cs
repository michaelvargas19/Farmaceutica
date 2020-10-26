using DespachosDTO.Ofertas;
using System;
using System.Collections.Generic;
using System.Text;

namespace DespachosDTO.Despachos
{
    public class DespachoDTO
    {
        public bool exitoso { get; set; }
        public int IdDespacho { get; set; }
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinOfertas { get; set; }
        public DateTime FechaCierreDespacho { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public ICollection<OfertaDTO> Ofertas { get; set; }
        public string Mensaje { get; set; }
    }
}
