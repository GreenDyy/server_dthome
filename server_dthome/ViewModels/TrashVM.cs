namespace server_dthome.ViewModels
{
    public class TrashVM
    {
        public int TrashId { get; set; }

        public decimal PricePerUnit { get; set; }

        public DateTime EffectiveDate { get; set; }

        public int? OwnerId { get; set; }
    }
}
