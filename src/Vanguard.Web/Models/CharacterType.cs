namespace Vanguard.Web.Models;

public class CharacterType
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<Character> Characters { get; set; } = new List<Character>();
    public ICollection<Npc> Npcs { get; set; } = new List<Npc>();
}