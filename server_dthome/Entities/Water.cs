using System;
using System.Collections.Generic;

namespace server_dthome.Entities;

public partial class Water
{
    public int WaterId { get; set; }

    public decimal PricePerUnit { get; set; }

    public DateOnly EffectiveDate { get; set; }
}
