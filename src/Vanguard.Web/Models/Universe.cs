namespace Vanguard.Web.Models
{
    public class Universe
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public int? DisplayOrder { get; set; }
        public bool UsesOffset { get; set; }
        public int? OffsetYears { get; set; }
        public bool UsesBBYABY { get; set; }
        public DateTime? BBYABYAnchorDate { get; set; }
        public string DisplayFormat { get; set; } = "dd MMMM yyyy";
        public bool EnableStardate { get; set; }
        public DateTime? StardateBaseDate { get; set; }
        public double? StardateMultiplier { get; set; }

        public ICollection<Faction>? Factions { get; set; } = new List<Faction>();
        public ICollection<Character>? Characters { get; set; } = new List<Character>();
        public ICollection<Species>? Species { get; set; }
    }
}