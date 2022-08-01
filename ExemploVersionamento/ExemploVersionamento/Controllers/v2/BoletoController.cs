using Microsoft.AspNetCore.Mvc;

namespace ExemploVersionamento.Controllers.v2;

[ApiController]
[Route("api/v{version:apiVersion}/boleto")]
[Route("api/boleto")]
[ApiVersion("2")]
public class BoletoController : ControllerBase
{

    [HttpPost]
    public IActionResult Post()
    {
        return Ok(new
        {
            description = "Boleto criado com a api v2 - metodo novo"
        });
    }
}