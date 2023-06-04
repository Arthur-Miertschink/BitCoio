using AutoMapper;
using BitCoio.Entities;
using BitCoio.Handlers.ListarTransacoesCarteira;

namespace BitCoio.Handlers
{
    public class CorretoraProfile : Profile
    {
        public CorretoraProfile()
        {
            CreateMap<Carteira, CarteiraResponse>().ReverseMap();

            CreateMap<Transacao, ListarTransacoesCarteiraResponse>().ReverseMap();



        }

    }
}
