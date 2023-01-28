using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using filmesAPIalura.Data.Dtos.Sessao;
using filmesAPIalura.Models;

namespace filmesAPIalura.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>();
            CreateMap<UpdateSessaoDto, Sessao>();
        }
     
    }
}
