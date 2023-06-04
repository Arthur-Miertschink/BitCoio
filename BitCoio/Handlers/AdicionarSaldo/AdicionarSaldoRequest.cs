using MediatR;
using System.Text.Json.Serialization;

namespace BitCoio.Handlers.AdicionarSaldo
{
    public class AdicionarSaldoRequest : IRequest<Extensions.IResult>
    {
        [JsonIgnore]
        public Guid IdCarteira { get; set; }

        public decimal Valor { get; set; }
    }
}
