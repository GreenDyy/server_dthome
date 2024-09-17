namespace server_dthome.Models
{
    public class CustomerModel
    {
        public string CustomerName { get; set; } = null!;

        public string? CitizenId { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? PhotoUrl { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? CitizenIdphotoFirstUrl { get; set; }

        public string? CitizenIdphotoBackUrl { get; set; }

        public string? AnotherPhotoUrl { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
