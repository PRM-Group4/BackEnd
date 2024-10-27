using System;
using System.Collections.Generic;

namespace BOs.Models;

public partial class Farm
{
    public int FarmId { get; set; }

    public string Name { get; set; } = null!;

    public string? Location { get; set; }

    public string? Description { get; set; }

    public decimal? Rating { get; set; }

    public string? ContactInfo { get; set; }

    public virtual ICollection<KoiType> KoiTypes { get; set; } = new List<KoiType>();

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
