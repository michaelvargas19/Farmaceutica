using AutenticacionDTO.DTO.Proceso;
using DespachosDTO.Ofertas;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using serverdespacho.Entidades;
using serverdespacho.Entidades.Util;
using serverdespacho.Peristencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace serverdespacho.Negocio
{
    public class OfertaNegocio : Controller
    {
        private readonly UserManager<Usuario> userManager;
        private readonly DBContext DBContext;


        public OfertaNegocio(UserManager<Usuario> userManager,
                               DBContext dbContext)
        {
            this.userManager = userManager;
            this.DBContext = dbContext;
        }

        public List<OfertaDTO> verOfertassActivas()
        {
            List<OfertaDTO> ofertasDTO = new List<OfertaDTO>();

            try
            {
                List<Oferta> ofertas = DBContext.Ofertas.Where(o => o.IdEstado == 1).Include(o=> o.Usuario).Include(o => o.Estado)
                                                       .Include(o => o.Despacho).ToList();
                DBContext.EstadosOfertas.ToList();
                ofertasDTO = Util.obtenerOfertasDTO(ofertas);

            }
            catch (Exception e)
            {
                DBContext.Log(Util.crearLog("Error", "Despachos", nameof(this.verOfertassActivas), true, this, e.Message, e.StackTrace.ToString()));
            }
            return ofertasDTO;
        }



        public OfertaDTO verOferta(int id)
        {
            OfertaDTO dto = new OfertaDTO();
            dto.exitoso = false;

            try
            {
                Oferta oferta = DBContext.Ofertas.Where(o => o.IdOferta == id).Include(o => o.Usuario).Include(o => o.Estado)
                                                       .Include(o => o.Despacho).ThenInclude(o => o.Usuario).FirstOrDefault();
                DBContext.EstadosDespachos.ToList();

                if (oferta != null)
                {
                    dto = Util.getOfertaDTO(oferta);
                    dto.exitoso = true;
                }
                else
                {
                    dto.Mensaje = "La oferta no exite";
                }

            }
            catch (Exception e)
            {
                dto.Mensaje = e.Message;
                DBContext.Log(Util.crearLog("Error", "Despachos", nameof(this.verOferta), true, this, e.Message, e.StackTrace.ToString()));
            }
            return dto;
        }


        public List<OfertaDTO> verOfertasPorUsuario(string username)
        {
            List<OfertaDTO> ofertasDTO = new List<OfertaDTO>();

            try
            {
                Usuario usuario = userManager.FindByNameAsync(username).Result;

                if (usuario != null)
                {
                    List<Oferta> ofertas = DBContext.Ofertas.Where(o => o.IdUsuario == usuario.Id).Include(o => o.Usuario)
                                                              .Include(o => o.Estado).Include(o => o.Despacho).OrderByDescending(o=> o.IdOferta).ToList();
                    DBContext.EstadosOfertas.ToList();

                    ofertasDTO = Util.obtenerOfertasDTO(ofertas);
                }


            }
            catch (Exception e)
            {
                DBContext.Log(Util.crearLog("Error", "Despachos", nameof(this.verOfertasPorUsuario), true, this, e.Message, e.StackTrace.ToString()));
            }
            return ofertasDTO;
        }


        public ResultadoResponse hacerOfertaADespacho(OfertarRequest request)
        {

            ResultadoResponse resultado = new ResultadoResponse();
            resultado.Proceso = "Hacer Oferta";
            resultado.Exitoso = false;

            try
            {

                Usuario usuario = userManager.FindByNameAsync(request.UserName).Result;

                if (usuario != null)
                {

                    Despacho despacho = DBContext.Despachos.Where(d => d.IdDespacho == request.IdDespacho).FirstOrDefault();

                    if (despacho != null)
                    {

                        EstadoOfertas estado = DBContext.EstadosOfertas.Where(e => e.IdEstado == 1).FirstOrDefault();

                        if (estado != null)
                        {

                            Oferta oferta = Util.castOfertaToEntity(request, usuario, estado,despacho);

                            //Notificar al proveedor solicitud de servicio
                            Notificacion notificacion = new Notificacion();
                            notificacion.IdUsuario = oferta.IdUsuario;
                            notificacion.IdTipoNotificacion = 1;
                            notificacion.Mensaje = "Se ha hecho una nueva oferta la despacho " + despacho.Nombre;
                            notificacion.MensajeCorto = "Se ha hecho una nueva oferta";
                            notificacion.FechaEnvio = DateTime.Now;
                            notificacion.Entregada = false;

                            DBContext.Notificaciones.Add(notificacion);
                            DBContext.Ofertas.Add(oferta);
                            DBContext.SaveChanges();

                            resultado.Mensaje = "Oferta registrada";
                            resultado.Exitoso = true;
                        }
                        else
                        {
                            resultado.Mensaje = "No existe el estado a asignar";
                        }
                    }
                    else 
                    {
                        resultado.Mensaje = "El despacho no existe";
                    }
                }
                else
                {
                    resultado.Mensaje = "El usuario no existe";
                }

            }
            catch (Exception e)
            {
                resultado.Mensaje = e.Message;
                DBContext.Log(Util.crearLog("Error", "Despachos", nameof(this.hacerOfertaADespacho), true, this, e.Message, e.StackTrace.ToString()));
            }

            return resultado;

        }



        public ResultadoResponse actualizarEstado(RequestEstadoOferta request)
        {

            ResultadoResponse resultado = new ResultadoResponse();
            resultado.Proceso = "Actualizar Estado";
            resultado.Exitoso = false;

            try
            {

                EstadoOfertas estado = DBContext.EstadosOfertas.Where(e => e.IdEstado == request.IdEstado).FirstOrDefault();

                if (estado != null)
                {

                    Oferta oferta = DBContext.Ofertas.Where(d => d.IdOferta == request.IdOferta).Include(d => d.Estado).Include(d=> d.Despacho).ThenInclude(d=>d.Usuario).FirstOrDefault();

                    if (oferta != null)
                    {
                        if ((request.IdEstado == 3) || (request.IdEstado == 4) || (request.IdEstado == 5))
                        {
                            if ((oferta.IdEstado == 1) || (oferta.IdEstado == 2))
                            {

                                if(request.IdEstado == 4)
                                {
                                    //Despacho Entregado
                                    oferta.Despacho.IdEstado = 6;

                                    //Notificar aceptación de oferta
                                    Notificacion notificacion = new Notificacion();
                                    notificacion.IdUsuario = oferta.Despacho.Usuario.Id;
                                    notificacion.IdTipoNotificacion = 1;
                                    notificacion.Mensaje = "Se ha cerrado la oferta " + oferta.Despacho.Nombre;
                                    notificacion.MensajeCorto = "Se ha cerrado una de tus ofertas";
                                    notificacion.FechaEnvio = DateTime.Now;
                                    notificacion.Entregada = false;

                                    DBContext.Notificaciones.Add(notificacion);
                                }

                                oferta.IdEstado = estado.IdEstado;
                                DBContext.Entry(oferta);
                                DBContext.SaveChanges();

                                resultado.Mensaje = "Oferta Actualizada";
                                resultado.Exitoso = true;
                            }
                            else
                            {
                                resultado.Mensaje = "La oferta está en: " + oferta.Estado.Nombre;
                            }
                        }
                        else
                        {
                            resultado.Mensaje = "La operación no es válida";
                        }
                    }
                    else
                    {
                        resultado.Mensaje = "La oferta no es correcta";
                    }

                }
                else
                {
                    resultado.Mensaje = "No existe el estado a asignar";
                }

            }
            catch (Exception e)
            {
                resultado.Mensaje = e.Message;
            }

            return resultado;

        }
    }
}
