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

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<MemberOfRental> MemberOfRentals { get; set; }

    public virtual DbSet<OwnerAccount> OwnerAccounts { get; set; }

    public virtual DbSet<OwnerBuilding> OwnerBuildings { get; set; }

    public virtual DbSet<Power> Powers { get; set; }

    public virtual DbSet<Rental> Rentals { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Trash> Trashes { get; set; }

    public virtual DbSet<Water> Water { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DTHome;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D8927C52C4");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.CitizenId, "UQ__Customer__6E49FBEDAF796816").IsUnique();

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
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.PhotoUrl)
                .HasMaxLength(255)
                .HasColumnName("PhotoURL");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Owner).WithMany(p => p.Customers)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK_Customer_Owner");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PK__Invoice__D796AAD5CCE2693F");

            entity.ToTable("Invoice");

            entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.PowerEnd).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PowerStart).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PowerUsage).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.RentalId).HasColumnName("RentalID");
            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.WaterEnd).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.WaterStart).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.WaterUsage).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Invoice__Custome__5535A963");

            entity.HasOne(d => d.Owner).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK_Invoice_Owner");

            entity.HasOne(d => d.Room).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Invoice__RoomID__5629CD9C");
        });

        modelBuilder.Entity<MemberOfRental>(entity =>
        {
            entity.HasKey(e => e.MemberOfRentalId).HasName("PK__MemberOf__766D4F364FE26B57");

            entity.ToTable("MemberOfRental");

            entity.Property(e => e.RoleMember).HasMaxLength(50);

            entity.HasOne(d => d.Customer).WithMany(p => p.MemberOfRentals)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_MemberOfRental_Customer");

            entity.HasOne(d => d.Owner).WithMany(p => p.MemberOfRentals)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK_MemberOfRental_Owner");

            entity.HasOne(d => d.Rental).WithMany(p => p.MemberOfRentals)
                .HasForeignKey(d => d.RentalId)
                .HasConstraintName("FK_MemberOfRental_Rental");
        });

        modelBuilder.Entity<OwnerAccount>(entity =>
        {
            entity.HasKey(e => e.AccountId);

            entity.ToTable("OwnerAccount");

            entity.HasIndex(e => e.PhoneNumber, "UQ__OwnerAcc__85FB4E38A372D052").IsUnique();

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Owner).WithMany(p => p.OwnerAccounts)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OwnerAcco__Owner__5AEE82B9");
        });

        modelBuilder.Entity<OwnerBuilding>(entity =>
        {
            entity.HasKey(e => e.OwnerId).HasName("PK__OwnerBui__819385B8C8593AEA");

            entity.ToTable("OwnerBuilding");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.OwnerName).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.PhotoUrl)
                .HasMaxLength(255)
                .HasColumnName("PhotoURL");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Power>(entity =>
        {
            entity.HasKey(e => e.PowerId).HasName("PK__Power__8C5F25B0BF385860");

            entity.ToTable("Power");

            entity.Property(e => e.PowerId).HasColumnName("PowerID");
            entity.Property(e => e.EffectiveDate).HasColumnType("datetime");
            entity.Property(e => e.PricePerUnit).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Owner).WithMany(p => p.Powers)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK_Power_Owner");
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity.HasKey(e => e.RentalId).HasName("PK__Rental__97005943B5EF65BE");

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

            entity.HasOne(d => d.Owner).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK_Rental_Owner");

            entity.HasOne(d => d.Room).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK_Rental_Room");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__Room__3286393918D243CA");

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

            entity.HasOne(d => d.Owner).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK_Room_Owner");
        });

        modelBuilder.Entity<Trash>(entity =>
        {
            entity.HasKey(e => e.TrashId).HasName("PK__Trash__E7477AC42D661411");

            entity.ToTable("Trash");

            entity.Property(e => e.TrashId).HasColumnName("TrashID");
            entity.Property(e => e.EffectiveDate).HasColumnType("datetime");
            entity.Property(e => e.PricePerUnit).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Owner).WithMany(p => p.Trashes)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK_Trash_Owner");
        });

        modelBuilder.Entity<Water>(entity =>
        {
            entity.HasKey(e => e.WaterId).HasName("PK__Water__C4F18EAFE85E264A");

            entity.Property(e => e.WaterId).HasColumnName("WaterID");
            entity.Property(e => e.EffectiveDate).HasColumnType("datetime");
            entity.Property(e => e.PricePerUnit).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Owner).WithMany(p => p.Water)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK_Water_Owner");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
