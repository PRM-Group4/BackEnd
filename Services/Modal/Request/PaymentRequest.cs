using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Modal.Request
{
    public class PaymentRequest
    {
        public int PaymentId { get; set; }

        public int? ServiceRequestId { get; set; }

        public decimal Amount { get; set; }

        public DateTime? Date { get; set; }

        public string? Method { get; set; }

        public string? Status { get; set; }
    }
}
