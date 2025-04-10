namespace Vanguard.Web.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public int MinRankLevel { get; set; }
        public Rank MinRank { get; set; }
        public int MaxRankLevel { get; set; }
        public Rank MaxRank { get; set; }
        public int UniverseId { get; set; }
        public Universe Universe { get; set; }
        public int FactionId { get; set; }
        public Faction Faction { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        public ICollection<Character> Characters { get; set; }
    }
}