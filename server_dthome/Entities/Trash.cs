using System;
using System.Collections.Generic;

namespace server_dthome.Entities;

public partial class Trash
{
    public int TrashId { get; set; }

    public decimal PricePerUnit { get; set; }

    public DateTime EffectiveDate { get; set; }

    public int? OwnerId { get; set; }

    public virtual OwnerBuilding? Owner { get; set; }
}
