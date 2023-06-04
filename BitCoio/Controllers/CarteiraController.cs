using BitCoio.Extensions;
using BitCoio.Handlers.AdicionarSaldo;
using BitCoio.Handlers.ConsultaSaldo;
using BitCoio.Handlers.CriarCarteira;
using BitCoio.Handlers.DeletarCarteira;
using BitCoio.Handlers.ListarTransacoesCarteira;
using BitCoio.Handlers.RetirarSaldo;
using BitCoio.Handlers.TransferenciaEntreCarteiras;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BitCoio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarteiraController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CarteiraController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("{id}", Name = "GetSaldoCarteira")]
        public async Task<IActionResult> GetSaldoCarteira([FromRoute] Guid id)
        {
            var request = new ConsultaSaldoRequest()
            {
                IdCarteira = id
            };

            var response = await _mediator.Send(request);

            return response.ApiResult();
        }

        [HttpGet("transacoes/{id}", Name = "GetTransacoesCarteira")]
        public async Task<IActionResult> GetTransacoesCarteira([FromRoute] Guid id)
        {
            var request = new ListarTransacoesCarteiraRequest()
            {
                IdCarteira = id
            };

            var response = await _mediator.Send(request);

            return response.ApiResult();
        }


        [HttpPost(Name = "CriarCarteira")]
        public async Task<IActionResult> CriarCarteira([FromBody] CriarCarteiraRequest request)
        {
            var response = await _mediator.Send(request);

            return response.ApiResult();
        }

        [HttpPost("transferencia",Name = "Transferencia")]
        public async Task<IActionResult> Transferencia([FromBody] TransferenciaEntreCarteirasRequest request)
        {
            var response = await _mediator.Send(request);

            return response.ApiResult();
        }

        [HttpPatch("adicionar/{id}",Name = "AdicionarSaldo")]
        public async Task<IActionResult> AdicionarSaldo([FromRoute] Guid id,[FromBody] AdicionarSaldoRequest request)
        {
            request.IdCarteira = id;

            var response = await _mediator.Send(request);

            return response.ApiResult();
        }

        [HttpPatch("retirar/{id}", Name = "RetirarSaldo")]
        public async Task<IActionResult> RetirarSaldo([FromRoute] Guid id, [FromBody] RetirarSaldoRequest request)
        {
            request.IdCarteira = id;

            var response = await _mediator.Send(request);

            return response.ApiResult();
        }

        [HttpDelete("{id}", Name = "DeletarCarteira")]
        public async Task<IActionResult> DeletarCarteira([FromRoute] Guid id)
        {
            var request = new DeletarCarteiraRequest
            {
                IdCarteira = id
            };

            await _mediator.Send(request);

            return NoContent();
        }


    }
}