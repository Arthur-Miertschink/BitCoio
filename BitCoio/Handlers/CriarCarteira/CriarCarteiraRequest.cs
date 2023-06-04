using BitCoio.Extensions;
using MediatR;

namespace BitCoio.Handlers.CriarCarteira
{
    public class CriarCarteiraRequest : IRequest<Extensions.IResult>
    {
        public string NomeCarteira { get; set; }


    }
}
