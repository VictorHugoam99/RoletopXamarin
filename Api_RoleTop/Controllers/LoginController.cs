using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Api_RoleTop.Domains;
using Api_RoleTop.Interfaces;
using Api_RoleTop.Repositories;
using Api_RoleTop.ViewModels;

namespace Api_RoleTop.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Loga o usuario por email ou apelido
        /// </summary>
        /// <param name="user"></param>
        /// <returns>token</returns>
        [HttpPost]
        public IActionResult Login(UsuarioViewModel user)
        {
            Usuario userSelect = _usuarioRepository.Login(user.Email_Apelido, user.Senha);

            if (userSelect == null)
            {
                return NotFound("E-mail ou senha inválidos");
            }

            //payload

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, userSelect.Email),
                new Claim(JwtRegisteredClaimNames.Jti, userSelect.Id.ToString()),
                new Claim(ClaimTypes.Role, "Usuario") // MUDAR ESSA LINHA QUANDO FOR ADD ADM
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("roletop-key-auth"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "RoleTop.WebApi",                // emissor do token
                audience: "RoleTop.WebApi",              // destinatário do token
                claims: claims,                          // dados definidos acima
                expires: DateTime.Now.AddMinutes(30),    // tempo de expiração
                signingCredentials: creds                // credenciais do token
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
