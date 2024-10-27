using System;
using System.Collections.Generic;

namespace BOs.Models;

public partial class Trip
{
    public int TripId { get; set; }

    public int? FarmId { get; set; }

    public DateOnly TripDate { get; set; }

    public decimal Price { get; set; }

    public bool Availability { get; set; }

    public virtual Farm? Farm { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<ServiceRequest> ServiceRequests { get; set; } = new List<ServiceRequest>();
}
