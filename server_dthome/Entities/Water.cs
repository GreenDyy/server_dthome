using System;
using System.Collections.Generic;

namespace server_dthome.Entities;

public partial class Water
{
    public int WaterId { get; set; }

    public decimal PricePerUnit { get; set; }

    public DateTime EffectiveDate { get; set; }

    public int? OwnerId { get; set; }

    public virtual OwnerBuilding? Owner { get; set; }
}
