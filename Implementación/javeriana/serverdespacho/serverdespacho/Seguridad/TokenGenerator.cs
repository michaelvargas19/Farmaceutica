using Microsoft.IdentityModel.Tokens;
using serverdespacho.Entidades.Util;
using serverdespacho.Peristencia;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace serverdespacho.Seguridad
{
    public class TokenGenerator
    {
        public static string GenerateTokenJWT(string secretKey, string securityAlgorithm, IEnumerable<Claim> claims, double LifeMinutes, string issuer, string audience, DBContext dbManager)
        {
            // CREAMOS EL HEADER //
            try
            {

                var symmetricSecurityKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(secretKey)
                    );

                var signingCredentials = new SigningCredentials(
                        symmetricSecurityKey, securityAlgorithm
                    );

                var header = new JwtHeader(signingCredentials);


                // CREAMOS EL PAYLOAD //
                var payload = new JwtPayload(
                        issuer: issuer,
                        audience: audience,
                        claims: claims,
                        notBefore: DateTime.UtcNow,
                        expires: DateTime.UtcNow.AddMinutes(LifeMinutes)
                    );

                // GENERAMOS EL TOKEN //
                var token = new JwtSecurityToken(
                        header,
                        payload
                    );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception e)
            {
                dbManager.Log(Util.crearLog("Error", "Despachos", nameof(GenerateTokenJWT), true, "TokenGenerator.cs", e.Message, e.StackTrace.ToString()));
                return null;
            }
        }

        public static string renovarTokenJWT(string token, string secretKey, double LifeMinutes, string issuer, string audience, DBContext dbManager)
        {
            //var SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                JwtSecurityToken st = tokenHandler.ReadJwtToken(token);

                // CREAMOS EL HEADER //
                var symmetricSecurityKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(secretKey)
                    );
                var signingCredentials = new SigningCredentials(
                        symmetricSecurityKey, st.Header.Alg
                    );
                var header = new JwtHeader(signingCredentials);

                List<Claim> claims = new List<Claim>();

                foreach (KeyValuePair<string, Object> c in st.Payload.Where(c => c.Key == ClaimTypes.Role || c.Key == ClaimTypes.NameIdentifier ||
                                                                                c.Key == ClaimTypes.Email || c.Key == ClaimTypes.GivenName))
                {
                    claims.Add(new Claim(c.Key, c.Value.ToString()));
                }


                // CREAMOS EL PAYLOAD //
                var payload = new JwtPayload(
                        issuer: issuer,
                        audience: audience,
                        claims: claims,
                        notBefore: DateTime.UtcNow,
                        expires: DateTime.UtcNow.AddMinutes(LifeMinutes)
                    );

                // GENERAMOS EL TOKEN //
                var newToken = new JwtSecurityToken(
                        header,
                        payload
                    );

                return new JwtSecurityTokenHandler().WriteToken(newToken);

            }
            catch (Exception e)
            {
                dbManager.Log(Util.crearLog("Error", "Despachos", nameof(renovarTokenJWT), true, "TokenGenerator.cs", e.Message, e.StackTrace.ToString()));
                return null;
            }
        }
    }
}
