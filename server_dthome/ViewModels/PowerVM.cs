namespace server_dthome.ViewModels
{
    public class PowerVM
    {
        public int PowerId { get; set; }

        public decimal PricePerUnit { get; set; }

        public DateTime EffectiveDate { get; set; }

        public int? OwnerId { get; set; }
    }
}
