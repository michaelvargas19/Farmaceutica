using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutenticacionDTO.DTO;
using AutenticacionDTO.DTO.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using serverdespacho.Seguridad;

namespace serverdespacho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthNegocio negocio;

        public AuthController(AuthNegocio authNegocio)
        {
            this.negocio = authNegocio;
        }   

        public LoginResponse Post([FromBody] LoginRequest cuenta)
        {
            LoginResponse response = new LoginResponse();
            response.Autenticacion = false;
            response.Bloqueado = false;

            if (!cuenta.datosParaLogin())
            {
                Response.StatusCode = 202;
                response.Mensaje = "Solicitud Inválida";
                return response;
            }
            TokenJWT token = null;
            try
            {
                token = negocio.iniciarSesion(cuenta).Result;
                Response.StatusCode = 201;

            }
            catch (Exception e)
            {
                Response.StatusCode = 203;
                response.Mensaje = e.Message;
                return response;
            }

            if (token == null)
            {
                Response.StatusCode = 203;
                response.Mensaje = "Inicio de Sesión Inválido";
                return response;
            }

            //LDAP Account Locked
            if (String.IsNullOrEmpty(token.Token))
            {
                Response.StatusCode = 203;
                response.Bloqueado = true;
                response.Mensaje = "Cuenta bloqueada.";
                return response;
            }

            response.Autenticacion = true;
            response.TokenJWT = token.Token;
            response.Mensaje = "Sesión Iniciada";

            return response;

        }

    }
}
