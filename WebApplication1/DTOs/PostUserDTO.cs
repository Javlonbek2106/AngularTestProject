namespace WebApplication1.DTOs
{
    public class PostUserDTO
    {
        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Fullname { get; set; }

        public string? Phonenumber { get; set; }

        public int? Age { get; set; }
        public Guid CompanyId { get; set; }
    }
}
