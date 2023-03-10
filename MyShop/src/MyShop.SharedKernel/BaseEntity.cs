namespace MyShop.SharedKernel
{
    // This can be modified to BaseEntity<TId> to support multiple key types (e.g. Guid)
    public abstract class BaseEntity
    {
        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }

    public abstract class BaseEntity<TId> : BaseEntity
    {
        public TId Id { get; set; }
    }
}