using System;
using System.Collections.Generic;

namespace PhonesAPIWeb.Models;

public partial class Iphone
{
    public int IdPhone { get; set; }

    public int IdType { get; set; }

    public string? Model { get; set; }

    public decimal? Price { get; set; }

    public string? CondBateria { get; set; }

    public virtual Phone IdPhoneNavigation { get; set; } = null!;
}
