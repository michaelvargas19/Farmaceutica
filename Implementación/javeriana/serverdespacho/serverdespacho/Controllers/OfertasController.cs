using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutenticacionDTO.DTO.Proceso;
using DespachosDTO.Ofertas;
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

        //GET: api/Ofertas
        [HttpGet]
        public List<OfertaDTO> Get()
        {
            return negocio.verOfertassActivas();
        }

        // GET: api/Ofertas/#
        [HttpGet("{id}")]
        public OfertaDTO GetUser(int id)
        {
            return negocio.verOferta(id);
        }


        // GET: api/Ofertas/#
        [HttpGet("usuario/{username}")]
        public List<OfertaDTO> GetByUser(string username)
        {
            return negocio.verOfertasPorUsuario(username);
        }

        // POST: api/Ofertas
        [HttpPost]
        public ResultadoResponse OfertarDespacho(OfertarRequest request)
        {
            return negocio.hacerOfertaADespacho(request);
        }

        // PUT: api/Ofertas/estado
        [HttpPut("estado")]
        public ResultadoResponse actualizarEstado(RequestEstadoOferta request)
        {
            return negocio.actualizarEstado(request);
        }


    }
}
