using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuarioApi.Data.Dtos;
using UsuarioApi.Data.Requests;
using UsuarioApi.Services;

namespace UsuarioApi.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class CadastroController : ControllerBase
    {
        private CadastroService _cadastroService;
        
        public CadastroController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        [Obsolete]
        public IActionResult CadastroUsuario(CreateUsuarioDto createDto)
        {
            //TODO  chamar o service 
            var resultado = _cadastroService.CadastroUsuario(createDto);
            if (resultado.IsFailed) return StatusCode(500);
            return Ok(resultado.Successes.FirstOrDefault());
        }

        [HttpGet("/ativa")]
        public IActionResult AtivaContaUsuario([FromQuery] AtivaContaRequest request)
        {
            Result resultado = _cadastroService.AtivaContaUsuario(request);
            if(resultado.IsFailed) return StatusCode(500);
            return Ok(resultado.Successes);
        }
    }
}
