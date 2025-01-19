using System;
using System.Collections.Generic;

namespace DataAccesLayer.Entities;

public partial class Comments
{
    public int Id { get; set; }

    public string? Context { get; set; }

    public int? UserId { get; set; }

    public string? Username { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual Users? User { get; set; }
}
