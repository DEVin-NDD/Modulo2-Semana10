using Aula2NDD.Models;

namespace Aula2NDD.ViewModels;

public class ClienteComContasViewModel
{
    public string Nome { get; set; }
    public List<Conta> Contas { get; set; }

    public ClienteComContasViewModel(string nome, List<Conta> contas)
    {
        Nome = nome;
        Contas = contas;
    }
}
