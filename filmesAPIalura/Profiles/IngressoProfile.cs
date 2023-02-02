using filmesAPIalura.Data.Dtos.Ingresso;
using filmesAPIalura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using AutoMapper;

namespace filmesAPIalura.Profiles
{
    public class IngressoProfile : Profile
    {
        public IngressoProfile()
        {
            CreateMap<CreateIngressoDto, Ingresso>();
            CreateMap<Ingresso, CreateIngressoDto>();
        }
    }
}
