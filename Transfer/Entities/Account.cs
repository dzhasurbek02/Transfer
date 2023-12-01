namespace Transfer.Entities
{
    public class Account : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        
        public Guid CurrencyId { get; set; }
        public Currency Currency { get; set; }
    
        public float Balance { get; set; }
    }
}