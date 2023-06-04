using MediatR;

namespace BitCoio.Handlers.TransferenciaEntreCarteiras
{
    public class TransferenciaEntreCarteirasRequest : IRequest<Extensions.IResult>
    {
        public Guid IdCarteiraEnvio { get; set; }

        public Guid IdCarteiraRecebimento { get; set;}

        public decimal Valor { get; set; }

        public string Descricao { get; set;  }

    }
}
