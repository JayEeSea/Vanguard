namespace Vanguard.Web.Models
{
    public class Universe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public ICollection<Faction> Factions { get; set; } = new List<Faction>();
        public ICollection<Character> Characters { get; set; } = new List<Character>();
    }
}