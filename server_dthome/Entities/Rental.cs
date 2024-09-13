using System;
using System.Collections.Generic;

namespace server_dthome.Entities;

public partial class Rental
{
    public int RentalId { get; set; }

    public int? RoomId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public bool? IsRenting { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<MemberOfRental> MemberOfRentals { get; set; } = new List<MemberOfRental>();

    public virtual Room? Room { get; set; }
}
