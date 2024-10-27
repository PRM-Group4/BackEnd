using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Modal.Request
{
    public class KoiTypeRequest
    {
        public int KoiTypeId { get; set; }

        public string Name { get; set; } = null!;

        public int? FarmId { get; set; }

        public string? Description { get; set; }

        public string? PriceRange { get; set; }

        public string? Image { get; set; }
    }
}
