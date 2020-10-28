using AutenticacionDTO.DTO.Proceso;
using DespachosDTO.Catalogos;
using DespachosDTO.Servicios;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using serverdespacho.Entidades;
using serverdespacho.Entidades.Util;
using serverdespacho.Peristencia;
using System;
using System.Collections.Generic;
using System.Linq;

namespace serverdespacho.Negocio
{
    public class ServicioNegocio
    {
        private readonly UserManager<Usuario> userManager;
        private readonly DBContext DBContext;


        public ServicioNegocio(UserManager<Usuario> userManager, 
                               DBContext dbContext)
        {
            this.userManager = userManager;
            this.DBContext = dbContext;
        }


        public List<ServicioDTO> verServicios()
        {
            List<ServicioDTO> serviciosDTO = new List<ServicioDTO>();

            try
            {
                List<Servicio> servicios = DBContext.Servicios.Include(s=> s.Catalogo).Include(s => s.MunicipioOrigen)
                                                              .Include(s => s.MunicipioDestino)
                                                              .OrderByDescending(d => d.IdServicio).ToList();

                foreach(Servicio s in servicios)
                {
                    serviciosDTO.Add(Util.getServicioDTO(s));
                }
                
            }
            catch (Exception e)
            {
                DBContext.Log(Util.crearLog("Error", "Despachos", nameof(this.verServicios), true, this, e.Message, e.StackTrace.ToString()));
            }

            return serviciosDTO;
        }



        public ServicioDTO verServicio(int idServicio)
        {
            ServicioDTO servicioDTO = new ServicioDTO();
            servicioDTO.Exitoso = false;

            try
            {
                Servicio servicio = DBContext.Servicios.Where(s=> s.IdServicio == idServicio).Include(s => s.Catalogo).Include(s => s.MunicipioOrigen)
                                                              .Include(s => s.MunicipioDestino).FirstOrDefault();

                if (servicio != null)
                {
                    servicioDTO = Util.getServicioDTO(servicio);
                    servicioDTO.Exitoso = true;
                }
                else
                {
                    servicioDTO.Mensaje = "El catálogo no existe";
                }


            }
            catch (Exception e)
            {
                DBContext.Log(Util.crearLog("Error", "Despachos", nameof(this.verServicio), true, this, e.Message, e.StackTrace.ToString()));
                servicioDTO.Mensaje = e.Message;
            }
            return servicioDTO;
        }


        public List<ServicioDTO> verServiciosAplicados(int idMunicipioOrigen, int idMunicipioDestino)
        {
            List<ServicioDTO> serviciosDTO = new List<ServicioDTO>();

            try
            {
                List<Servicio> servicios = DBContext.Servicios.Where(s=> s.IdMunicipioOrigen==idMunicipioOrigen && s.IdMunicipioDestino==idMunicipioDestino)
                                                              .Include(s => s.Catalogo).Include(s => s.MunicipioOrigen)
                                                              .Include(s => s.MunicipioDestino)
                                                              .OrderByDescending(d => d.IdServicio).ToList();

                foreach (Servicio s in servicios)
                {
                    serviciosDTO.Add(Util.getServicioDTO(s));
                }

            }
            catch (Exception e)
            {
                DBContext.Log(Util.crearLog("Error", "Despachos", nameof(this.verServicios), true, this, e.Message, e.StackTrace.ToString()));
            }

            return serviciosDTO;
        }


