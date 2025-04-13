namespace Vanguard.Web.Models
{
    public class Gender
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public int DisplayOrder { get; set; }

        public ICollection<Character>? Characters { get; set; }
    }
}