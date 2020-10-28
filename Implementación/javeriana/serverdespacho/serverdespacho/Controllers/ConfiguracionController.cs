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

        // GET: api/configuracion/departamentos
        [HttpGet("departamentos")]
        public List<Departamento> getDepartamentos()
        {
            return negocio.getDepartamentos();
        }

        // GET: api/configuracion/municipios
        [HttpGet("municipios")]
        public List<Municipio> getMunicipios()
        {
            return negocio.getMunicipios();
        }

        // GET: api/configuracion/estados/despacho
        [HttpGet("estados/despacho")]
        public List<EstadoDespachos> getEstadosDespachos()
        {
            return negocio.getEstadosDespachos();
        }

        // GET: api/configuracion/estados/oferta
        [HttpGet("estados/oferta")]
        public List<EstadoOfertas> getEstadosOfertas()
        {
            return negocio.getEstadosOfertas();
        }
    }
}
