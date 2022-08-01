using ControleCarrinhoCompras.Models;

namespace ControleCarrinhoCompras.Repositorios
{
    public class CarrinhoRepositorio
    {
        private ProdutoRepositorio _produtoRepositorio;

        public CarrinhoRepositorio(ProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        private static readonly List<Carrinho> _carrinhos = new();

        public bool AdicionarCarrinho(Carrinho carrinho)
        {
            if (_carrinhos.Contains(carrinho))
            {
                return false;
            }

            _carrinhos.Add(carrinho);

            return true;
        }

        public bool RemoverCarrinho(Carrinho carrinho)
        {
            if (!_carrinhos.Contains(carrinho))
            {
                return false;
            }

            _carrinhos.Remove(carrinho);

            return true;
        }

        public CarrinhoProduto AdicionarProdutoEmCarrinho(Guid carrinhoId, Guid produtoId, int quantidade)
        {
            var carrinho = ObterCarrinhoPorId(carrinhoId);

            if (carrinho == null) return null;

            var produto = _produtoRepositorio.ObterProdutoPorId(produtoId);

            if (produto == null) return null;

            return carrinho.AdicionarProduto(produto, quantidade);
        }

        public bool RemoverProdutoEmCarrinho(Guid carrinhoId, Guid produtoId)
        {
            var carrinho = ObterCarrinhoPorId(carrinhoId);

            if (carrinho == null) return false;

            return carrinho.RemoverProduto(produtoId);
        }

        public List<Carrinho> ObterCarrinhos()
        {
            return _carrinhos;
        }

        public Carrinho ObterCarrinhoPorId(Guid id)
        {
            return _carrinhos.SingleOrDefault(p => p.Id == id);
        }
    }
}