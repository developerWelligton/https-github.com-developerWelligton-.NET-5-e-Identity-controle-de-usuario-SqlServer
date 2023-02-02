using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Models;
using FilmesAPI.Data.Dtos;
using filmesAPIalura.Data.Dtos.Ingresso;
using filmesAPIalura.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngressoController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public IngressoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaIngresso([FromBody] CreateIngressoDto ingressoDto)
        {
            Ingresso ingresso = _mapper.Map<Ingresso>(ingressoDto);
            _context.Ingressos.Add(ingresso);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaIngressosPorId), new { Id = ingresso.Id }, ingresso);
        }

        [HttpGet]
        public IEnumerable<Ingresso> RecuperaIngressos()
        {
            return _context.Ingressos;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaIngressosPorId(int id)
        {
            Ingresso ingresso = _context.Ingressos.FirstOrDefault(ingresso => ingresso.Id == id);
            if (ingresso != null)
            {
                ReadIngressoDto ingressoDto = _mapper.Map<ReadIngressoDto>(ingresso);

                return Ok(ingressoDto);
            }
            return NotFound();
        }
         
    }
}