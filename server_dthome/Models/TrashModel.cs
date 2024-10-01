namespace server_dthome.Models
{
    public class TrashModel
    {

        public decimal PricePerUnit { get; set; }

        public DateTime EffectiveDate { get; set; }

        public int? OwnerId { get; set; }
    }
}
