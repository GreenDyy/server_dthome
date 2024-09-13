namespace server_dthome.Models
{
    public class RoomModelUpdate
    {
        public string RoomName { get; set; } = null!;

        public decimal? RoomPrice { get; set; }

        public string? PhotoUrl { get; set; }

        public bool? IsAvailable { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
