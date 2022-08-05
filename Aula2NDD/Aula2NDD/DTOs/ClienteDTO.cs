using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Aula2NDD.DTOs;

public class ClienteDTO
{
    [Required(ErrorMessage = "O nome do cliente é obrigatório.")]
    [StringLength(40)]
    public string Nome { get; set; }
    [Range(minimum: 1, maximum: 200)]
    public int Idade { get; set; }
    public int TipoClienteId { get; set; }
}
