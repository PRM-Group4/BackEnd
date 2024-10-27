using System;
using System.Collections.Generic;

namespace BOs.Models;

public partial class KoiType
{
    public int KoiTypeId { get; set; }

    public string Name { get; set; } = null!;

    public int? FarmId { get; set; }

    public string? Description { get; set; }

    public string? PriceRange { get; set; }

    public string? Image { get; set; }

    public virtual Farm? Farm { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
