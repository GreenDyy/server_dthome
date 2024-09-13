using server_dthome.Entities;

namespace server_dthome.ViewModels
{
    public class MemberOfRentalVM
    {
        public int MemberOfRentalId { get; set; }

        public int? RentalId { get; set; }

        public int? CustomerId { get; set; }

        public string? RoleMember { get; set; }

        public string? PhotoUrl { get; set; }

        public virtual Customer? Customer { get; set; }

        public virtual Rental? Rental { get; set; }
    }
}
