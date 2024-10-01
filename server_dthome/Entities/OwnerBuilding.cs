using System;
using System.Collections.Generic;

namespace server_dthome.Entities;

public partial class OwnerBuilding
{
    public int OwnerId { get; set; }

    public string OwnerName { get; set; } = null!;

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? PhotoUrl { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<MemberOfRental> MemberOfRentals { get; set; } = new List<MemberOfRental>();

    public virtual ICollection<Power> Powers { get; set; } = new List<Power>();

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

    public virtual ICollection<Trash> Trashes { get; set; } = new List<Trash>();

    public virtual ICollection<Water> Water { get; set; } = new List<Water>();
}
