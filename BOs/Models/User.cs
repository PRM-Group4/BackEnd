using System;
using System.Collections.Generic;

namespace BOs.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public int? RoleId { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? Status { get; set; }

    public string? Position { get; set; }

    public string? ContactInfo { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Quotation> QuotationApprovedByUsers { get; set; } = new List<Quotation>();

    public virtual ICollection<Quotation> QuotationQuotedByUsers { get; set; } = new List<Quotation>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<ServiceRequest> ServiceRequests { get; set; } = new List<ServiceRequest>();
}
