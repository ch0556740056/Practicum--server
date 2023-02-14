namespace WebApi.Models
{
    public class PersonDetailModel
    {
        public string Identity { get; set; } = null!;

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int? Gender { get; set; }

        public string? Hmo { get; set; }

        public DateTime? DateOfBirdth { get; set; }
    }
}
