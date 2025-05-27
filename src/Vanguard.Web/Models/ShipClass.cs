namespace Vanguard.Web.Models;

public class ShipClass
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Abbreviation { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
    public int DisplayOrder { get; set; }

    public int? UniverseId { get; set; }
    public Universe? Universe { get; set; }

    public int? FactionId { get; set; }
    public Faction? Faction { get; set; }

    public int? BranchId { get; set; }
    public Branch? Branch { get; set; }

    public ICollection<Ship> Ships { get; set; } = new List<Ship>();
}