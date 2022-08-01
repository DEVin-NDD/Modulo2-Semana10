using ControleCarrinhoCompras.Models;

namespace ControleCarrinhoCompras.Repositorios
{
    public class ProdutoRepositorio
    {
        private static readonly List<Produto> _produtos = new ();

        public bool AdicionarProduto(Produto produto)
        {
            if (_produtos.Contains(produto))
            {
                return false;
            }

            _produtos.Add(produto);

            return true;
        }

        public bool AtualizarProduto(Produto produto)
        {
            if (!_produtos.Contains(produto))
            {
                return false;
            }

            _produtos.Remove(produto);

            _produtos.Add(produto);

            return true;
        }

        public bool RemoverProduto(Produto produto)
        {
            if (!_produtos.Contains(produto))
            {
                return false;
            }

            _produtos.Remove(produto);

            return true;
        }

        public List<Produto> ObterProdutos()
        {
            return _produtos;
        }

        public Produto ObterProdutoPorId(Guid id)
        {
            return _produtos.SingleOrDefault(p => p.Id == id);
        }
    }
}