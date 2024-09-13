using server_dthome.Entities;

namespace server_dthome.ViewModels
{
    public class CustomerVM
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;

        public string? CitizenId { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? PhotoUrl { get; set; }

        public string? CitizenIdphotoFirstUrl { get; set; }

        public string? CitizenIdphotoBackUrl { get; set; }

        public string? AnotherPhotoUrl { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<MemberOfRentalVM> MemberOfRentals { get; set; } = new List<MemberOfRentalVM>();

        public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    }
}
