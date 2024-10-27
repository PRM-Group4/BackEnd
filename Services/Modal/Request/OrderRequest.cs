using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Modal.Request
{
    public class OrderRequest
    {
        public int OrderId { get; set; }

        public int? ServiceRequestId { get; set; }

        public int? KoiTypeId { get; set; }

        public decimal? DepositAmount { get; set; }

        public decimal? FinalAmount { get; set; }

        public DateOnly? DeliveryDate { get; set; }

        public string? Status { get; set; }
    }
}
