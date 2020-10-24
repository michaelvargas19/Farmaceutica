using AutenticacionDTO.DTO;
using AutenticacionDTO.DTO.Login;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using serverdespacho.Entidades;
using serverdespacho.Peristencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace serverdespacho.Seguridad
{
    public class AuthNegocio : Controller
    {
        
        private readonly SignInManager<Usuario> signInManager;
        private readonly DBContext dbManager;
        private string Algorithm;
        private string SecretKey;
        private string Audience;
        private string Issuer;
        private double lifeMinutes;

        public AuthNegocio(IConfiguration configuration, 
                           SignInManager<Usuario> signInManager,
                           DBContext dbContext)
        {
            this.signInManager = signInManager;
            this.dbManager = dbContext;
            this.Algorithm = configuration["JwtConfig:algorithm"];
            this.SecretKey = configuration["JwtConfig:secretKey"];
            this.Audience = configuration["JwtConfig:audience"];
            this.Issuer = configuration["JwtConfig:issuer"];
            this.lifeMinutes = 0;
        }

        public async Task<TokenJWT> iniciarSesion(LoginRequest account)
        {
            TokenJWT token = null;
            SignInResult result = SignInResult.Failed;

            try
            {

                string user = account.Usuario;
                user = user.Contains("@") ? user.Split("@")[0] : user;

                Usuario appUser = signInManager.UserManager.FindByNameAsync(user).Result;
                List<Rol> roles = dbManager.Roles.ToList();

                if (appUser != null)
                {
                    
                    account.Usuario = account.Usuario.Contains("@") ? account.Usuario.Split("@")[0] : account.Usuario;
                    
                    
                    bool hasRole = false;

                    foreach (Rol rol in roles)
                    {
                        if (signInManager.UserManager.IsInRoleAsync(appUser, rol.Name).Result)
                        {
                            hasRole = true;
                            continue;
                        }
                    }

                    if (!hasRole)
                    {
                        throw new Exception("El usuario no tiene permisos para iniciar sesión.");
                    }



                    //Account Service

                    user = user.Contains("@") ? user.Split("@")[0] : user;

                    SignInResult validation = signInManager.PasswordSignInAsync(appUser, account.Contrasena, false, false).Result;

                    if (validation.Succeeded)
                        result = SignInResult.Success;

                }

                if (result.Succeeded)
                {

                    IList<string> rolesUsuario = signInManager.UserManager.GetRolesAsync(appUser).Result;
                    List<Claim> claimsJWT = new List<Claim>();

                    foreach (Rol rol in roles)
                    {
                        if (rolesUsuario.Contains(rol.Name))
                            claimsJWT.Add(new Claim(ClaimTypes.Role, rol.Name));
                    }
                    claimsJWT.Add(new Claim(ClaimTypes.NameIdentifier, appUser.UserName));
                    claimsJWT.Add(new Claim(ClaimTypes.Email, appUser.Email));
                    claimsJWT.Add(new Claim(ClaimTypes.GivenName, appUser.FirstName + " " + appUser.LastName));



                    string jwt = TokenGenerator.GenerateTokenJWT(this.SecretKey, this.Algorithm, claimsJWT, this.lifeMinutes, this.Issuer, this.Audience, dbManager);

                    token = new TokenJWT();
                    token.Token = jwt;

                }
                else
                {
                    if (token == null)
                    {
                        token = new TokenJWT();
                        token.Token = "La dupla Usuario/Contraseña es incorrecta.";
                    }
                    else
                    {
                        token = new TokenJWT();
                        token.Token = "Usuario incorrecto";
                    }
                }
            }
            catch (Exception e)
            {
                token = new TokenJWT();
                token.Token = e.Message;
            }
            return token;
        }

        public bool validarTokenJWT(TokenJWT token)
        {

            return TokenValidator.ValidarTokenJWT(token.Token, this.SecretKey, this.Issuer, this.Audience, TimeSpan.Zero, dbManager);

        }

        public TokenJWT renovarToken(TokenJWT token)
        {
            TokenJWT newToken = null;

            if (validarTokenJWT(token))
            {
                newToken = new TokenJWT();
                newToken.Token = TokenGenerator.renovarTokenJWT(token.Token, this.SecretKey, this.lifeMinutes, this.Issuer, this.Audience, dbManager);
                newToken.TokenValido = true;
            }
            return newToken;

        }


    }
}
