using server_dthome.Entities;

namespace server_dthome.ViewModels
{
    public class OwnerAccountVM
    {
        public int AccountId { get; set; }

        public int OwnerId { get; set; }

        public string PhoneNumber { get; set; } = null!;

        public string Password { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
