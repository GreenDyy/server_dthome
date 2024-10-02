using server_dthome.Entities;

namespace server_dthome.ViewModels
{
    public class OwnerBuildingVM
    {
        public int OwnerId { get; set; }

        public string OwnerName { get; set; } = null!;

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? PhotoUrl { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
