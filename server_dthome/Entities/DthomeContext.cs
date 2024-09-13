using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace server_dthome.Entities;

public partial class DthomeContext : DbContext
{
    public DthomeContext()
    {
    }

    public DthomeContext(DbContextOptions<DthomeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<MemberOfRental> MemberOfRentals { get; set; }

    public virtual DbSet<Rental> Rentals { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=GREEND;Initial Catalog=DTHome;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D8445FC040");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.CitizenId, "UQ__Customer__6E49FBED7AF0035E").IsUnique();

            entity.Property(e => e.AnotherPhotoUrl)
                .HasMaxLength(255)
                .HasColumnName("AnotherPhotoURL");
            entity.Property(e => e.CitizenId)
                .HasMaxLength(20)
                .HasColumnName("CitizenID");
            entity.Property(e => e.CitizenIdphotoBackUrl)
                .HasMaxLength(255)
                .HasColumnName("CitizenIDPhotoBackURL");
            entity.Property(e => e.CitizenIdphotoFirstUrl)
                .HasMaxLength(255)
                .HasColumnName("CitizenIDPhotoFirstURL");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CustomerName).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.PhotoUrl)
                .HasMaxLength(255)
                .HasColumnName("PhotoURL");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<MemberOfRental>(entity =>
        {
            entity.HasKey(e => e.MemberOfRentalId).HasName("PK__MemberOf__766D4F363F7BCABD");

            entity.ToTable("MemberOfRental");

            entity.Property(e => e.RoleMember).HasMaxLength(50);

            entity.HasOne(d => d.Customer).WithMany(p => p.MemberOfRentals)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_MemberOfRental_Customer");

            entity.HasOne(d => d.Rental).WithMany(p => p.MemberOfRentals)
                .HasForeignKey(d => d.RentalId)
                .HasConstraintName("FK_MemberOfRental_Rental");
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity.HasKey(e => e.RentalId).HasName("PK__Rental__970059430C5F69F2");

            entity.ToTable("Rental");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.IsRenting).HasDefaultValue(true);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Rental_Customer");

            entity.HasOne(d => d.Room).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK_Rental_Room");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__Room__32863939EFB46B67");

            entity.ToTable("Room");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsAvailable).HasDefaultValue(true);
            entity.Property(e => e.PhotoUrl)
                .HasMaxLength(255)
                .HasColumnName("PhotoURL");
            entity.Property(e => e.RoomName).HasMaxLength(100);
            entity.Property(e => e.RoomPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
