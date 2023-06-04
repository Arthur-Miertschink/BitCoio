using AutoMapper;
using BitCoio.Data;
using BitCoio.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BitCoio.Handlers.ConsultaSaldo
{
    public class ConsultaSaldoQueryHandler : IRequestHandler<ConsultaSaldoRequest, Extensions.IResult>
    {
        private readonly IMapper _mapper;

        public ConsultaSaldoQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<Extensions.IResult> Handle(ConsultaSaldoRequest query, CancellationToken cancellationToken)
        {
            var context = new CorretoraContext();

            var carteira = await context.Carteiras.FirstOrDefaultAsync(c => c.Id == query.IdCarteira);

            if (carteira == null)
                return "Carteira não encontrada.".Fail();

            var response = _mapper.Map<CarteiraResponse>(carteira);

            return response.Success();
        }
    }
}
