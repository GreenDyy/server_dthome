using System;
using System.Collections.Generic;

namespace server_dthome.Entities;

public partial class MemberOfRental
{
    public int MemberOfRentalId { get; set; }

    public int? RentalId { get; set; }

    public int? CustomerId { get; set; }

    public string? RoleMember { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Rental? Rental { get; set; }
}
