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
    public class DespachosController : ControllerBase
    {
        private readonly DespachoNegocio negocio;

        public DespachosController(DespachoNegocio despachoNegocio)
        {
            this.negocio = despachoNegocio;
        }
    }
}
