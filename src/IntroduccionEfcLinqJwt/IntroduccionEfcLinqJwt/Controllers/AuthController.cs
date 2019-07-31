using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using IntroduccionEfcLinqJwt.Helpers;
using IntroduccionEfcLinqJwt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace IntroduccionEfcLinqJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly EfcLinqJwtIntroContext _context;
        private readonly AuthSettings _authSettings;

        public AuthController(EfcLinqJwtIntroContext context, IOptions<AuthSettings> authSettings)
        {
            _context = context;
            _authSettings = authSettings.Value;
        }

        [HttpPost]
        public IActionResult Authenticate()
        {
            Dictionary<string, string> credentials = GetUserCredentialsFromHeader();

            bool isAValidUser = IsAValidUser(credentials["user"], credentials["password"]);

            if (isAValidUser)
            {
                // Agregamos información sobre el usuario en el token.
                credentials.Add("role", GetUserRoleDescription(credentials["user"]));
                credentials.Add("appkey", GetUserApplicationKey(credentials["user"]));

                // Encriptamos el token.
                string token = CreateEncryptedJwtToken(credentials, _authSettings.Secret, 60);

                return Ok(token);
            }
            return BadRequest("Credentials not found");
        }


        private string DecodeUserCredentials(string codedCredentials)
        {
            string credentials = Encoding.UTF8.GetString(Convert.FromBase64String(codedCredentials));

            return credentials;
        }

        private Dictionary<string, string> GetUserCredentialsFromHeader()
        {
            var header = Request.Headers["Authorization"];

            // Debo sacar el nombre de usuario y la contraseña del header. ¡IMPORTANTE! Estos datos estan codificados.
            string codedCredentials = header.ToString().Substring("Basic".Length).Trim();

            // Decodificamos las credenciales.
            string[] decodedCredentials = DecodeUserCredentials(codedCredentials).Split(":");


            Dictionary<string, string> decodedUserCredentials = new Dictionary<string, string>();
            decodedUserCredentials.Add("user", decodedCredentials[0]);
            decodedUserCredentials.Add("password", decodedCredentials[1]);
            
            return decodedUserCredentials;
        }

        private string GetUserApplicationKey(string username)
        {
            var user = _context.User.Where(u => u.Username == username).FirstOrDefault();

            return user.Applicationkey;
        }

        public string GetUserRoleDescription(string username)
        {
            var user = _context.Persona.Where(u => u.Username == username).FirstOrDefault();

            user.Userrole = _context.Userrole.Where(ut => ut.IdUserrole == user.Userroleid).FirstOrDefault();

            return user.Userrole.Roledescription;
        }

        private bool IsAValidUser(string username, string password)
        {
            bool IsAValidUser = false;

            var user = _context.User.Where(u => u.Username == username && u.Password == password).FirstOrDefault();

            if (user != null)
            {
                IsAValidUser = true;
            }

            return IsAValidUser;
        }

        private SigningCredentials SignCredential(string secret)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

            SigningCredentials signedCredential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            return signedCredential;
        }

        private SecurityToken CreateJwtToken(Dictionary<string, string> credentials, string secret, int tokenExpiresInMinutes)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(tokenExpiresInMinutes),
                SigningCredentials = SignCredential(secret),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Name", credentials["user"]),
                    new Claim("Role", credentials["role"]),
                    new Claim("AppId", credentials["appid"])
                })
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return token;
        }

        private string EncryptJwtToken(SecurityToken token)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }

        public string CreateEncryptedJwtToken(Dictionary<string, string> credentials, string secret, int tokenExpiresInMinutes)
        {
            SecurityToken token = CreateJwtToken(credentials, secret, tokenExpiresInMinutes);

            return EncryptJwtToken(token);
        }
    }
}