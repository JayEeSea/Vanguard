namespace Vanguard.Web.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int UniverseParentId { get; set; }
        public Universe Universe { get; set; }
        public int FactionParentId { get; set; }
        public Faction Faction { get; set; }

        public ICollection<Unit> Units { get; set; } = new List<Unit>();
        public ICollection<Character> Characters { get; set; } = new List<Character>();
    }
}