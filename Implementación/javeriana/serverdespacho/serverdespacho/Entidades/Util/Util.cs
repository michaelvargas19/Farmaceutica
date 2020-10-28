using AutenticacionDTO.DTO;
using AutenticacionDTO.DTO.Cuentas;
using DespachosDTO.Catalogos;
using DespachosDTO.Despachos;
using DespachosDTO.Ofertas;
using DespachosDTO.Servicios;
using Microsoft.CodeAnalysis.CSharp;
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


        //------------- [Despachos]
        public static DespachoDTO obtenerDespachoDTO(Despacho despacho)
        {
            DespachoDTO dto = new DespachoDTO();
            dto.IdDespacho = despacho.IdDespacho;
            dto.Usuario = despacho.Usuario.FirstName + " " + despacho.Usuario.LastName;
            dto.Nombre = despacho.Nombre;
            dto.FechaInicio = despacho.FechaInicio;
            dto.FechaFinOfertas = despacho.FechaFinOfertas;
            dto.FechaCierreDespacho = despacho.FechaCierreDespacho;
            dto.IdEstado = despacho.IdEstado;
            dto.Estado = despacho.Estado.Nombre;
            dto.Ofertas = new List<OfertaDTO>();

            foreach (Oferta o in despacho.Ofertas) {
                dto.Ofertas.Add(getOfertaDTO(o));
            }

            return dto;
        }

        public static List<DespachoDTO> obtenerDespachosDTO(List<Despacho> despachos)
        {
            List<DespachoDTO> despachosDTO = new List<DespachoDTO>();

            foreach (Despacho d in despachos) {
                despachosDTO.Add(obtenerDespachoDTO(d));
            }

            return despachosDTO;
        }


        public static Despacho castDespachoToEntity(DespachoRequest request, Usuario usuario, EstadoDespachos estado)
        {
            Despacho despacho = new Despacho();
            despacho.Nombre = request.Nombre;
            despacho.Usuario = usuario;
            despacho.FechaInicio = request.FechaInicio;
            despacho.FechaFinOfertas = request.FechaFinOfertas;
            despacho.FechaCierreDespacho = request.FechaCierreDespacho;
            despacho.Estado = estado;
            despacho.IdMunicipioOrigen = request.IdMunicipioOrigen;
            despacho.IdMunicipioDestino = request.IdMunicipioDestino;

            return despacho;
        }

        //------------- [Ofertas]

        public static OfertaDTO getOfertaDTO(Oferta oferta) {
            
            OfertaDTO dto = new OfertaDTO();
            dto.IdOferta = oferta.IdOferta;
            dto.Usuario = oferta.Usuario.FirstName +" "+ oferta.Usuario.LastName;
            dto.FechaPostulacion = oferta.FechaPostulacion;
            dto.FechaFinalizacion = oferta.FechaFinalizacion;
            dto.Precio = oferta.Precio;
            dto.IdEstado = oferta.IdEstado;
            dto.Estado = oferta.Estado.Nombre;
            dto.IdDespacho = oferta.IdDespacho;
            dto.Mensaje = oferta.Despacho.Nombre;

            return dto;
        }


        public static List<OfertaDTO> obtenerOfertasDTO(List<Oferta> ofertas)
        {
            List<OfertaDTO> ofertasDTO = new List<OfertaDTO>();

            foreach (Oferta o in ofertas)
            {
                ofertasDTO.Add(getOfertaDTO(o));
            }

            return ofertasDTO;
        }


        public static Oferta castOfertaToEntity(OfertarRequest request, Usuario usuario, EstadoOfertas estado, Despacho despacho)
        {
            Oferta oferta = new Oferta();
            oferta.IdUsuario = usuario.Id;
            oferta.FechaPostulacion = DateTime.Now; ;
            oferta.FechaFinalizacion = null;
            oferta.Precio = request.Precio;
            oferta.IdEstado = estado.IdEstado;
            oferta.IdDespacho = despacho.IdDespacho;
            
            return oferta;
        }


        //------------- [catalogos]

        public static CatalogosDTO getCatalogoDTO(Catalogo catalogo)
        {

            CatalogosDTO dto = new CatalogosDTO();
            dto.IdCatalogo = catalogo.IdCatalogo;
            dto.Nombre = catalogo.Nombre;
            dto.FechaCreacion = catalogo.FechaCreacion;
            dto.Servicios = new List<ServicioDTO>();

            foreach(Servicio s in catalogo.Servicios)
            {
                dto.Servicios.Add(getServicioDTO(s));
            }

                        
            return dto;
        }


        //------------- [Servicios]

        public static ServicioDTO getServicioDTO(Servicio servicio)
        {

            ServicioDTO dto = new ServicioDTO();
            dto.IdServicio = servicio.IdServicio;
            dto.IdCatalogo = servicio.IdCatalogo;
            dto.Nombre = servicio.Nombre;
            dto.Descripcion = servicio.Descripcion;
            dto.IdMunicipioOrigen = servicio.IdMunicipioOrigen;
            dto.IdMunicipioDestino = servicio.IdMunicipioDestino;
            dto.Precio = servicio.Precio;
            
            return dto;
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
