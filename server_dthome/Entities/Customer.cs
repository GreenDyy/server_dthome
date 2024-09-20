using System;
using System.Collections.Generic;

namespace server_dthome.Entities;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string? CitizenId { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? PhotoUrl { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? CitizenIdphotoFirstUrl { get; set; }

    public string? CitizenIdphotoBackUrl { get; set; }

    public string? AnotherPhotoUrl { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<MemberOfRental> MemberOfRentals { get; set; } = new List<MemberOfRental>();

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}
