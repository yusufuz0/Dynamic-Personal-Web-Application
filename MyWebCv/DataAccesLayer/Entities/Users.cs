using System;
using System.Collections.Generic;

namespace DataAccesLayer.Entities;

public partial class Users
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime? RegistrationTime { get; set; }

    public int? Role { get; set; }

    public virtual ICollection<Comments> Comments { get; set; } = new List<Comments>();
}
