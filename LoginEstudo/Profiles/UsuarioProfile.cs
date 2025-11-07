using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LoginEstudo.Dtos;
using LoginEstudo.Entities;

namespace LoginEstudo.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<UsuarioLoginDTO, Usuario>().ForMember(
                destino => destino.DataCriacao,
                opt => opt.MapFrom(src => DateTime.Now)
            ).ForMember(
                destino => destino.UltimoLogin,
                opt => opt.MapFrom(src => DateTime.Now)
            );
    }
}