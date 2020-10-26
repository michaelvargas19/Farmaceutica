using AutenticacionDTO.DTO.Proceso;
using DespachosDTO.Despachos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using serverdespacho.Entidades;
using serverdespacho.Entidades.Util;
using serverdespacho.Peristencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace serverdespacho.Negocio
{
    public class DespachoNegocio : Controller
    {
        private readonly UserManager<Usuario> userManager;
        private readonly DBContext DBContext;


        public DespachoNegocio(UserManager<Usuario> userManager,
                               DBContext dbContext)
        {
            this.userManager = userManager;
            this.DBContext = dbContext;
        }


        public List<DespachoDTO> verDespachosActivos()
        {
            List<DespachoDTO> despachosDTO = new List<DespachoDTO>();

            try
            {
                List<Despacho> despachos = DBContext.Despachos.Where(d => d.IdEstado == 1).Include(d => d.Usuario).Include(d => d.Estado)
                                                       .Include(d => d.Ofertas).ThenInclude(o => o.Usuario).OrderByDescending(d=> d.IdDespacho).ToList();
                DBContext.EstadosOfertas.ToList();
                despachosDTO = Util.obtenerDespachosDTO(despachos);

            }
            catch (Exception e)
            {
                DBContext.Log(Util.crearLog("Error", "Despachos", nameof(this.verDespacho), true, this, e.Message, e.StackTrace.ToString()));
            }
            return despachosDTO;
        }



        public DespachoDTO verDespacho(int id)
        {
            DespachoDTO dto = new DespachoDTO();
            dto.exitoso = false;

            try
            {
                Despacho despacho = DBContext.Despachos.Where(d => d.IdDespacho == id).Include(d=> d.Usuario).Include(d=> d.Estado)
                                                       .Include(d=> d.Ofertas).ThenInclude(o=> o.Usuario).FirstOrDefault();
                DBContext.EstadosOfertas.ToList();

                if (despacho != null)
                {
                    dto = Util.obtenerDespachoDTO(despacho);
                    dto.exitoso = true;
                }
                else{
                    dto.Mensaje = "El despacho no exite";
                }

            }
            catch (Exception e)
            {
                dto.Mensaje = e.Message;
                DBContext.Log(Util.crearLog("Error", "Despachos", nameof(this.verDespacho), true, this, e.Message, e.StackTrace.ToString()));
            }
            return dto;
        }


        public List<DespachoDTO> verDespachosPorUsuario(string username)
        {
            List<DespachoDTO> despachosDTO = new List<DespachoDTO>();
            
            try
            {
                Usuario usuario = userManager.FindByNameAsync(username).Result;

                if (usuario != null)
                {
                    List<Despacho> despachos = DBContext.Despachos.Where(d => d.IdUsuario == usuario.Id).Include(d => d.Usuario)
                                                              .Include(d => d.Estado).Include(d => d.Ofertas).ThenInclude(o => o.Usuario).ToList();
                    DBContext.EstadosDespachos.ToList();

                    despachosDTO = Util.obtenerDespachosDTO(despachos);
                }
               

            }
            catch (Exception e)
            {
                DBContext.Log(Util.crearLog("Error", "Despachos", nameof(this.verDespachosPorUsuario), true, this, e.Message, e.StackTrace.ToString()));
            }
            return despachosDTO;
        }


        public ResultadoResponse ofertarDespacho(DespachoRequest request) {

            ResultadoResponse resultado = new ResultadoResponse();
            resultado.Proceso = "Ofertar Servicio";
            resultado.Exitoso = false;

            try { 

            Usuario usuario = userManager.FindByNameAsync(request.UserName).Result;

            if (usuario != null) {

                EstadoDespachos estado = DBContext.EstadosDespachos.Where(e => e.IdEstado == 1).FirstOrDefault();

                if (estado != null) {

                    Despacho despacho = Util.castDespachoToEntity(request,usuario,estado);
                    DBContext.Despachos.Add(despacho);
                    DBContext.SaveChanges();

                    resultado.Mensaje = "Despacho ofertado";
                    resultado.Exitoso = true;
                }
                else {
                    resultado.Mensaje = "No existe el estado a asignar";
                }
            }   
            else {
                resultado.Mensaje = "El usuario no existe";
            }

            }
            catch (Exception e) {
                resultado.Mensaje = e.Message;
            }

            return resultado;

        }


        public ResultadoResponse seleccionarOferta(RequestSeleccionarOferta request)
        {

            ResultadoResponse resultado = new ResultadoResponse();
            resultado.Proceso = "Seleccionar Oferta";
            resultado.Exitoso = false;

            try
            {
                Despacho despacho = DBContext.Despachos.Where(d => d.IdDespacho == request.IdDespacho).FirstOrDefault();               

                if (despacho != null)
                {

                    Oferta oferta = DBContext.Ofertas.Where(o => o.IdOferta == request.IdOferta && o.IdEstado == 1).FirstOrDefault();

                    if (oferta != null)
                    {
                        //Despacho cerrado
                        despacho.IdEstado = 3;
                        
                        //Oferta Aceptada
                        oferta.IdEstado = 2;

                        List<Oferta> ofertas = DBContext.Ofertas.Where(o=> o.IdDespacho == despacho.IdDespacho && o.IdEstado == 1 && o.IdOferta != oferta.IdOferta).ToList();

                        foreach (Oferta o in ofertas) {
                            o.IdEstado = 3;
                            DBContext.Entry(o);
                        }

                        DBContext.Entry(despacho);
                        DBContext.Entry(oferta);
                        DBContext.SaveChanges();

                        resultado.Mensaje = "Oferta Cerrada";
                        resultado.Exitoso = true;
                    }
                    else
                    {
                        resultado.Mensaje = "La oferta no existe";
                    }
                }
                else
                {
                    resultado.Mensaje = "El despacho no existe";
                }

            }
            catch (Exception e)
            {
                resultado.Mensaje = e.Message;
            }

            return resultado;

        }


        public ResultadoResponse actualizarEstado(RequestEstadoDespacho request)
        {

            ResultadoResponse resultado = new ResultadoResponse();
            resultado.Exitoso = false;

            try
            {

                EstadoDespachos estado = DBContext.EstadosDespachos.Where(e => e.IdEstado == request.IdEstado).FirstOrDefault();

                if (estado != null)
                {

                    Despacho despacho = DBContext.Despachos.Where(d => d.IdDespacho == request.IdDespacho).Include(d=> d.Estado).FirstOrDefault();
                    
                    if (despacho != null) 
                    {
                        if ((request.IdEstado==4) || (request.IdEstado == 5) || (request.IdEstado == 6)) { 

                            if ((despacho.IdEstado==3) || (despacho.IdEstado == 4) || (despacho.IdEstado == 5)) {
                        
                                despacho.Estado = estado;
                                DBContext.Entry(despacho);
                                DBContext.SaveChanges();

                                resultado.Mensaje = "Despacho Actualizado";
                                resultado.Exitoso = true;
                            }
                            else
                            {
                                resultado.Mensaje = "El despacho está en: "+despacho.Estado.Nombre;
                            }
                        }
                        else
                        {
                            resultado.Mensaje = "La operación no es válida";
                        }
                    }
                    else
                    {
                        resultado.Mensaje = "El despacho no es correcto";
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
