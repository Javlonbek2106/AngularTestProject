namespace WebApplication1.DTOs
{
    public class PostCompanyDTO
    {

        public string? Name { get; set; }

        public string? Address { get; set; }

        public DateTime? CreatedDate { get; set; } = new DateTime(2020, 2, 2);
    }
}
