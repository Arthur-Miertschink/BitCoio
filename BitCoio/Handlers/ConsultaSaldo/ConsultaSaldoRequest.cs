using BitCoio.Extensions;
using MediatR;

namespace BitCoio.Handlers.ConsultaSaldo
{
    public class ConsultaSaldoRequest : IRequest<Extensions.IResult>
    {
        public Guid IdCarteira { get; set; }
    }
}
