namespace server_dthome.ViewModels
{
    public class WaterVM
    {
        public int WaterId { get; set; }

        public decimal PricePerUnit { get; set; }

        public DateTime EffectiveDate { get; set; }

        public int? OwnerId { get; set; }
    }
}
