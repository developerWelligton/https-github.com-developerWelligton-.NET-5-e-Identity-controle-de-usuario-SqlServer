using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuarioApi.Data.Requests;
using UsuarioApi.Models;

namespace UsuarioApi.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService )
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LogaUsuario(LoginRequest request)
        {
            var resultadoIdentity = _signInManager
                .PasswordSignInAsync(request.Username, request.Password, false, false);
            if (resultadoIdentity.Result.Succeeded) {
                var identityUser = _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(usuario=>usuario.NormalizedUserName == request.Username.ToUpper());
                Token token = _tokenService.CreateToken(identityUser);
                return Result.Ok().WithSuccess(token.value);
            }
             
            return Result.Fail("Login Falhou");
        }

        public Result SolicitaResetSenhaUsuario(SolicitaResetRequest request)
        {
            IdentityUser<int> identityUser = _signInManager.UserManager.Users.FirstOrDefault(u => u.NormalizedEmail == request.Email.ToUpper());
            
            if(identityUser != null)
            {
                var codigoDeRecuperação = _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;
                return Result.Ok().WithSuccess(codigoDeRecuperação);
            }
            return Result.Fail("Falha ao solicitar redefinição");
        }
    }
}
