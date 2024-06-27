namespace Core.Entities
{
    public class Base
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
    }
}
