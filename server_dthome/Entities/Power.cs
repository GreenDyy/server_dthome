using System;
using System.Collections.Generic;

namespace server_dthome.Entities;

public partial class Power
{
    public int PowerId { get; set; }

    public decimal PricePerUnit { get; set; }

    public DateTime EffectiveDate { get; set; }

    public int? OwnerId { get; set; }

    public virtual OwnerBuilding? Owner { get; set; }
}
