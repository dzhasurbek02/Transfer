namespace Transfer.Entities
{
    public class Account : BaseEntity
    {
        public Guid UserId { get; set; }
    
        public User User { get; set; }
    
        public string Type { get; set; }
    
        public float Balance { get; set; }
    }
}