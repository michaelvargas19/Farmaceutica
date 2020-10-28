using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutenticacionDTO.DTO.Proceso;
using DespachosDTO.Catalogos;
using Microsoft.AspNetCore.Mvc;
using serverdespacho.Negocio;
using Ubiety.Dns.Core;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace serverdespacho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogosController : ControllerBase
    {

        private readonly CatalogoNegocio negocio;

        public CatalogosController(CatalogoNegocio catalogoNegocio) {
            this.negocio = catalogoNegocio;
        }

        // GET: api/Catalogos

        [HttpGet]
        public List<CatalogosDTO> Get()
        {
            return negocio.verCatalogos();
        }


        // GET: api/Catalogos/#

        [HttpGet("{id}")]
        public CatalogosDTO Get(int id)
        {
            return negocio.verCatalogo(id);
        }


        // GET: api/Catalogos/proveedor/#

        [HttpGet("proveedor/{username}")]
        public List<CatalogosDTO> Get(string username)
        {
            return negocio.verCatalogosPorUsuario(username);
        }


        // POST: api/Catalogos

        [HttpPost]
        public ResultadoResponse Post(RequestCatalogos request)
        {
            return negocio.agregarCatalogo(request);
        }

    }
}
