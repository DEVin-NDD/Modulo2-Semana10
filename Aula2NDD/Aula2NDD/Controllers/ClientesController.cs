using Aula2NDD.Infra;
using Aula2NDD.Models;
using Aula2NDD.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aula2NDD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private static int _idIndice = 1;
        private static List<Cliente> _clientes = new();

        private readonly LogAcao _logAcao;
        private readonly ServicoSMS _servicoSMS;

        public ClientesController(
            LogAcao logAcao,
            ServicoSMS servicoSMS
        )
        {
            _logAcao = logAcao;
            _servicoSMS = servicoSMS;
        }

        //GET http://localhost:5180/Clientes?idade=20
        [HttpGet]
        public List<Cliente> Get(
            [FromQuery] int? idade   
        )
        {
            if (idade.HasValue)
            {
                return _clientes
                    .Where(c => c.Idade == idade)
                    .ToList();
            }

            return _clientes;
        }

        //GET http://localhost:5180/Clientes/1
        [HttpGet("{idCliente}")]
        public Cliente GetById([FromRoute] int idCliente)
        {
            return _clientes.FirstOrDefault(c => c.Id == idCliente);
        }

        //POST http://localhost:5180/Clientes
        [HttpPost]
        public ActionResult<Cliente> Post(
            [FromBody] Cliente body
        )
        {
            if (_clientes.Any(c => c.Nome == body.Nome))
            {
                return BadRequest(new ErroProcessamento("Cliente já cadastrado."));
            }

            body.Id = _idIndice;
            _idIndice += 1;

            _clientes.Add(body);

            _logAcao.GravarLog($"Cliente {body.Nome} foi criado!");

            // mandar mensagem de boas vindas
            _servicoSMS.Enviar("bem vindo!");

            return Ok(body);
        }

        //PUT http://localhost:5180/Clientes/1
        [HttpPut("{idCliente}")]
        public Cliente Put(
            [FromBody] Cliente body,
            [FromRoute] int idCliente
        )
        {
            var cliente = _clientes.FirstOrDefault(c => c.Id == idCliente);

            cliente.Nome = body.Nome;
            cliente.Idade = body.Idade;

            _logAcao.GravarLog($"Cliente {body.Nome} foi atualizado!");

            return cliente;
        }

        //DELETE http://localhost:5180/Clientes/1
        [HttpDelete("{idCliente}")]
        public void Delete(
            [FromRoute] int idCliente
        )
        {
            var cliente = _clientes.FirstOrDefault(c => c.Id == idCliente);

            _clientes.Remove(cliente);
        }
    }
}