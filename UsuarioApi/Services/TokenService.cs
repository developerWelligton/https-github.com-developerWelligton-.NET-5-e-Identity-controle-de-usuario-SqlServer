using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuarioApi.Models;

namespace UsuarioApi.Services
{
    public class TokenService
    {
        public Token CreateToken(CustomIdentityUser usuario, string role)
        {
            Claim[] direitosUsuario = new Claim[]
            {
                new Claim("username",usuario.UserName),
                new Claim("id",usuario.Id.ToString()),
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.DateOfBirth, usuario.DataNascimento.ToString())
            };
            Claim[] direitosUsuarioDTO = new Claim[]
           {
                new Claim("username",direitosUsuario[0].Value),
                new Claim("id",direitosUsuario[1].Value),
                new Claim("role", direitosUsuario[2].Value),
                new Claim("DataNascimento", direitosUsuario[3].Value)
           };

            //gerar chave
            var chave = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("0asdsadasdsad06asdasdasdasd09asdasdsad0sa9")
                );
            var credencias = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);
            
            var token = new JwtSecurityToken(
                claims: direitosUsuarioDTO,
                signingCredentials: credencias,
                expires: DateTime.UtcNow.AddHours(1)
                );
            var tokenstring = new JwtSecurityTokenHandler().WriteToken(token);
            return new Token(tokenstring);
        }
    }
}
