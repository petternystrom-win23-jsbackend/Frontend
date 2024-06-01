namespace Frontend.Models
{
    public class NewsletterSubscription
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public bool IsSubscribed { get; set; }
    }
}
