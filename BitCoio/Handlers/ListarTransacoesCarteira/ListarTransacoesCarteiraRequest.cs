using MediatR;

namespace BitCoio.Handlers.ListarTransacoesCarteira
{
    public class ListarTransacoesCarteiraRequest : IRequest<Extensions.IResult>
    {
        public Guid IdCarteira { get; set; }
    }
}
