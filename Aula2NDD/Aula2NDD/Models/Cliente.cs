using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Aula2NDD.Models
{
    public class Cliente
    {
        public int Id { get; internal set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public TipoCliente Tipo { get; set; }
        public List<Conta> Contas { get; set; }

        public Cliente(string nome, int idade, TipoCliente tipo)
        {
            Nome = nome;
            Idade = idade;
            Tipo = tipo;
        }

        public void AdicionarConta(Conta conta){
            Contas ??= new List<Conta>();

            Contas.Add(conta);
        }
    }
}
