namespace SampleUserManagement.Domain
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; protected set; }
    }
}
