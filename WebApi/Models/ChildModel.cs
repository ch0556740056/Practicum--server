namespace WebApi.Models
{
    public class ChildModel
    {
        public string Identity { get; set; } = null!;

        public string Name { get; set; } = null!;

        public DateTime DateOfBirdth { get; set; }

        public string ParentId { get; set; } = null!;
    }
}
