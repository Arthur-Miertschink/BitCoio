using AutoMapper;
using BitCoio.Data;
using BitCoio.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BitCoio.Handlers.RetirarSaldo
{
    public class RetirarSaldoCommandHandler : IRequestHandler<RetirarSaldoRequest, Extensions.IResult>
    {
        private readonly IMapper _mapper;

        public RetirarSaldoCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<Extensions.IResult> Handle(RetirarSaldoRequest request, CancellationToken cancellationToken)
        {
            var context = new CorretoraContext();

            var carteira = await context.Carteiras.FirstOrDefaultAsync(c => c.Id == request.IdCarteira);

            if (carteira == null)
                return "Carteira não encontrada".Fail();

            carteira.Valor -= request.Valor;

            if (carteira.Valor < 0)
                return "Saldo insuficiente para saque.".Fail();

            context.Update(carteira);
            
            await context.SaveChangesAsync();

            var response = _mapper.Map<CarteiraResponse>(carteira);

            return response.Success();
        }
    }
}
