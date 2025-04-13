namespace Vanguard.Web.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int? UniverseId { get; set; }
        public Universe? Universe { get; set; }
        public int? FactionId { get; set; }
        public Faction? Faction { get; set; }
        public bool IsActive { get; set; } = true;
        public int? DisplayOrder { get; set; }

        public ICollection<Unit> Units { get; set; } = new List<Unit>();
        public ICollection<Character> Characters { get; set; } = new List<Character>();
    }
}