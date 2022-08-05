using Aula2NDD.Models;
using Aula2NDD.ViewModels;

namespace Aula2NDD.Repositories;

public class ClienteRepository
{
    private static int _idIndice = 1;
    private static int _idContaIndice = 1;
    private static List<Cliente> _clientes = new();

    public Cliente ObterPorId(int id)
    {
        return _clientes.FirstOrDefault(cliente => cliente.Id == id);
    }

    public List<Cliente> ObterTodos()
    {
        return _clientes;
    }

    public List<Cliente> ObterPorIdade(int idade)
    {
        return _clientes
            .Where(c => c.Idade == idade)
            .ToList();
    }

    public bool ExisteClienteComNome(string nome)
    {
        return _clientes
            .Where(c => c.Nome == nome)
            .Any();
    }

    public List<ClienteComContasViewModel> ObterClientesComContas(){
        return _clientes
                .Select(cliente => 
                    new ClienteComContasViewModel(cliente.Nome, cliente.Contas)
                )
                .ToList();
    }

    public Cliente Adicionar(Cliente cliente)
    {
        cliente.Id = _idIndice;

        _idIndice++;

        _clientes.Add(cliente);

        return cliente;
    }

    public Cliente Atualizar(Cliente cliente)
    {
        var clienteAtual = ObterPorId(cliente.Id);

        clienteAtual.Nome = cliente.Nome;
        clienteAtual.Idade = cliente.Idade;
        clienteAtual.Tipo = cliente.Tipo;
        clienteAtual.Contas = cliente.Contas;

        return clienteAtual;
    }

    public void Remover(int id)
    {
        var cliente = ObterPorId(id);

        if(cliente == null) return;

        _clientes.Remove(cliente);
    }

    public Cliente AdicionarConta(Cliente cliente, Conta conta){
        conta.Id = _idContaIndice;

        _idContaIndice++;

        cliente.AdicionarConta(conta);

        return cliente;
    }
}
