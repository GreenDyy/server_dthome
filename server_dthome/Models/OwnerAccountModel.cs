namespace server_dthome.Models
{
    public class OwnerAccountModel
    {
        public int OwnerId { get; set; }

        public string PhoneNumber { get; set; } = null!;

        public string Password { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
