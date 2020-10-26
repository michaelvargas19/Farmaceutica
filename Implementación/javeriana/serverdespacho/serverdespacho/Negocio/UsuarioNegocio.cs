using AutenticacionDTO.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    public class UsuarioNegocio : Controller
    {
        private readonly UserManager<Usuario> userManager;
        private readonly DBContext DBContext;

        public UsuarioNegocio(IConfiguration configuration,
                                      UserManager<Usuario> userManager,
                                      DBContext dbContext)
        {
            this.userManager = userManager;
            this.DBContext = dbContext;
        }

        public List<UsuarioDTO> verUsuarios()
        {
            List<UsuarioDTO> usuarios = new List<UsuarioDTO>();

            try
            {
                UsuarioDTO user = new UsuarioDTO();
                user.exitoso = false;

                List<Usuario> appUsers = userManager.Users.ToList();
                List<Rol> roles = DBContext.Roles.ToList();

                foreach (Usuario u in appUsers)
                {
                    user = Util.obtenerUsuario(u);
                    user.exitoso = true;
                    user.Roles = new List<int>();
                    
                    foreach (Rol rol in roles)
                    {
                        if (userManager.IsInRoleAsync(u, rol.Name).Result)
                        {
                            user.Roles.Add(rol.Id);
                        }
                    }

                    usuarios.Add(user);
                }

            }
            catch (Exception e)
            {
                
                DBContext.Log(Util.crearLog("Error", "Despachos", nameof(this.verUsuarios), true, this, e.Message, e.StackTrace.ToString()));
            }
            return usuarios;
        }


        public UsuarioDTO verUsuario(string usuario)
        {
            UsuarioDTO user = new UsuarioDTO();
            user.exitoso = false;

            try
            {
                usuario = usuario.Contains("@") ? usuario.Split("@")[0] : usuario;
                Usuario appUser = userManager.FindByNameAsync(usuario).Result;
                
                if (appUser != null)
                {
                    user = Util.obtenerUsuario(appUser);
                    user.exitoso = true;
                    user.Roles = new List<int>();
                    List<Rol>roles = DBContext.Roles.ToList();
                    
                    foreach (Rol rol in roles)
                    {
                        if (userManager.IsInRoleAsync(appUser, rol.Name).Result)
                        {
                            user.Roles.Add(rol.Id);
                        }
                    }

                }

            }
            catch (Exception e)
            {
                user = null;

                DBContext.Log(Util.crearLog("Error", "Despachos", nameof(this.verUsuario), true, this, e.Message, e.StackTrace.ToString()));
            }
            return user;
        }



        public async Task<IdentityResult> CreateUserAsync(UsuarioDTO user)
        {
            try
            {
                IdentityResult result = userManager.CreateAsync(Util.castUsuarioToIdentity(user), user.Contrasena).Result;

                if (result.Succeeded)
                {
                    Usuario appUser = userManager.FindByNameAsync(user.UserName).Result;

                    foreach (int rol in user.Roles)
                    {
                        Rol rolApp = DBContext.Roles.Where(r => r.Id == rol).Single();

                        if ((appUser != null) && (rolApp != null))
                        {

                            IdentityUserRole<int> role = new IdentityUserRole<int>();
                            role.RoleId = rolApp.Id;
                            role.UserId = appUser.Id;

                            DBContext.UserRoles.Add(role);
                            await DBContext.SaveChangesAsync();
                            result = IdentityResult.Success;
                        }
                    }
                }

                return result;

            }
            catch (Exception e)
            {
                IdentityError error = new IdentityError();
                error.Code = e.Message;
                error.Description = e.StackTrace.ToString();

                IdentityResult result = IdentityResult.Failed(error);


                return result;
            }
        }
    }
}
