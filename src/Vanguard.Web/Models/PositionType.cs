namespace Vanguard.Web.Models;
    public class PositionType
    {
        public int Id { get; set; }
        public required string Name { get; set; } // e.g., "Branch Leader"
        public required string RoleName { get; set; } // e.g., "BranchLeader"
        public int Level { get; set; } // e.g., 3
        public bool RequiresScope { get; set; }
        public bool IsActive { get; set; } = true;
        public int DisplayOrder { get; set; }

        public ICollection<Position>? Positions { get; set; } = new List<Position>();
    }