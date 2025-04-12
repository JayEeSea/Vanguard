namespace Vanguard.Web.Models
{
    public class Rank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string? ImageUrl { get; set; }
        public int UniverseId { get; set; }
        public Universe? Universe { get; set; }
        public int? FactionId { get; set; }
        public Faction? Faction { get; set; }
        public int? BranchId { get; set; }
        public Branch? Branch { get; set; }
        public int Level { get; set; }
        public ICollection<Character> Characters { get; set; }
    }
}