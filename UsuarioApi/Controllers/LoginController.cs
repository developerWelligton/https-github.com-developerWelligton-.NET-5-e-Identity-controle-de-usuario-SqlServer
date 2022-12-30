
using FluentResults;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuarioApi.Data.Requests;
using UsuarioApi.Services;

namespace UsuarioApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("MyAllowSpecificOrigins")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }



        [EnableCors]
        [HttpPost]
        public IActionResult LogaUsuario (LoginRequest request)
        {
            var resultado = _loginService.LogaUsuario(request);
            if (resultado.IsFailed) return Unauthorized(resultado.Errors.FirstOrDefault());
            return Ok(resultado.Successes.FirstOrDefault());
        }
        [EnableCors]
        [HttpPost("/solicita-reset")]
        [Obsolete]
        public IActionResult SolicitaResetSenhaUsuario(SolicitaResetRequest request)
        {
            Result resultado = _loginService.SolicitaResetSenhaUsuario(request);
            if (resultado.IsFailed) return Unauthorized(resultado.Errors);
            return Ok(resultado.Successes.FirstOrDefault());
        }
        [EnableCors]
        [HttpPost("/efetua-reset")]
        public IActionResult  ResetaSenhaUsuario(EfetuaResetRequest request)
        {
            Result resultado = _loginService.ResetSenhaUsuario(request);
            if (resultado.IsFailed) return Unauthorized(resultado.Errors);
            return Ok(resultado.Successes.FirstOrDefault());
        }

    }
}
