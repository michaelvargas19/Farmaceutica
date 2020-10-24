using Microsoft.IdentityModel.Tokens;
using serverdespacho.Entidades.Util;
using serverdespacho.Peristencia;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serverdespacho.Seguridad
{
	public class TokenValidator
	{
		public static bool ValidarTokenJWT(string token, string secretKey, string issuer, string audience, TimeSpan clockSkew, DBContext dbManager)
		{
			var SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

			var tokenHandler = new JwtSecurityTokenHandler();
			try
			{
				tokenHandler.ValidateToken(token, new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidIssuer = issuer,
					ValidAudience = audience,
					IssuerSigningKey = SecurityKey,
					ClockSkew = clockSkew
				}, out SecurityToken validatedToken);
			}
			catch (Exception ex)
			{
				return false;
			}
			return true;
		}

		public static string extraerFirmaJWT(string token, DBContext dbManager)
		{

			try
			{
				string[] parts = token.Split('.');
				string signature = parts[2];

				return signature;
			}
			catch (Exception e)
			{
				dbManager.Log(Util.crearLog("Error", "Manager", nameof(extraerFirmaJWT), true, "TokenValidator.cs", e.Message, e.StackTrace.ToString()));
				return null;
			}
		}


		public static bool validarFirmaJWT(string token, string codeSignature, DBContext dbManager)
		{

			try
			{
				string tokenSignature = extraerFirmaJWT(token, dbManager);

				if (tokenSignature.CompareTo(codeSignature) == 0)
				{
					return true;
				}

				return false;

			}
			catch (Exception e)
			{
				dbManager.Log(Util.crearLog("Error", "Manager", nameof(validarFirmaJWT), true, "TokenValidator.cs", e.Message, e.StackTrace.ToString()));
				return false;
			}
		}


	}
}
