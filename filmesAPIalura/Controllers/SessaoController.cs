using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using AutoMapper;
using Castle.Core.Resource;
using FilmesApi.Data;
using FilmesAPI.Data.Dtos;
using filmesAPIalura.Data.Dtos.Sessao;
using filmesAPIalura.Models;
using filmesAPIalura.Services;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace filmesAPIalura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper; 

        public SessaoController(AppDbContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper; 
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AdicionaSessao(CreateSessaoDto dto)
        {
            Sessao sessao = _mapper.Map<Sessao>(dto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaSessoesPorId), new { Id = sessao.id }, sessao);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessoesPorId(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.id == id);
            if (sessao != null)
            {
                ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
                 

                return Ok(sessaoDto);
            }
            return NotFound();
        }

        [HttpGet]
        public IEnumerable<Sessao> RecuperaSessoes()
        {

            return _context.Sessoes;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeletaSessao(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.id == id);
            if (sessao == null)
            {
                return NotFound();
            }
            _context.Remove(sessao);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult AtualizaSessao(int id, [FromBody] UpdateSessaoDto sessaoDto)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.id == id);
            if (sessao == null)
            {
                return NotFound();
            }
            _mapper.Map(sessaoDto, sessao);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
