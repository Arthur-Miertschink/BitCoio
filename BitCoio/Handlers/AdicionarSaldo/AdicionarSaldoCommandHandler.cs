using AutoMapper;
using BitCoio.Data;
using BitCoio.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BitCoio.Handlers.AdicionarSaldo
{
    public class AdicionarSaldoCommandHandler : IRequestHandler<AdicionarSaldoRequest, Extensions.IResult>
    {
        private readonly IMapper _mapper;

        public AdicionarSaldoCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<Extensions.IResult> Handle(AdicionarSaldoRequest request, CancellationToken cancellationToken)
        {
            var context = new CorretoraContext();

            var carteira = await context.Carteiras.FirstOrDefaultAsync(c => c.Id == request.IdCarteira);

            if (carteira == null)
                return "Carteira não encontrada.".Fail();

            carteira.Valor += request.Valor;

            context.Update(carteira);

            await context.SaveChangesAsync();

            var response = _mapper.Map<CarteiraResponse>(carteira);

            return response.Success();
        }
    }
}
