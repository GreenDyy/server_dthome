using server_dthome.Entities;

namespace server_dthome.Models
{
    public class InvoiceModel
    {

        public int RentalId { get; set; }

        public int CustomerId { get; set; }

        public int RoomId { get; set; }

        public DateTime CreateAt { get; set; }

        public decimal Amount { get; set; }

        public string? Status { get; set; }

        public string? Description { get; set; }

        public decimal? WaterStart { get; set; }

        public decimal? WaterEnd { get; set; }

        public decimal? PowerStart { get; set; }

        public decimal? PowerEnd { get; set; }

        public decimal? WaterUsage { get; set; }

        public decimal? PowerUsage { get; set; }

        public int? OwnerId { get; set; }
    }
}
