using AutoMapper;
using SmartBank.Application.ViewModels;
using SmartBank.Domain.Entities;

namespace SmartBank.Application.AutoMapper
{
    public class Configuration : Profile
    {
        public Configuration()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();

            //Value objects
            //CreateMap<EnderecoValueObject, EnderecoViewModel>().ReverseMap();
            //CreateMap<ContatoValueObject, ContatoViewModel>().ReverseMap();
        }
    }
}
