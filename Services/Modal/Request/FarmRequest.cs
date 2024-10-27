using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Modal.Request
{
    public class FarmRequest
    {
        public int FarmId { get; set; }

        public string Name { get; set; } = null!;

        public string? Location { get; set; }

        public string? Description { get; set; }

        public decimal? Rating { get; set; }

        public string? ContactInfo { get; set; }
    }
}
