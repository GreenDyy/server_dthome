using server_dthome.Entities;

namespace server_dthome.Models
{
    public class RentalModel
    {
        public int? RoomId { get; set; }

        public int? CustomerId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool? IsRenting { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? OwnerId { get; set; }
    }
}
