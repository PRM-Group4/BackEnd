using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BOs.Models;

public partial class KoiFarmManagementContext : DbContext
{
    public KoiFarmManagementContext()
    {
    }

    public KoiFarmManagementContext(DbContextOptions<KoiFarmManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Farm> Farms { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<KoiType> KoiTypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Quotation> Quotations { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<ServiceRequest> ServiceRequests { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    public virtual DbSet<User> Users { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Farm>(entity =>
        {
            entity.HasKey(e => e.FarmId).HasName("PK__Farm__ED7BBA990BF1B28A");

            entity.ToTable("Farm");

            entity.Property(e => e.FarmId).HasColumnName("FarmID");
            entity.Property(e => e.ContactInfo).HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Rating).HasColumnType("decimal(3, 2)");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDF6373952EC");

            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");
            entity.Property(e => e.Comment).HasMaxLength(1000);
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TripId).HasColumnName("TripID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Trip).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.TripId)
                .HasConstraintName("FK__Feedback__TripID__5535A963");

            entity.HasOne(d => d.User).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Feedback__UserID__5441852A");
        });

        modelBuilder.Entity<KoiType>(entity =>
        {
            entity.HasKey(e => e.KoiTypeId).HasName("PK__KoiType__040BD45579963157");

            entity.ToTable("KoiType");

            entity.Property(e => e.KoiTypeId).HasColumnName("KoiTypeID");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.FarmId).HasColumnName("FarmID");
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PriceRange).HasMaxLength(100);

            entity.HasOne(d => d.Farm).WithMany(p => p.KoiTypes)
                .HasForeignKey(d => d.FarmId)
                .HasConstraintName("FK__KoiType__FarmID__4222D4EF");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BAFDB9393D0");

            entity.ToTable("Order");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.DepositAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.FinalAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.KoiTypeId).HasColumnName("KoiTypeID");
            entity.Property(e => e.ServiceRequestId).HasColumnName("ServiceRequestID");
            entity.Property(e => e.Status).HasMaxLength(20);

            entity.HasOne(d => d.KoiType).WithMany(p => p.Orders)
                .HasForeignKey(d => d.KoiTypeId)
                .HasConstraintName("FK__Order__KoiTypeID__5FB337D6");

            entity.HasOne(d => d.ServiceRequest).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ServiceRequestId)
                .HasConstraintName("FK__Order__ServiceRe__5EBF139D");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payment__9B556A58B0F23AF0");

            entity.ToTable("Payment");

            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Method).HasMaxLength(50);
            entity.Property(e => e.ServiceRequestId).HasColumnName("ServiceRequestID");
            entity.Property(e => e.Status).HasMaxLength(20);

            entity.HasOne(d => d.ServiceRequest).WithMany(p => p.Payments)
                .HasForeignKey(d => d.ServiceRequestId)
                .HasConstraintName("FK__Payment__Service__59FA5E80");
        });

        modelBuilder.Entity<Quotation>(entity =>
        {
            entity.HasKey(e => e.QuotationId).HasName("PK__Quotatio__E19752B346FBF157");

            entity.ToTable("Quotation");

            entity.Property(e => e.QuotationId).HasColumnName("QuotationID");
            entity.Property(e => e.ApprovedByUserId).HasColumnName("ApprovedByUserID");
            entity.Property(e => e.QuotationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.QuotedByUserId).HasColumnName("QuotedByUserID");
            entity.Property(e => e.ServiceRequestId).HasColumnName("ServiceRequestID");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.ApprovedByUser).WithMany(p => p.QuotationApprovedByUsers)
                .HasForeignKey(d => d.ApprovedByUserId)
                .HasConstraintName("FK__Quotation__Appro__4F7CD00D");

            entity.HasOne(d => d.QuotedByUser).WithMany(p => p.QuotationQuotedByUsers)
                .HasForeignKey(d => d.QuotedByUserId)
                .HasConstraintName("FK__Quotation__Quote__4E88ABD4");

            entity.HasOne(d => d.ServiceRequest).WithMany(p => p.Quotations)
                .HasForeignKey(d => d.ServiceRequestId)
                .HasConstraintName("FK__Quotation__Servi__4D94879B");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Report__D5BD48E587D285B6");

            entity.ToTable("Report");

            entity.Property(e => e.ReportId).HasColumnName("ReportID");
            entity.Property(e => e.DateRange).HasMaxLength(100);
            entity.Property(e => e.TotalSales).HasColumnType("decimal(15, 2)");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE3A92857635");

            entity.ToTable("Role");

            entity.HasIndex(e => e.RoleName, "UQ__Role__8A2B6160931E650D").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<ServiceRequest>(entity =>
        {
            entity.HasKey(e => e.ServiceRequestId).HasName("PK__ServiceR__790F6CAB7B4A7723");

            entity.ToTable("ServiceRequest");

            entity.Property(e => e.ServiceRequestId).HasColumnName("ServiceRequestID");
            entity.Property(e => e.RequestDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TripId).HasColumnName("TripID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Trip).WithMany(p => p.ServiceRequests)
                .HasForeignKey(d => d.TripId)
                .HasConstraintName("FK__ServiceRe__TripI__48CFD27E");

            entity.HasOne(d => d.User).WithMany(p => p.ServiceRequests)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__ServiceRe__UserI__47DBAE45");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.TripId).HasName("PK__Trip__51DC711ECE86D0F3");

            entity.ToTable("Trip");

            entity.Property(e => e.TripId).HasColumnName("TripID");
            entity.Property(e => e.FarmId).HasColumnName("FarmID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Farm).WithMany(p => p.Trips)
                .HasForeignKey(d => d.FarmId)
                .HasConstraintName("FK__Trip__FarmID__44FF419A");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CCAC7D781ECF");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "UQ__User__A9D10534D77ADA4E").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.ContactInfo).HasMaxLength(255);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Position).HasMaxLength(50);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.UserName).HasMaxLength(100);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__User__RoleID__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
