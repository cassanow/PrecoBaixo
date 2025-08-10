using AutoMapper;
using PreçoBaixo.DTO;
using PreçoBaixo.Models;

namespace PreçoBaixo.Helper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<LoginDTO, Usuarios>().ReverseMap();
    }
}