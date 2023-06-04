using AutoMapper;
using BitCoio.Data;
using BitCoio.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BitCoio.Handlers.DeletarCarteira
{
    public class DeletarCarteiraCommandHandler : IRequestHandler<DeletarCarteiraRequest, Extensions.IResult>
    {
        private readonly IMapper _mapper;

        public DeletarCarteiraCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<Extensions.IResult> Handle(DeletarCarteiraRequest request, CancellationToken cancellationToken)
        {
            var context = new CorretoraContext();

            var carteira = await context.Carteiras.FirstOrDefaultAsync(d => d.Id == request.IdCarteira);

            if (carteira == null)
                return "Carteira não encontrada".Fail();

            context.Remove(carteira);

            await context.SaveChangesAsync();

            var response = _mapper.Map<CarteiraResponse>(carteira);

            return response.Success();
        }
    }
}
