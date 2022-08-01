using System.ComponentModel.DataAnnotations;

namespace ControleCarrinhoCompras.Models
{
    public class Produto : BaseModel
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Range(1, 1000, ErrorMessage = "O valor deve ser maior que 0 e menor que 1000.")]
        public decimal Valor { get; set; }
    }
}
