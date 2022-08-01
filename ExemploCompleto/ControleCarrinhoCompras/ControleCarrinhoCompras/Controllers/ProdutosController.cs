using ControleCarrinhoCompras.Models;
using ControleCarrinhoCompras.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace ControleCarrinhoCompras.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoRepositorio _repositorio;

        public ProdutosController(ProdutoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet()]
        public ActionResult<List<Produto>> ObterProdutos(
            [FromQuery] string nomeFiltro
        )
        {
            var produtos = _repositorio.ObterProdutos();

            if (!string.IsNullOrEmpty(nomeFiltro))
            {
                produtos = produtos
                    .Where(p => p.Nome.ToUpper().Contains(nomeFiltro.ToUpper()))
                    .ToList();
            }

            return produtos;
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> ObterProdutoPorId(
            [FromRoute] Guid id
        )
        {
            return _repositorio.ObterProdutoPorId(id);
        }

        [HttpPost()]
        public ActionResult<Produto> AdicionarProduto(
            [FromBody] Produto produto
        )
        {
            var successo = _repositorio.AdicionarProduto(produto);

            if (!successo) return BadRequest();

            return Created(nameof(AdicionarProduto), produto);
        }

        [HttpPut("{id}")]
        public ActionResult<Produto> EditarProduto(
            [FromRoute] Guid id,
            [FromBody] Produto produto
        )
        {
            produto.AtribuirId(id);

            var successo = _repositorio.AtualizarProduto(produto);

            if (!successo) return BadRequest();

            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public ActionResult<Produto> RemoverProduto(
            [FromRoute] Guid id
        )
        {
            var produto = _repositorio.ObterProdutoPorId(id);

            if (produto == null) return NotFound();

            var successo = _repositorio.RemoverProduto(produto);

            if (!successo) return BadRequest();

            return NoContent();
        }
    }
}