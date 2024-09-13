namespace server_dthome.ViewModels
{
    public class RoomVM
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; } = null!;

        public decimal? RoomPrice { get; set; }

        public string? PhotoUrl { get; set; }

        public bool? IsAvailable { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
