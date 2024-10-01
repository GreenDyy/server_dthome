namespace server_dthome.ViewModels
{
    public class RoomVM
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; } = null!;

        public decimal? RoomPrice { get; set; }
        public int WaterAfter { get; set; }

        public int WaterBefore { get; set; }

        public int PowerAfter { get; set; }

        public int PowerBefore { get; set; }

        public string? PhotoUrl { get; set; }

        public bool? IsAvailable { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? OwnerId { get; set; }
    }
}
