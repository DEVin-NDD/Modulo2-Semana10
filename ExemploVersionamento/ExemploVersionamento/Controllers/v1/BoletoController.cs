using Microsoft.AspNetCore.Mvc;

namespace ExemploVersionamento.Controllers.v1;

[ApiController]
[Route("api/v{version:apiVersion}/boleto")]
[Route("api/boleto")]
[ApiVersion("1", Deprecated = true)]
public class BoletoController : ControllerBase
{

    [HttpPost]
    public IActionResult Post()
    {
        return Ok(new
        {
            description = "Boleto criado com a api v1 - depreciado"
        });
    }
}