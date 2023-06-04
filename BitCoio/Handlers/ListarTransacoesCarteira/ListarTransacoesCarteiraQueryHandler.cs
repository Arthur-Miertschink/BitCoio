using AutoMapper;
using BitCoio.Data;
using BitCoio.Extensions;
using MediatR;

namespace BitCoio.Handlers.ListarTransacoesCarteira
{
    public class ListarTransacoesCarteiraQueryHandler : IRequestHandler<ListarTransacoesCarteiraRequest, Extensions.IResult>
    {
        private readonly IMapper _mapper;

        public ListarTransacoesCarteiraQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<Extensions.IResult> Handle(ListarTransacoesCarteiraRequest request, CancellationToken cancellationToken)
        {
            var context = new CorretoraContext();

            var transacoes = context.Transacoes.AsQueryable().Where(x => x.CarteiraEnvioId == request.IdCarteira || x.CarteiraRecebimentoId == request.IdCarteira);

            var response = _mapper.Map<IList<ListarTransacoesCarteiraResponse>>(transacoes);

            return response.Success();
        }
    }
}
