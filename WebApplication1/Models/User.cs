using System.Text.Json.Serialization;

namespace WebApplication1.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Fullname { get; set; }

    public string? Phonenumber { get; set; }

    public int? Age { get; set; }

    [JsonIgnore]
    public virtual Company? Company { get; set; }
    public Guid? CompanyId { get; set; }

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
