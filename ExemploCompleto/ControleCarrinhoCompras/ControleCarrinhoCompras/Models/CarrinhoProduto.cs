using System.ComponentModel.DataAnnotations;

namespace ControleCarrinhoCompras.Models
{
    public class CarrinhoProduto
    {
        public Produto Produto { get; set; }
        [Range(1, 15, ErrorMessage = "A quantidade deve estar entre 1 e 15.")]
        public int Quantidade { get; set; }
    }
}
