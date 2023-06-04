using MediatR;
using System.Text.Json.Serialization;

namespace BitCoio.Handlers.RetirarSaldo
{
    public class RetirarSaldoRequest : IRequest<Extensions.IResult>
    {
        [JsonIgnore]
        public Guid IdCarteira { get; set; }

        public decimal Valor { get; set; }

    }
}
