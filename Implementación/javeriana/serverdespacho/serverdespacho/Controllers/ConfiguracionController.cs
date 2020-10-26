using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using serverdespacho.Entidades;
using serverdespacho.Negocio;

namespace serverdespacho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionController : ControllerBase
    {
        private readonly ConfiguracionNegocio negocio;

        public ConfiguracionController(ConfiguracionNegocio configuracionNegocio)
        {
            this.negocio = configuracionNegocio;
        }

        // GET: api/Despachos
        [HttpGet("departamentos")]
        public List<Departamento> getDepartamentos()
        {
            return negocio.getDepartamentos();
        }

        [HttpGet("municipios")]
        public List<Municipio> getMunicipios()
        {
            return negocio.getMunicipios();
        }

        [HttpGet("estados/despacho")]
        public List<EstadoDespachos> getEstadosDespachos()
        {
            return negocio.getEstadosDespachos();
        }

        [HttpGet("estados/oferta")]
        public List<EstadoOfertas> getEstadosOfertas()
        {
            return negocio.getEstadosOfertas();
        }
    }
}
