using System;
using System.Collections.Generic;

namespace server_dthome.Entities;

public partial class Power
{
    public int PowerId { get; set; }

    public decimal PricePerUnit { get; set; }

    public DateOnly EffectiveDate { get; set; }
}
