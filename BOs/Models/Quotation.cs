using System;
using System.Collections.Generic;

namespace BOs.Models;

public partial class Quotation
{
    public int QuotationId { get; set; }

    public int? ServiceRequestId { get; set; }

    public int? QuotedByUserId { get; set; }

    public int? ApprovedByUserId { get; set; }

    public DateTime? QuotationDate { get; set; }

    public string? Status { get; set; }

    public decimal? TotalPrice { get; set; }

    public virtual User? ApprovedByUser { get; set; }

    public virtual User? QuotedByUser { get; set; }

    public virtual ServiceRequest? ServiceRequest { get; set; }
}
