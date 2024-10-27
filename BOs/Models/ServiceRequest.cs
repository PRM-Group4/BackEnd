using System;
using System.Collections.Generic;

namespace BOs.Models;

public partial class ServiceRequest
{
    public int ServiceRequestId { get; set; }

    public int? UserId { get; set; }

    public int? TripId { get; set; }

    public DateTime? RequestDate { get; set; }

    public string? Status { get; set; }

    public decimal? TotalAmount { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Quotation> Quotations { get; set; } = new List<Quotation>();

    public virtual Trip? Trip { get; set; }

    public virtual User? User { get; set; }
}
