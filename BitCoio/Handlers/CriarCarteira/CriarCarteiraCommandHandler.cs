using AutoMapper;
using BitCoio.Data;
using BitCoio.Entities;
using BitCoio.Extensions;
using MediatR;

namespace BitCoio.Handlers.CriarCarteira
{
    public class CriarCarteiraCommandHandler : IRequestHandler<CriarCarteiraRequest, Extensions.IResult>
    {
        private readonly IMapper _mapper;

        public CriarCarteiraCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<Extensions.IResult> Handle(CriarCarteiraRequest request, CancellationToken cancellationToken)
        {
            var context = new CorretoraContext();

            var carteira = new Carteira(request.NomeCarteira);

            await context.AddAsync(carteira);

            await context.SaveChangesAsync();

            var response = _mapper.Map<CarteiraResponse>(carteira);

            return response.Success();
        }
    }
}
