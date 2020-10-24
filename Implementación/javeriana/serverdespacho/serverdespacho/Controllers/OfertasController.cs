using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using serverdespacho.Negocio;

namespace serverdespacho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfertasController : ControllerBase
    {
        private readonly OfertaNegocio negocio;

        public OfertasController(OfertaNegocio ofertaNegocio)
        {
            this.negocio = ofertaNegocio;
        }
    }
}
