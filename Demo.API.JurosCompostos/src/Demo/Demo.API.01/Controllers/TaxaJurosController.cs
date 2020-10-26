using Demo.API._01.Contracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Demo.API._01.Controllers
{
    [EnableCors("AllowAnyOrigin")]
    [Route("taxaJuros")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        private readonly ITaxas _taxas;
        private readonly ILogger<TaxaJurosController> _logger;

        public TaxaJurosController(ITaxas taxas, ILogger<TaxaJurosController> logger)
        {
            _taxas = taxas;
            _logger = logger;
        }

        // GET taxaJuros
        [HttpGet]
        public async Task<ActionResult<decimal>> GetTaxaJuros()
        {
            try
            {
                var taxaJuros = await _taxas.RetornaTaxaDeJuros();

                _logger.LogInformation("Taxa de juros retornada com sucesso.");

                return Ok(taxaJuros);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message, ex);

                return BadRequest(ex.Message);
            }
        }
    }
}
