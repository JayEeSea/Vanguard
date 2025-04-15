namespace Vanguard.Web.Models
{
    public class Faction
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int? UniverseId { get; set; }
        public Universe? Universe { get; set; }
        public bool IsActive { get; set; } = true;
        public int? DisplayOrder { get; set; }

        public ICollection<Branch> Branches { get; set; } = new List<Branch>();
        public ICollection<Character> Characters { get; set; } = new List<Character>();
        public ICollection<Species>? Species { get; set; }
    }
}