using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Modal.Request
{
    public class FeedbackRequest
    {

        public int FeedbackId { get; set; }

        public int? UserId { get; set; }

        public int? TripId { get; set; }

        public int? Rating { get; set; }

        public string? Comment { get; set; }

        public DateTime? Date { get; set; }
    }
}
