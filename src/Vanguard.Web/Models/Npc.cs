namespace Vanguard.Web.Models
{
    public class Npc
    {
        public int Id { get; set; }
        public required string DisplayName { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? FullName { get; set; }
        public int CharacterTypeId { get; set; }
        public CharacterType CharacterType { get; set; } = null!;
        public DateTimeOffset DateCreated { get; set; }
        public string? AddressedName { get; set; }
        public DateTimeOffset? DateOfBirth { get; set; }
        public string? PlaceOfBirth { get; set; }
        public string? ImageUrl { get; set; }
        public string? Appearance { get; set; }
        public string? Personality { get; set; }
        public string? Background { get; set; }
        public int? SpeciesId { get; set; }
        public Species? Species { get; set; }
        public int? GenderId { get; set; }
        public Gender? Gender { get; set; }
        public int? RankId { get; set; }
        public Rank? Rank { get; set; }
        public int? UniverseId { get; set; }
        public Universe? Universe { get; set; }
        public int? FactionId { get; set; }
        public Faction? Faction { get; set; }
        public int? BranchId { get; set; }
        public Branch? Branch { get; set; }
        public int? UnitId { get; set; }
        public Unit? Unit { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTimeOffset? LastPromotionDate { get; set; }
        public DateTimeOffset? LastMedalDate { get; set; }
    }
}