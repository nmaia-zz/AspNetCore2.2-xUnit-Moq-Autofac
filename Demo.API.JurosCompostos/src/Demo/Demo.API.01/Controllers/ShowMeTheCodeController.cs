using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Demo.API._01.Controllers
{
    [EnableCors("AllowAnyOrigin")]
    [Route("showmethecode")]
    [ApiController]
    public class ShowMeTheCodeController : ControllerBase
    {
        private readonly ILogger<ShowMeTheCodeController> _logger;

        public ShowMeTheCodeController(ILogger<ShowMeTheCodeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public void GetGitHubUrl()
        {
            try
            {
                Response.Redirect("https://github.com/nmaia/AspNetCore2.2-xUnit-Moq-Autofac");

                _logger.LogInformation("Redirecionamento realizado com sucesso.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }
    }
}
