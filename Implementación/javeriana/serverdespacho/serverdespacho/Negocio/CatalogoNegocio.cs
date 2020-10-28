using AutenticacionDTO.DTO.Proceso;
using DespachosDTO.Catalogos;
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
    public class CatalogoNegocio
    {
        private readonly UserManager<Usuario> userManager;
        private readonly DBContext DBContext;


        public CatalogoNegocio(UserManager<Usuario> userManager, 
                               DBContext dbContext)
        {
            this.userManager = userManager;
            this.DBContext = dbContext;
        }


        public List<CatalogosDTO> verCatalogos()
        {
            List<CatalogosDTO> catalogosDTO = new List<CatalogosDTO>();

            try
            {
                List<Catalogo> catalogos = DBContext.Catalogo.Include(c=> c.Usuario).Include(c => c.Servicios).ThenInclude(s=> s.MunicipioOrigen)
                                                             .Include(c => c.Servicios).ThenInclude(s => s.MunicipioOrigen)
                                                             .Include(c => c.Servicios).ThenInclude(s => s.MunicipioDestino)
                                                             .OrderByDescending(d => d.IdCatalogo).ToList();

                foreach(Catalogo c in catalogos)
                {
                    catalogosDTO.Add(Util.getCatalogoDTO(c));
                }
                
            }
            catch (Exception e)
            {
                DBContext.Log(Util.crearLog("Error", "Despachos", nameof(this.verCatalogos), true, this, e.Message, e.StackTrace.ToString()));
            }
            return catalogosDTO;
        }



        public CatalogosDTO verCatalogo(int idCatalogo)
        {
            CatalogosDTO catalogoDTO = new CatalogosDTO();
            catalogoDTO.Exitoso = false;

            try
            {
                Catalogo catalogo = DBContext.Catalogo.Where(c=> c.IdCatalogo == idCatalogo).Include(c => c.Usuario).Include(c => c.Servicios).ThenInclude(s => s.MunicipioOrigen)
                                                             .Include(c => c.Servicios).ThenInclude(s => s.MunicipioOrigen).Include(c => c.Servicios).ThenInclude(s => s.MunicipioDestino)
                                                             .OrderByDescending(d => d.IdCatalogo).FirstOrDefault();

                if(catalogo != null)
                {
                    catalogoDTO = Util.getCatalogoDTO(catalogo);
                    catalogoDTO.Exitoso = true;
                }
                else
                {
                    catalogoDTO.Mensaje = "El catálogo no existe";
                }


            }
            catch (Exception e)
            {
                DBContext.Log(Util.crearLog("Error", "Despachos", nameof(this.verCatalogos), true, this, e.Message, e.StackTrace.ToString()));
                catalogoDTO.Mensaje = e.Message;
            }
            return catalogoDTO;
        }


        public List<CatalogosDTO> verCatalogosPorUsuario(string username)
        {
            List<CatalogosDTO> catalogosDTO = new List<CatalogosDTO>();

            try
            {
                List<Catalogo> catalogos = DBContext.Catalogo.Where(c=>c.Usuario.UserName==username).Include(c => c.Usuario).Include(c => c.Servicios).ThenInclude(s => s.MunicipioOrigen)
                                                             .Include(c => c.Servicios).ThenInclude(s => s.MunicipioOrigen)
                                                             .Include(c => c.Servicios).ThenInclude(s => s.MunicipioDestino)
                                                             .OrderByDescending(d => d.IdCatalogo).ToList();

                foreach (Catalogo c in catalogos)
                {
                    catalogosDTO.Add(Util.getCatalogoDTO(c));
                }

            }
            catch (Exception e)
            {
                DBContext.Log(Util.crearLog("Error", "Despachos", nameof(this.verCatalogos), true, this, e.Message, e.StackTrace.ToString()));
            }
            return catalogosDTO;
        }



        public ResultadoResponse agregarCatalogo(RequestCatalogos request)
        {

            ResultadoResponse resultado = new ResultadoResponse();
            resultado.Proceso = "Agregar Catálogo";
            resultado.Exitoso = false;

            try
            {

                Usuario usuario = userManager.FindByNameAsync(request.Proveedor).Result;

                if (usuario != null)
                {
                    Catalogo catalogo = new Catalogo();
                    catalogo.IdUsuario = usuario.Id;
                    catalogo.Nombre = request.Nombre;
                    catalogo.FechaCreacion = DateTime.Now;

                    DBContext.Catalogo.Add(catalogo);
                    DBContext.SaveChanges();

                    resultado.Mensaje = "Catalogo registrado";
                    resultado.Exitoso = true;
                    
                }
                else
                {
                    resultado.Mensaje = "El usuario no existe";
                }

            }
            catch (Exception e)
            {
                resultado.Mensaje = e.Message;
                DBContext.Log(Util.crearLog("Error", "Despachos", nameof(this.agregarCatalogo), true, this, e.Message, e.StackTrace.ToString()));
            }

            return resultado;

        }



    }
}
