using AutoMapper;
using Autoplay_API.DTO;
using Autoplay_API.Models;

namespace Autoplay_API.Profiles;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<ProdutoRequestDTO, Produto>().ReverseMap();
    }
}