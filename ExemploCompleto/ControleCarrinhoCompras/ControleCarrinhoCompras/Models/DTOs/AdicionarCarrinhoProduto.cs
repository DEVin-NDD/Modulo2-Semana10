using System.ComponentModel.DataAnnotations;

namespace ControleCarrinhoCompras.Models.DTOs
{
    public record AdicionarCarrinhoProdutoDTO
    {
        public Guid ProdutoId { get; set; }
        [Range(1, 15, ErrorMessage = "A quantidade deve estar entre 1 e 15.")]
        public int Quantiadade { get; set; }
    }
}
