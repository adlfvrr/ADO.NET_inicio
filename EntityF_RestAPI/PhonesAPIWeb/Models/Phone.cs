using System;
using System.Collections.Generic;

namespace PhonesAPIWeb.Models;

public partial class Phone
{
    public int IdPhone { get; set; }

    public int IdType { get; set; }

    public int? Stock { get; set; }

    public virtual Iphone? Iphone { get; set; }

    public virtual Samsung? Samsung { get; set; }
}
