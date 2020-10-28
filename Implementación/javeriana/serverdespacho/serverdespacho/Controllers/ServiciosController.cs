using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutenticacionDTO.DTO.Proceso;
using DespachosDTO.Catalogos;
using DespachosDTO.Servicios;
using Microsoft.AspNetCore.Mvc;
using serverdespacho.Negocio;
using Ubiety.Dns.Core;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace serverdespacho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {

        private readonly ServicioNegocio negocio;

        public ServiciosController(ServicioNegocio servicioNegocio) {
            this.negocio = servicioNegocio;
        }

        // GET: api/Servicios

        [HttpGet]
        public List<ServicioDTO> Get()
        {
            return negocio.verServicios();
        }


        // GET: api/Servicios/#

        [HttpGet("{id}")]
        public ServicioDTO Get(int id)
        {
            return negocio.verServicio(id);
        }


        // GET: api/Servicios/proveedor/#

        [HttpGet("destinos/{idMunicipioOrigen}/{idMunicipioDestino}")]
        public List<ServicioDTO> Get(int idMunicipioOrigen, int idMunicipioDestino)
        {
            return negocio.verServiciosAplicados(idMunicipioOrigen, idMunicipioDestino);
        }


        // POST: api/Servicios

        [HttpPost]
        public ResultadoResponse Post(ServicioRequest request)
        {
            return negocio.agregarServicio(request);
        }


        // POST: api/Servicios/solicitar

        [HttpPost("solicitar")]
        public ResultadoResponse solicitarServicio(SolicitarServicioRequest request)
        {
            return negocio.solicitarServicio(request);
        }

    }
}
