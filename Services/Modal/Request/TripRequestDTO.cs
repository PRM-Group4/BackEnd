using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Modal.Request
{
    public class TripRequestDTO
    {
        public int TripId { get; set; }

        public int? FarmId { get; set; }

        public DateOnly TripDate { get; set; }

        public decimal Price { get; set; }

        public bool Availability { get; set; }
    }
}
