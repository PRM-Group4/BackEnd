using System;
using System.Collections.Generic;

namespace BOs.Models;

public partial class Report
{
    public int ReportId { get; set; }

    public string? DateRange { get; set; }

    public decimal? TotalSales { get; set; }

    public int? TotalTrips { get; set; }

    public int? TotalCustomers { get; set; }

    public int? TotalFeedback { get; set; }
}