        public ResultadoResponse agregarServicio(ServicioRequest request)
        {

            ResultadoResponse resultado = new ResultadoResponse();
            resultado.Proceso = "Agregar Servicios";
            resultado.Exitoso = false;

            try
            {

                Usuario usuario = userManager.FindByNameAsync(request.Proveedor).Result;

                if (usuario != null)
                {
                    Catalogo catalogo = DBContext.Catalogo.Where(c => c.IdCatalogo == request.IdCatalogo).FirstOrDefault();

                    if (catalogo != null) {

                        if((DBContext.Municipios.Any(m=> m.CodigoDane==request.IdMunicipioOrigen)) && (DBContext.Municipios.Any(m => m.CodigoDane == request.IdMunicipioDestino)))
                        {

                            Servicio servicio = new Servicio();
                            servicio.IdCatalogo = catalogo.IdCatalogo;
                            servicio.Nombre = request.Nombre;
                            servicio.Descripcion = request.Descripcion;
                            servicio.IdMunicipioOrigen = request.IdMunicipioOrigen;
                            servicio.IdMunicipioDestino = request.IdMunicipioDestino;
                            servicio.Precio = request.Precio;

                            DBContext.Servicios.Add(servicio);
                            DBContext.SaveChanges();

                            resultado.Mensaje = "Servicio registrado";
                            resultado.Exitoso = true;

                        }else {
                            resultado.Mensaje = "Los municipios son incorrectos";
                        }

                    }
                    else {
                        resultado.Mensaje = "El catálogo no existe";
                    }
                }
                else
                {
                    resultado.Mensaje = "El proveedor no existe";
                }

            }
            catch (Exception e)
            {
                resultado.Mensaje = e.Message;
                DBContext.Log(Util.crearLog("Error", "Despachos", nameof(this.agregarServicio), true, this, e.Message, e.StackTrace.ToString()));
            }

            return resultado;

        }
        
        
        
        public ResultadoResponse solicitarServicio(SolicitarServicioRequest request)
        {

            ResultadoResponse resultado = new ResultadoResponse();
            resultado.Proceso = "Solicitar Servicios";
            resultado.Exitoso = false;

            try
            {

                Servicio servicio = DBContext.Servicios.Where(s=> s.IdServicio==request.IdServicio).FirstOrDefault();

                if (servicio != null)
                {
                    Despacho despacho = DBContext.Despachos.Where(d => d.IdDespacho == request.IdDespacho && (d.IdEstado == 1 || d.IdEstado == 2))
                                                           .Include(d=> d.MunicipioOrigen).Include(d => d.MunicipioDestino)
                                                           .Include(d=> d.Usuario).FirstOrDefault();

                    if (despacho != null) {

                        if((servicio.IdMunicipioOrigen==despacho.IdMunicipioOrigen) && (servicio.IdMunicipioDestino==despacho.IdMunicipioDestino))
                        {

                            Oferta oferta = new Oferta();
                            oferta.IdUsuario = despacho.IdUsuario;
                            oferta.FechaPostulacion = DateTime.Now;
                            oferta.FechaFinalizacion = null;
                            oferta.Precio = servicio.Precio;
                            oferta.IdEstado = 2;
                            oferta.IdDespacho = despacho.IdDespacho;

                            despacho.IdEstado = 3;

                            //Notificar al proveedor solicitud de servicio
                            Notificacion notificacion = new Notificacion();
                            notificacion.IdUsuario = oferta.IdUsuario;
                            notificacion.IdTipoNotificacion = 1;
                            notificacion.Mensaje = "Se ha solicitado un servicio de despacho desde " + despacho.MunicipioOrigen.Nombre + " hasta "+despacho.MunicipioDestino.Nombre;
                            notificacion.MensajeCorto = "Se ha solicitado un servicio";
                            notificacion.FechaEnvio = DateTime.Now;
                            notificacion.Entregada = false;


                            DBContext.Notificaciones.Add(notificacion);
                            DBContext.Ofertas.Add(oferta);
                            DBContext.Entry(despacho);
                            DBContext.SaveChanges();

                            resultado.Mensaje = "Servicio registrado";
                            resultado.Exitoso = true;

                        }
                        else {
                            resultado.Mensaje = "El despacho es incorrecto";
                        }

                    }
                    else {
                        resultado.Mensaje = "El despacho no existe";
                    }
                }
                else
                {
                    resultado.Mensaje = "El servicio no existe";
                }

            }
            catch (Exception e)
            {
                resultado.Mensaje = e.Message;
                DBContext.Log(Util.crearLog("Error", "Despachos", nameof(this.agregarServicio), true, this, e.Message, e.StackTrace.ToString()));
            }

            return resultado;

        }



    }
}
