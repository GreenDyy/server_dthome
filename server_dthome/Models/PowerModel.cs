namespace server_dthome.Models
{
    public class PowerModel
    {

        public decimal PricePerUnit { get; set; }

        public DateTime EffectiveDate { get; set; }

        public int? OwnerId { get; set; }
    }
}
