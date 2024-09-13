﻿using server_dthome.Entities;

namespace server_dthome.Models
{
    public class MemberOfRentalModel
    {
        public int? RentalId { get; set; }

        public int? CustomerId { get; set; }

        public string? RoleMember { get; set; }

        public virtual Customer? Customer { get; set; }

        public virtual Rental? Rental { get; set; }
    }
}
