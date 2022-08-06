using System.ComponentModel.DataAnnotations;

namespace ApiMusicas.Api.Models;

public class Artista
{
    public int Id { get; internal set; }
    [Required(ErrorMessage = "O nome do artista é obrigatório.")]
    public string Nome { get; set; }
    public string NomeArtistico { get; set; }
    public string FotoUrl { get; set; }
    public string PaisOrigem { get; set; }
}