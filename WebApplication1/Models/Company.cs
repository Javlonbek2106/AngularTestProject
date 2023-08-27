using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Company
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
