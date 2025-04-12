namespace Vanguard.Web.Models
{
    public class PositionType
    {
        public int Id { get; set; }
        public string Name { get; set; } // e.g., "Branch Leader"
        public string RoleName { get; set; } // e.g., "BranchLeader"
        public int Level { get; set; } // e.g., 3

        public ICollection<Position> Positions { get; set; } = new List<Position>();
    }
}