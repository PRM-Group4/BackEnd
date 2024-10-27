using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Modal.Request
{
    public class QuotationRequest
    {
        public int QuotationId { get; set; }

        public int? ServiceRequestId { get; set; }

        public int? QuotedByUserId { get; set; }

        public int? ApprovedByUserId { get; set; }

        public DateTime? QuotationDate { get; set; }

        public string? Status { get; set; }

        public decimal? TotalPrice { get; set; }

    }
}
