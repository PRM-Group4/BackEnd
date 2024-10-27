using System;
using System.Collections.Generic;

namespace BOs.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? ServiceRequestId { get; set; }

    public int? KoiTypeId { get; set; }

    public decimal? DepositAmount { get; set; }

    public decimal? FinalAmount { get; set; }

    public DateOnly? DeliveryDate { get; set; }

    public string? Status { get; set; }

    public virtual KoiType? KoiType { get; set; }

    public virtual ServiceRequest? ServiceRequest { get; set; }
}
