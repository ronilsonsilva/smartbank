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
            CreateMap<ClienteValidacaoCadastral, ClienteValidacaoCadastralViewModel>().ReverseMap();
            CreateMap<ClienteSolicitacao, ClienteSolicitacaoViewModel>().ReverseMap();
            CreateMap<ClienteSolicitacaoPendecia, ClienteSolicitacaoPendeciaViewModel>().ReverseMap();
            CreateMap<ClienteBiometriaDigital, ClienteBiometriaDigitalViewModel>().ReverseMap();
            CreateMap<ClienteBiometriaFacial, ClienteBiometriaFacialViewModel>().ReverseMap();
            CreateMap<ClienteScore, ClienteScoreViewModel>().ReverseMap();

            //Value objects
            //CreateMap<EnderecoValueObject, EnderecoViewModel>().ReverseMap();
            //CreateMap<ContatoValueObject, ContatoViewModel>().ReverseMap();
        }
    }
}
