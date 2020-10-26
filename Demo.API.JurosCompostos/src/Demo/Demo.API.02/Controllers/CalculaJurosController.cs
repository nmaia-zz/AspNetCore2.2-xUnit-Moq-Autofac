using Demo.API._02.Contracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Demo.API._02.Controllers
{
    [EnableCors("AllowAnyOrigin")]
    [Route("calculaJuros")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ICalculoDeJuros _calculoDeJuros;
        private readonly IApi01Request _api01Resquest;
        private readonly ILogger<CalculaJurosController> _logger;

        public CalculaJurosController(ICalculoDeJuros calculoDeJuros, IApi01Request api01Resquest, ILogger<CalculaJurosController> logger)
        {
            _calculoDeJuros = calculoDeJuros;
            _api01Resquest = api01Resquest;
            _logger = logger;
        }

        // GET calculaJuros?valorinicial=&meses=
        [HttpGet]
        public async Task<ActionResult<decimal>> GetValorJurosCompostosCalculado([FromQuery] decimal valorinicial, int meses)
        {
            try
            {
                var taxadejuros = _api01Resquest.GetTaxaDeJuros();

                var jurosCompostosCalculado = await Task.Run(() =>
                {

                    return _calculoDeJuros.CalculaJurosCompostos(valorinicial, meses, taxadejuros);

                });

                _logger.LogInformation($"Valor de juros compostos calculado com sucesso para o valor {valorinicial}.");
                _logger.LogInformation($"O resultado do juro composto para o valor {valorinicial} é: {jurosCompostosCalculado}.");

                return Ok(jurosCompostosCalculado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);

                return BadRequest(ex.Message);
            }
        }
    }
}
