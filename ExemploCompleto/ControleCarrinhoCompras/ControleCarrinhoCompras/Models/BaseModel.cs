namespace ControleCarrinhoCompras.Models
{
    public class BaseModel
    {
        public Guid Id { get; internal set; } = Guid.NewGuid();

        public override bool Equals(object? obj)
        {
            return obj is BaseModel model &&
                   Id.Equals(model.Id);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public void AtribuirId(Guid id)
        {
            Id = id;
        }
    }
}
