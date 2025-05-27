namespace Vanguard.Web.Models;

public class Position
{
    public int Id { get; set; }

    public int? PositionTypeId { get; set; }
    public PositionType? PositionType { get; set; }

    public required string Name { get; set; }
    public required string Abbreviation { get; set; }
    public int? MinRankLevel { get; set; }
    public Rank? MinRank { get; set; }
    public int? MaxRankLevel { get; set; }
    public Rank? MaxRank { get; set; }

    public string? ImageUrl { get; set; }

    public int? UniverseId { get; set; }
    public Universe? Universe { get; set; }

    public int? FactionId { get; set; }
    public Faction? Faction { get; set; }

    public int? BranchId { get; set; }
    public Branch? Branch { get; set; }

    public int? UnitId { get; set; }
    public Unit? Unit { get; set; }

    public bool RequiresScope { get; set; }
    public bool IsActive { get; set; } = true;
    public int DisplayOrder { get; set; }

    public ICollection<Character> Characters { get; set; } = new List<Character>();
}