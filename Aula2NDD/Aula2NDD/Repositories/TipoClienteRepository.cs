using Aula2NDD.Models;

namespace Aula2NDD.Repositories;

public class TipoClienteRepository
{
    private static List<TipoCliente> _tipoClientes = new()
        {
            new TipoCliente(1, "Padrão"),
            new TipoCliente(2, "Premium")
        };

    public TipoCliente ObterPorId(int id){
        return _tipoClientes.FirstOrDefault(tipoCliente => tipoCliente.Id == id);
    }
}
