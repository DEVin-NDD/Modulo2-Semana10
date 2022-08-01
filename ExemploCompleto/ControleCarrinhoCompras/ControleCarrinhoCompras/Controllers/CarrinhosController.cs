using ControleCarrinhoCompras.Models;
using ControleCarrinhoCompras.Models.DTOs;
using ControleCarrinhoCompras.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace ControleCarrinhoCompras.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarrinhosController : ControllerBase
    {
        private readonly CarrinhoRepositorio _repositorio;

        public CarrinhosController(CarrinhoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet()]
        public ActionResult<List<Carrinho>> ObterCarrinhos(
            [FromQuery] string usuarioFiltro
        )
        {
            var Carrinhos = _repositorio.ObterCarrinhos();

            if (!string.IsNullOrEmpty(usuarioFiltro))
            {
                Carrinhos = Carrinhos
                    .Where(p => p.Usuario.ToUpper().Contains(usuarioFiltro.ToUpper()))
                    .ToList();
            }

            return Carrinhos;
        }

        [HttpGet("{id}")]
        public ActionResult<Carrinho> ObterCarrinhoPorId(
            [FromRoute] Guid id
        )
        {
            return _repositorio.ObterCarrinhoPorId(id);
        }

        [HttpPost()]
        public ActionResult<Carrinho> AdicionarCarrinho(
            [FromBody] Carrinho carrinho
        )
        {
            var successo = _repositorio.AdicionarCarrinho(carrinho);

            if (!successo) return BadRequest();

            return Created(nameof(AdicionarCarrinho), carrinho);
        }

        [HttpDelete("{id}")]
        public ActionResult<Carrinho> RemoverCarrinho(
            [FromRoute] Guid id
        )
        {
            var carrinho = _repositorio.ObterCarrinhoPorId(id);

            if (carrinho == null) return NotFound();

            var successo = _repositorio.RemoverCarrinho(carrinho);

            if (!successo) return BadRequest();

            return NoContent();
        }

        [HttpPost("{id}/produtos")]
        public ActionResult<Carrinho> AdicionarProdutoEmCarrinho(
            [FromRoute] Guid id, 
            [FromBody] AdicionarCarrinhoProdutoDTO carrinhoProduto 
        )
        {
            var produtoCarrinho = _repositorio.AdicionarProdutoEmCarrinho(
                id, 
                carrinhoProduto.ProdutoId, 
                carrinhoProduto.Quantiadade
            );

            if (produtoCarrinho == null) return BadRequest();

            return Created(nameof(AdicionarProdutoEmCarrinho), produtoCarrinho);
        }

        [HttpDelete("{id}/produtos/{produtoId}")]
        public ActionResult<Carrinho> RemoverProdutoEmCarrinho(
            [FromRoute] Guid id,
            [FromRoute] Guid produtoId
        )
        {
            var carrinho = _repositorio.ObterCarrinhoPorId(id);

            if (carrinho == null) return NotFound();

            var successo = _repositorio.RemoverProdutoEmCarrinho(
                id,
                produtoId
            );

            if (!successo) return BadRequest();

            return NoContent();
        }
    }
}