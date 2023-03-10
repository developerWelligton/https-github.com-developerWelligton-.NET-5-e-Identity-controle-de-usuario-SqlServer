using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuarioApi.Data.Dtos;
using UsuarioApi.Data.Requests;
using UsuarioApi.Models;

namespace UsuarioApi.Services
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<CustomIdentityUser> _userManager;
        private EmailService _emailService;
        private RoleManager<IdentityRole<int>> _roleManager;

        public CadastroService(IMapper mapper, UserManager<CustomIdentityUser> userManager, EmailService emailService, RoleManager<IdentityRole<int>> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
            _roleManager = roleManager;
        }

        [Obsolete]
        public Result CadastroUsuario(CreateUsuarioDto createDto)
        {
            //Existe usuario?
            var identityUser = _userManager
               .Users
               .FirstOrDefault(u => u.UserName == createDto.Username);
            if (identityUser == null)
            {
                var usuario = _mapper.Map<Usuario>(createDto);
                CustomIdentityUser usuarioIdentity = _mapper.Map<CustomIdentityUser>(usuario);
                var resultadoIdentity = _userManager
                    .CreateAsync(usuarioIdentity, createDto.Password);

                if (resultadoIdentity.Result.Succeeded)
                {
                    _userManager.AddToRoleAsync(usuarioIdentity, "regular");

                    var code = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
                    var encodedCode = HttpUtility.UrlEncode(code);
                    _emailService.EnviarEmail(new[] { usuarioIdentity.Email }, "Link de Ativação", usuarioIdentity.Id, encodedCode);
                    return Result.Ok().WithSuccess(code).WithSuccess(encodedCode);
                }
            } 
            return Result.Fail("Falha ao cadastrar usuário");
        }

        public Result AtivaContaUsuario(AtivaContaRequest request)
        {
            var identityUser = _userManager
                .Users
                .FirstOrDefault(u => u.Id == request.UsuarioId);
            var identityResult = _userManager.ConfirmEmailAsync(identityUser, request.CodigoDeAtivacao).Result;
            if(identityResult.Succeeded)
            {
                return Result.Ok();
            }
            return Result.Fail("Falha ao ativar conta de usuario"); 
        }
    }
}
