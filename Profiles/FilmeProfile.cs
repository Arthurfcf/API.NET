using AutoMapper;
using FilmesAPIs.Dtos;
using FilmesAPIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPIs.Profiles
{
    public class FilmeProfile : Profile
    {
      public FilmeProfile()
        {
            CreateMap<FilmeDto, Filme>();
            CreateMap<Filme, ListaFilmesDto>();
            CreateMap<UpdateFilmeDto, Filme>();
        }
    }
}
