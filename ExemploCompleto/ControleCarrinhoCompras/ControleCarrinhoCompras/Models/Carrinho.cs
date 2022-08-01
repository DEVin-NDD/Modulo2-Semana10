using System.ComponentModel.DataAnnotations;

namespace ControleCarrinhoCompras.Models
{
    public class Carrinho : BaseModel
    {
        public DateTime AtualizadoEm { get; set; }
        [Required(ErrorMessage = "O usuário é obrigatório")]
        public string Usuario { get; set; }
        public List<CarrinhoProduto> Produtos { get; internal set; } = new();
        public decimal ValorTotal => Produtos?.Sum(p => p.Produto.Valor * p.Quantidade) ?? 0;

        public CarrinhoProduto AdicionarProduto(Produto produto, int quantidade)
        {
            var carrinhoProduto = new CarrinhoProduto
            {
                Produto = produto,
                Quantidade = quantidade
            };

            Produtos.Add(carrinhoProduto);

            return carrinhoProduto;
        }
        public bool RemoverProduto(Guid produtoId)
        {
            var produtoIndex = Produtos.FindIndex(p => p.Produto.Id == produtoId);

            if (produtoIndex < 0)
                return false;

            Produtos.RemoveAt(produtoIndex);

            return true;
        }
    }
}
