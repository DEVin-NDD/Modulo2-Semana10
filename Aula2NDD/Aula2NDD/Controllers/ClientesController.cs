using Aula2NDD.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aula2NDD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private static int _idIndice = 1;
        private static List<Cliente> _clientes = new(); 

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
        public Cliente Post(
            [FromBody] Cliente body
        )
        {
            body.Id = _idIndice;
            _idIndice += 1;

            _clientes.Add(body);

            return body;
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