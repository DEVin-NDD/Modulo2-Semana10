using Aula2NDD.Infra;
using Aula2NDD.Models;
using Aula2NDD.Services;
using Aula2NDD.DTOs;
using Microsoft.AspNetCore.Mvc;
using Aula2NDD.ViewModels;
using Aula2NDD.Repositories;

namespace Aula2NDD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly LogAcao _logAcao;
        private readonly ServicoSMS _servicoSMS;
        private readonly TipoClienteRepository _tipoClienteRepository;
        private readonly ClienteRepository _clienteRepository;

        public ClientesController(
            LogAcao logAcao,
            ServicoSMS servicoSMS,
            TipoClienteRepository tipoClienteRepository,
            ClienteRepository clienteRepository
        )
        {
            _logAcao = logAcao;
            _servicoSMS = servicoSMS;
            _tipoClienteRepository = tipoClienteRepository;
            _clienteRepository = clienteRepository;
        }

        //GET http://localhost:5180/Clientes?idade=20
        [HttpGet]
        public List<Cliente> Get(
            [FromQuery] int? idade   
        )
        {
            if (idade.HasValue)
            {
                return _clienteRepository
                   .ObterPorIdade(idade.Value);
            }

            return _clienteRepository.ObterTodos();
        }

        //GET http://localhost:5180/Clientes/com-contas
        [HttpGet("com-contas")]
        public List<ClienteComContasViewModel> GetClienteContas()
        {
            return _clienteRepository.ObterClientesComContas();
        }

        //GET http://localhost:5180/Clientes/1
        [HttpGet("{idCliente}")]
        public Cliente GetById([FromRoute] int idCliente)
        {
            return _clienteRepository.ObterPorId(idCliente);
        }

        //POST http://localhost:5180/Clientes/
        [HttpPost]
        public ActionResult<Cliente> Post(
            [FromBody] ClienteDTO body
        )
        {
            if (_clienteRepository.ExisteClienteComNome(body.Nome))
            {
                return BadRequest(new ErroProcessamento("Cliente já cadastrado."));
            }

            var tipoCliente = _tipoClienteRepository.ObterPorId(body.TipoClienteId);

            var cliente = new Cliente(
                body.Nome,
                body.Idade,
                tipoCliente
            );

            _clienteRepository.Adicionar(cliente);

            _logAcao.GravarLog($"Cliente {cliente.Nome} foi criado!");

            // mandar mensagem de boas vindas
            _servicoSMS.Enviar("bem vindo!");

            return Ok(cliente);
        }

        //PUT http://localhost:5180/Clientes/1
        [HttpPut("{idCliente}")]
        public Cliente Put(
            [FromBody] ClienteDTO body,
            [FromRoute] int idCliente
        )
        {
            var cliente = _clienteRepository.ObterPorId(idCliente);

            var tipoCliente = _tipoClienteRepository.ObterPorId(body.TipoClienteId);

            cliente.Nome = body.Nome;
            cliente.Idade = body.Idade;
            cliente.Tipo = tipoCliente;

            _clienteRepository.Atualizar(cliente);

            _logAcao.GravarLog($"Cliente {body.Nome} foi atualizado!");

            return cliente;
        }

        //DELETE http://localhost:5180/Clientes/1
        [HttpDelete("{idCliente}")]
        public void Delete(
            [FromRoute] int idCliente
        )
        {
            _clienteRepository.Remover(idCliente);
        }


        [HttpPost("{idCliente}/contas")]
        public ActionResult<Cliente> PostConta(
            [FromBody] Conta conta,
            [FromRoute] int idCliente
        )
        {
            var cliente = _clienteRepository.ObterPorId(idCliente);

            _clienteRepository.AdicionarConta(cliente, conta);

            return cliente;
        }
    }
}