using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Modal.Request
{
    public class ReportRequest
    {
        public int ReportId { get; set; }

        public string? DateRange { get; set; }

        public decimal? TotalSales { get; set; }

        public int? TotalTrips { get; set; }

        public int? TotalCustomers { get; set; }

        public int? TotalFeedback { get; set; }
    }
}
