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
                new Claim("role", role),
                new Claim("dataNascimento", usuario.DataNascimento.ToString())
            };

            //gerar chave
            var chave = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("0asdsadasdsad06asdasdasdasd09asdasdsad0sa9")
                );
            var credencias = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: direitosUsuario,
                signingCredentials: credencias,
                expires: DateTime.UtcNow.AddHours(1)
                );
            var tokenstring = new JwtSecurityTokenHandler().WriteToken(token);
            return new Token(tokenstring);
        }
    }
}
