using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SENAI.SP.MEDICAL.Domains;
using SENAI.SP.MEDICAL.Interfaces;
using SENAI.SP.MEDICAL.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SENAI.SP.MEDICAL.Controllers
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



        [HttpPost]
        public IActionResult Login(Usuario Login)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.Login(Login.Email, Login.Senha);
                if (usuarioBuscado != null)
                {
                    var Claims = new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString())
                };

                    var Key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("spmedicalgroup-chave-autenticacao"));

                    var Creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

                    var meuToken = new JwtSecurityToken(
                            issuer: "SPMEDICALGROUP.webApi",
                            audience: "SPMEDICALGROUP.webApi",
                            claims: Claims,
                            expires: DateTime.Now.AddMinutes(60),
                            signingCredentials: Creds
                        );

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                    });
                }

                return NotFound("Email ou Senha errado");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
