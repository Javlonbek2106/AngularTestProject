namespace WebApplication1.DTOs
{
    public class CompanyDTO
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
