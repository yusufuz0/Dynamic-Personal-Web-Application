using System;
using System.Collections.Generic;

namespace DataAccesLayer.Entities;

public partial class Datas
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? About { get; set; }

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? Education { get; set; }
}
