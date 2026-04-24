using System;
using System.Collections.Generic;

namespace EntityF_proy.Models;

public partial class Samsung
{
    public int IdPhone { get; set; }

    public int IdType { get; set; }

    public string? Model { get; set; }

    public decimal? Price { get; set; }

    public string? Serie { get; set; }

    public virtual Phone IdPhoneNavigation { get; set; } = null!;
}
