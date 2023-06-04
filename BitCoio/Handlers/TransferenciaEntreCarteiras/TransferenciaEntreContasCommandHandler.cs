using AutoMapper;
using BitCoio.Data;
using BitCoio.Entities;
using BitCoio.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BitCoio.Handlers.TransferenciaEntreCarteiras
{
    public class TransferenciaEntreContasCommandHandler : IRequestHandler<TransferenciaEntreCarteirasRequest, Extensions.IResult>
    {
        private readonly IMapper _mapper ;

        public TransferenciaEntreContasCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<Extensions.IResult> Handle(TransferenciaEntreCarteirasRequest request, CancellationToken cancellationToken)
        {
            var context = new CorretoraContext();

            var carteiraRetirada = await context.Carteiras.FirstOrDefaultAsync(c => c.Id == request.IdCarteiraEnvio);

            if (carteiraRetirada == null)
                return "Carteira para retirada não encontrada.".Fail();

            var carteiraAdicionar = await context.Carteiras.FirstOrDefaultAsync(c => c.Id == request.IdCarteiraRecebimento);

            if (carteiraAdicionar == null)
                return "Carteira para adicionar não encontrada".Fail();

            carteiraRetirada.Valor -= request.Valor;

            if (carteiraRetirada.Valor < 0)
                return "Saldo Insuficiente para transferencia.".Fail();

            carteiraAdicionar.Valor += request.Valor;

            var transacao = new Transacao(carteiraRetirada.Id, carteiraAdicionar.Id, request.Valor, request.Descricao);

            await context.Transacoes.AddAsync(transacao);

            context.Carteiras.UpdateRange(carteiraRetirada, carteiraAdicionar);

            await context.SaveChangesAsync();

            return true.Success("Transferencia realizada com Sucesso.");
        }
    }
}
