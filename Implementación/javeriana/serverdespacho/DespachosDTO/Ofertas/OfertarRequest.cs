using System;
using System.Collections.Generic;
using System.Text;

namespace DespachosDTO.Ofertas
{
    public class OfertarRequest
    {
        public string UserName { get; set; }
        public long Precio { get; set; }
        public int IdDespacho { get; set; }
    }
}
