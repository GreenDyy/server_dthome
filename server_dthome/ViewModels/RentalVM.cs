using server_dthome.Entities;

namespace server_dthome.ViewModels
{
    public class RentalVM
    {
        public int RentalId { get; set; }

        public int? RoomId { get; set; }

        public int? CustomerId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool? IsRenting { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual Customer? Customer { get; set; }

        public virtual ICollection<MemberOfRentalVM> MemberOfRentals { get; set; } = new List<MemberOfRentalVM>();

        public virtual Room? Room { get; set; }
    }
}
