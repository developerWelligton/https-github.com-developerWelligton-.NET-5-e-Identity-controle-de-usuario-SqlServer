using AutoMapper;
using FilmesAPI.Data.Dtos;
using filmesAPIalura.Models;


namespace filmesAPIalura.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
            CreateMap<UpdateFilmeDto, Filme>();
        }
            
    }
}
