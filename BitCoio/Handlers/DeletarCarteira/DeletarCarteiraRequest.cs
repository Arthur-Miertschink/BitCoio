using BitCoio.Extensions;
using MediatR;

namespace BitCoio.Handlers.DeletarCarteira
{
    public class DeletarCarteiraRequest : IRequest<Extensions.IResult>
    {
        public Guid IdCarteira { get; set; }
    }
}
