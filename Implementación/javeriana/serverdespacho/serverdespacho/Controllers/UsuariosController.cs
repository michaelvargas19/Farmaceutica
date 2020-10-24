using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutenticacionDTO.DTO;
using AutenticacionDTO.DTO.Proceso;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using serverdespacho.Entidades;
using serverdespacho.Negocio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace serverdespacho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioNegocio negocio;

        public UsuariosController(UsuarioNegocio usuarioNegocio) {
            this.negocio = usuarioNegocio;
        }

        // GET: api/Usuarios
        [HttpGet]
        public List<UsuarioDTO> Get()
        {
            return negocio.verUsuarios();
        }

        [HttpGet("{userName}")]
        public UsuarioDTO GetUser(string userName)
        {
            return negocio.verUsuario(userName);
        }

        // POST: Usuarios
        [HttpPost]
        public ResultadoResponse Create(UsuarioDTO usuario)
        {
            ResultadoResponse response = new ResultadoResponse();
            response.Proceso = "Crear usuario";
            response.Exitoso = false;

            if (ModelState.IsValid)
            {
                IdentityResult result = negocio.CreateUserAsync(usuario).Result;
                if (result.Succeeded)
                {
                    response.Exitoso = true;
                }
                else
                {
                    response.Exitoso = false;
                    response.Mensaje = result.Errors.ToList()[0].Description;
                }
            }

            return response;

        }
    }
}
