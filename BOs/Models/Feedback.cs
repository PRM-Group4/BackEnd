using System;
using System.Collections.Generic;

namespace BOs.Models;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public int? UserId { get; set; }

    public int? TripId { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime? Date { get; set; }

    public virtual Trip? Trip { get; set; }

    public virtual User? User { get; set; }
}
