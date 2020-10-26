using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutenticacionDTO.DTO.Proceso;
using DespachosDTO.Despachos;
using Google.Protobuf.WellKnownTypes;
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

        // GET: api/Despachos
        [HttpGet]
        public List<DespachoDTO> Get()
        {
            return negocio.verDespachosActivos();
        }

        // GET: api/Despachos/#
        [HttpGet("{id}")]
        public DespachoDTO GetUser(int id)
        {
            return negocio.verDespacho(id);
        }


        // GET: api/Despachos/#
        [HttpGet("usuario/{username}")]
        public List<DespachoDTO> GetByUser(string username)
        {
            return negocio.verDespachosPorUsuario(username);
        }

        // POST: api/Despachos
        [HttpPost("ofertar")]
        public ResultadoResponse OfertarDespacho(DespachoRequest request)
        {
            return negocio.ofertarDespacho(request);
        }

        // PUT: api/Despachos/estado
        [HttpPut("estado")]
        public ResultadoResponse actualizarEstado(RequestEstadoDespacho request)
        {
            return negocio.actualizarEstado(request);
        }

    }
}
