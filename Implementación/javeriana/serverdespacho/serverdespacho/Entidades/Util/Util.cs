using AutenticacionDTO.DTO;
using AutenticacionDTO.DTO.Cuentas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace serverdespacho.Entidades.Util
{
    public static class Util
    {

        //------------- [Usuarios]
        public static UsuarioDTO obtenerUsuario(Usuario user)
        {
            UsuarioDTO usuario = new UsuarioDTO();
            usuario.Id = user.Id;
            usuario.UserName = user.UserName;
            usuario.Nombres = user.FirstName;
            usuario.Apellidos = user.LastName;
            usuario.Correo = user.Email;
            usuario.Telefono = user.PhoneNumber;
            usuario.Area = user.Area;
            usuario.Organizacion = user.Organization;

            return usuario;
        }

        public static Usuario castUsuarioToIdentity(UsuarioDTO u)
        {
            Usuario user = new Usuario();
            user.Id = u.Id;
            user.UserName = u.UserName;
            user.FirstName = u.Nombres;
            user.LastName = u.Apellidos;
            user.Email = u.Correo;
            user.PhoneNumber = u.Telefono;
            user.Area = u.Area;
            user.Organization = u.Organizacion;

            return user;
        }

        #region newLog
        public static AppLogAuthenticacionAPI crearLog(string type, string app, string method, bool isException, Object entity, string message, object parameters)
        {

            AppLogAuthenticacionAPI log = new AppLogAuthenticacionAPI();
            log.Type = type;
            log.Date = DateTime.Now;
            log.Application = app;
            log.Method = method;
            log.IsException = isException;
            log.Entity = entity.ToString();
            log.Message = message;

            string json = JsonConvert.SerializeObject(parameters);
            log.Parameters = json;

            return log;
        }
        #endregion

    }
}
