using System;

namespace Vanguard.Web.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime DateCreated { get; set; }
        public string? AddressedName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string? ImageUrl { get; set; }
        public string Appearance { get; set; }
        public string Personality { get; set; }
        public string Background { get; set; }

        public int SpeciesId { get; set; }
        public Species Species { get; set; }

        public int GenderId { get; set; }
        public Gender Gender { get; set; }

        public string MemberId { get; set; }
        public ApplicationUser Member { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }

        public int RankId { get; set; }
        public Rank Rank { get; set; }

        public int UniverseId { get; set; }
        public Universe Universe { get; set; }

        public int FactionId { get; set; }
        public Faction Faction { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public int UnitId { get; set; }
        public Unit Unit { get; set; }

        public DateTime? LastPromotionDate { get; set; }
        public DateTime? LastMedalDate { get; set; }
    }
}