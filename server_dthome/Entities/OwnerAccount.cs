using System;
using System.Collections.Generic;

namespace server_dthome.Entities;

public partial class OwnerAccount
{
    public int AccountId { get; set; }

    public int OwnerId { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual OwnerBuilding Owner { get; set; } = null!;
}
