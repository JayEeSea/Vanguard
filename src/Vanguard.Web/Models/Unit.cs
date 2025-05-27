namespace Vanguard.Web.Models;
    public class Unit
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }

    public int? UniverseId { get; set; }
    public Universe? Universe { get; set; }

    public int? FactionId { get; set; }
    public Faction? Faction { get; set; }

    public int? BranchId { get; set; }
    public Branch? Branch { get; set; }
    public bool IsActive { get; set; } = true;
    public int? DisplayOrder { get; set; }

    public int? ParentUnitId { get; set; }
    public Unit? ParentUnit { get; set; }

    public int? ShipId { get; set; }
    public Ship? Ship { get; set; }

    public ICollection<Unit>? SubUnits { get; set; } = new List<Unit>();
    public ICollection<Character>? Characters { get; set; } = new List<Character>();
}